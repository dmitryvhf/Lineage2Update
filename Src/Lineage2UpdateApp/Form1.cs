using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Lineage2UpdateApp
{
    public partial class Form1 : Form
    {
        const string downloadUrl = "http://127.0.0.1:8080/live.htm"; // "http://localhost/update";

        public Form1()
        {
            InitializeComponent();

            // Register form events
            MouseDown += OnMouseDown;
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;

            picBoxCloseApp.Click += PicBoxCloseAppOnClick;
            // Register form events

            webView.Visible = false;
            webView.Enabled = false;
            webView.NavigationCompleted += NavigationCompleted;
            webView.Source = new Uri(downloadUrl);
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
                lblStatus.Text = "Update resource not available...";
            }
        }
    }
}