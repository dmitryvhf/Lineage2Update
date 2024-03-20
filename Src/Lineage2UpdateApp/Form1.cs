using System;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lineage2UpdateApp.Models;
using Lineage2UpdateApp.Models.Configuration;
using Lineage2UpdateApp.Services;
using Microsoft.Web.WebView2.Core;

namespace Lineage2UpdateApp
{
    public partial class Form1 : Form
    {
        private AppConfiguration _localConfiguration;
        private RemoteConfiguration _remoteConfiguration;

        public Form1()
        {
            InitializeComponent();

            // Register form events
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;

            picBoxCloseApp.Click += PicBoxCloseAppOnClick;

            this.Load += OnLoad;
            // Register form events
        }

        private async void OnLoad(object? sender, EventArgs e)
        {
            ReadLocalConfiguration();

            await ReadRemoteConfigurationAsync();

            if (_remoteConfiguration == null)
            {
                return;
            }

            webView.Visible = false;
            webView.Enabled = false;
            webView.NavigationCompleted += NavigationCompleted;

            webView.Source = GetFullUri(_localConfiguration.UpdateBasePath, _remoteConfiguration.Settings.Index);
        }

        private void ReadLocalConfiguration()
        {
            string rawJson = System.IO.File.ReadAllText(AppConstants.ApplicationName + ".json");

            try
            {
                AppConfiguration localConfiguration = SupportTools.Deserialize<AppConfiguration>(rawJson)!;
                _localConfiguration = localConfiguration;
            }
            catch (Exception e)
            {
                throw new ExecuteException("Local configuration file is invalid.");
            }
        }

        private async Task ReadRemoteConfigurationAsync()
        {
            HttpResult remoteConfigJson = await GetHttpContentAsync("Lineage2RemoteConfiguration.json");
            if (!remoteConfigJson.IsSuccess || remoteConfigJson.Result == null)
            {
                return;
            }

            string jsonText = System.Text.Encoding.UTF8.GetString(remoteConfigJson.Result);

            try
            {
                RemoteConfiguration remoteConfiguration = SupportTools.Deserialize<RemoteConfiguration>(jsonText)!;
                _remoteConfiguration = remoteConfiguration;
            }
            catch (Exception e)
            {
                throw new ExecuteException("Remote configuration file is invalid.");
            }
        }

        private Uri GetFullUri(Uri basePath, string relativePath)
        {
            UriBuilder builder = new UriBuilder(basePath);
            builder.Path = relativePath;

            return new Uri(builder.Uri.ToString());
        }

        private async Task<HttpResult> GetHttpContentAsync(string relativePath)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Uri requestUri = GetFullUri(_localConfiguration.UpdateBasePath, relativePath);

                    HttpResponseMessage requestResult = await client.GetAsync(requestUri);
                    if (!requestResult.IsSuccessStatusCode)
                    {
                        return new HttpResult();
                    }

                    HttpResult result = new HttpResult()
                    {
                        IsSuccess = true,
                        Result = await requestResult.Content.ReadAsByteArrayAsync()
                    };

                    return result;
                }
                catch (Exception e)
                {
                    return new HttpResult();
                }
            }
        }

        private class HttpResult
        {
            public bool IsSuccess { get; init; }
            public byte[]? Result { get; init; }
        }

        #region Form drag/move implementation

        private bool _frmMoveIsMouseDown = false;
        private Point _frmMoveLastLocation;

        private void OnMouseDown(object? sender, MouseEventArgs e)
        {
            _frmMoveIsMouseDown = true;
            _frmMoveLastLocation = e.Location;
        }

        private void OnMouseUp(object? sender, MouseEventArgs e)
        {
            _frmMoveIsMouseDown = false;
        }

        /// <summary>
        ///     Custom method for drag/move form by mouse holding.
        /// </summary>
        /// <remarks>FormBorderStyle=None not allow move form by mouse.</remarks>
        private void OnMouseMove(object? sender, MouseEventArgs e)
        {
            if (_frmMoveIsMouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - _frmMoveLastLocation.X) + e.X, (this.Location.Y - _frmMoveLastLocation.Y) + e.Y);

                this.Update();
            }
        }

        #endregion

        private void PicBoxCloseAppOnClick(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (e.IsSuccess && e.HttpStatusCode == 200)
            {
                webView.Visible = true;
            }
            else
            {
                UpdateStatus("Update resource not available...");
            }
        }

        #region UI controls

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }

        #endregion

    }
}