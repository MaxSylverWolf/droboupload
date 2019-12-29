using Nemiro.OAuth;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace DroBoUpload
{
    public partial class DroBoUpload : Form
    {
        private HttpAuthorization Authorization = null;

        private string CurrentPath = "";

        private long UploadingFileLength = 0;
        private string accessToken = "";
        private string accessCode = "";
        private string accountId = "";

        private Stream DownloadReader = null;
        private FileStream DownloadFileStream = null;
        private BinaryWriter DownloadWriter = null;
        private byte[] DownloadReadBuffer = new byte[4096];
        private static readonly HttpClient client = new HttpClient();

        public DroBoUpload()
        {
            InitializeComponent();
        }

        private void DroBoUpload_Load(object sender, EventArgs e)
        {
            textToken.Text = "";
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            accessToken = textToken.Text;
            this.Authorization = new HttpAuthorization(AuthorizationType.Bearer, accessToken);
            GetFiles();

        }
        private void GetFiles()
        {
            OAuthUtility.PostAsync
            (
              "https://api.dropboxapi.com/2/files/list_folder",
              new HttpParameterCollection
              {
          new
          {
            path = this.CurrentPath,
            include_media_info = true
          }
              },
              contentType: "application/json",
              authorization: this.Authorization,
              callback: this.GetFilesCheck
            );
        }

        private void GetFilesCheck(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(this.GetFilesCheck), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                this.listBox1.Items.Clear();
                this.listBox1.DisplayMember = "path_display";

                foreach (UniValue file in result["entries"])
                {
                    listBox1.Items.Add(file);
                }

                if (!String.IsNullOrEmpty(this.CurrentPath))
                {
                    this.listBox1.Items.Insert(0, UniValue.ParseJson("{path_display: '..'}"));
                }
            }
            else
            {
                MessageBox.Show(result.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
        }

        private void CreateNewFolder(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(this.CreateNewFolder), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                this.GetFiles();
            }
            else
            {
                if (result["error"].HasValue)
                {
                    MessageBox.Show(result["error"].ToString());
                }
                else
                {
                    MessageBox.Show(result.ToString());
                }
            }
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private void Downloading(IAsyncResult result)
        {
            var bytesRead = this.DownloadReader.EndRead(result);

            if (bytesRead > 0)
            {
                this.SafeInvoke(() =>
                {
                    this.progressBar1.Increment(bytesRead);
                });

                if (this.DownloadFileStream.CanWrite)
                {
                    this.DownloadWriter.Write(this.DownloadReadBuffer.Take(bytesRead).ToArray());
                    this.DownloadReader.BeginRead(this.DownloadReadBuffer, 0, this.DownloadReadBuffer.Length, Downloading, null);
                }
            }
            else
            {
                this.DownloadFileStream.Close();

                this.SafeInvoke(() =>
                {
                    this.progressBar1.Value = this.progressBar1.Maximum;
                });
            }
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK) { return; }
            var fs = new FileStream(this.openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            this.UploadingFileLength = fs.Length;
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = 100;

            var fileInfo = UniValue.Empty;
            fileInfo["path"] = (String.IsNullOrEmpty(this.CurrentPath) ? "/" : "") + Path.Combine(this.CurrentPath, Path.GetFileName(this.openFileDialog1.FileName)).Replace("\\", "/");
            fileInfo["mode"] = "add";
            fileInfo["autorename"] = true;
            fileInfo["mute"] = false;

            OAuthUtility.PostAsync
            (
              "https://content.dropboxapi.com/2/files/upload",
              new HttpParameterCollection
              {
          { fs }
              },
              headers: new NameValueCollection { { "Dropbox-API-Arg", fileInfo.ToString() } },
              contentType: "application/octet-stream",
              authorization: this.Authorization,
              callback: this.UploadingCheck,
              streamWriteCallback: this.UploadingProgressBar
            );
        }
        private void UploadingProgressBar(object sender, StreamWriteEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, StreamWriteEventArgs>(this.UploadingProgressBar), sender, e);
                return;
            }
            progressBar1.Value = Math.Min(Convert.ToInt32(Math.Round((e.TotalBytesWritten * 100.0) / this.UploadingFileLength)), 100);
        }

        private void UploadingCheck(RequestResult result)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<RequestResult>(this.UploadingCheck), result);
                return;
            }

            if (result.StatusCode == 200)
            {
                this.GetFiles();
            }
            else
            {
                if (result["error_summary"].HasValue)
                {
                    MessageBox.Show(result["error_summary"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(result.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void SafeInvoke(Action action)
        {
            try
            {
                if (this.IsDisposed)
                {
                    return;
                }
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<Action>(this.SafeInvoke), action);
                    return;
                }
                action();
            }
            catch (ObjectDisposedException ex)
            {
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            OAuthUtility.PostAsync("https://api.dropboxapi.com/2/files/create_folder", new HttpParameterCollection{
                new { path = ((String.IsNullOrEmpty(this.CurrentPath) ? "/" : "") + Path.Combine(this.CurrentPath, this.textFolderName.Text).Replace("\\", "/"))
        }
},
contentType: "application/json",
authorization: this.Authorization,
callback: this.CreateNewFolder
);
            this.panel2.Visible = false;
            this.textFolderName.Text = "";
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadFile();
        }

        private void DownloadFile()
        {
            if (listBox1.SelectedItem == null) { return; }

            var file = (UniValue)this.listBox1.SelectedItem;

            if (file["path_display"] == "..")
            {
                if (!String.IsNullOrEmpty(this.CurrentPath))
                {
                    this.CurrentPath = Path.GetDirectoryName(this.CurrentPath).Replace("\\", "/");
                    if (this.CurrentPath == "/") { this.CurrentPath = ""; }
                }
            }
            else
            {
                if (file[".tag"].Equals("folder"))
                {
                    this.CurrentPath = file["path_display"].ToString();
                }
                else
                {
                    this.saveFileDialog1.FileName = Path.GetFileName(file["path_display"].ToString());
                    if (this.saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                    this.progressBar1.Value = 0;
                    this.DownloadFileStream = new FileStream(this.saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                    this.DownloadWriter = new BinaryWriter(this.DownloadFileStream);
                    var req = WebRequest.Create("https://content.dropboxapi.com/2/files/download");
                    req.Method = "POST";
                    req.Headers.Add(HttpRequestHeader.Authorization, this.Authorization.ToString());
                    req.Headers.Add("Dropbox-API-Arg", UniValue.Create(new { path = file["path_display"].ToString() }).ToString());

                    req.BeginGetResponse(result =>
                    {
                        var resp = req.EndGetResponse(result);

                        this.SafeInvoke(() =>
                        {
                            this.progressBar1.Maximum = (int)resp.ContentLength;
                        });
                        this.DownloadReader = resp.GetResponseStream();
                        this.DownloadReader.BeginRead(this.DownloadReadBuffer, 0, this.DownloadReadBuffer.Length, this.Downloading, null);
                    }, null);
                }
            }
            this.GetFiles();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.AbsoluteUri.StartsWith(@"https://www.dropbox.com/1/oauth2/redirect_receiver"))
            {
                //  var code = HttpUtility.ParseQueryString(e.Url.Fragment.Substring(1))["access_token"];
                var code = HttpUtility.ParseQueryString(e.Url.Query).Get("code");
                code.Trim();
                //this.labelPleaseAu.Text = "Account: " + code;
                accessCode = code;
                webBrowser1.Navigate("https://www.dropbox.com");
                //     var client = new WebClient();
                //     client.Headers["Authorization"] = "Bearer " + code;
                //     var accountInfo = client.DownloadString("https://api.dropboxapi.com/oauth2/token");

                //      MessageBox.Show("Account info: " + code);

            }
        }

        private void addAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAccess();
        }

        private void AddNewAccess()
        {
            var clientID = "zwvcm5lpbp0jph3";
            var redirectUri = new Uri("https://www.dropbox.com/1/oauth2/redirect_receiver");
            var uri = string.Format(
                @"https://www.dropbox.com/1/oauth2/authorize?response_type=code&redirect_uri={0}&client_id={1}",
                redirectUri, clientID);

            webBrowser1.Navigate(uri);
        }
        private async void signWithCodeToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {/*
            var redirectUri = new Uri("https://www.dropbox.com/1/oauth2/redirect_token");
            var uri = string.Format(
                @"https://api.dropboxapi.com/oauth2/token?code={0}&grant_type=authorization_code&client_id={1}&client_secret={2}&redirect_uri={3}",
                accessCode, clientID, secretId,redirectUri);

            webBrowser1.Navigate(uri);
            
        */
            var response = AuthorizeMe();

        }
    
        private async Task AuthorizeMe()
        {
            var clientID = "zwvcm5lpbp0jph3";
            var secretId = "ervjxyvek0dv4ah";
            var values = new Dictionary<string, string>
{
   { "code", accessCode },
   { "grant_type", "authorization_code" },
                {"client_id", clientID },
                {"client_secret", secretId },
                {"redirect_uri", "https://www.dropbox.com/1/oauth2/redirect_receiver" }
};

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://api.dropboxapi.com/oauth2/token", content);

            var responseString = await response.Content.ReadAsStringAsync();
            var jss = new JavaScriptSerializer();
            Dictionary<string, string> sData = jss.Deserialize<Dictionary<string, string>>(responseString);
            accessToken = sData["access_token"].ToString();
            accountId = sData["account_id"].ToString();
            this.Authorization = new HttpAuthorization(AuthorizationType.Bearer, accessToken);
            GetFiles();
            using (var clientAcc = new HttpClient())
            {
                clientAcc.DefaultRequestHeaders.Accept.Clear();
                clientAcc.DefaultRequestHeaders.Authorization
                               = new AuthenticationHeaderValue("Bearer", accessToken);
                //clientAcc.DefaultRequestHeaders.Add("Content-type","application/json");
                clientAcc.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var valuesAcc = new Dictionary<string, string>
{
   { "account_id", accountId },
};

                var contentAcc = new FormUrlEncodedContent(valuesAcc);

                var responseAcc = await clientAcc.PostAsync("https://api.dropboxapi.com/2/users/get_account", contentAcc);
                var responseStringAcc = await responseAcc.Content.ReadAsStringAsync();
                var jssAcc = new JavaScriptSerializer();
                Dictionary<string, string> sDataAcc = jss.Deserialize<Dictionary<string, string>>(responseStringAcc);
                this.labelPleaseAu.Text = "Account: " + sDataAcc["email"];
            }
        }

        private void signWithCodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddNewAccess();
            var response = AuthorizeMe();
           
        }
    }
    }

