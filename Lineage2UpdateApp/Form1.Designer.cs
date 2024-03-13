namespace Lineage2UpdateApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            picBoxCloseApp = new System.Windows.Forms.PictureBox();
            lblMainTitle = new System.Windows.Forms.Label();
            lblDownloadProgress = new System.Windows.Forms.Label();
            lblTotalProgress = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            progressBarDownload = new System.Windows.Forms.ProgressBar();
            progressBarTotal = new System.Windows.Forms.ProgressBar();
            btnStart = new System.Windows.Forms.Button();
            btnCheck = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)picBoxCloseApp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webView).BeginInit();
            SuspendLayout();
            // 
            // picBoxCloseApp
            // 
            picBoxCloseApp.BackgroundImage = Properties.ImageResources.CloseButton;
            picBoxCloseApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            picBoxCloseApp.Location = new System.Drawing.Point(634, 2);
            picBoxCloseApp.Name = "picBoxCloseApp";
            picBoxCloseApp.Size = new System.Drawing.Size(14, 14);
            picBoxCloseApp.TabIndex = 0;
            picBoxCloseApp.TabStop = false;
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            lblMainTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            lblMainTitle.ForeColor = System.Drawing.Color.LightGray;
            lblMainTitle.Location = new System.Drawing.Point(68, 2);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new System.Drawing.Size(144, 13);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "Lineage II Automatic Update";
            // 
            // lblDownloadProgress
            // 
            lblDownloadProgress.AutoSize = true;
            lblDownloadProgress.BackColor = System.Drawing.Color.Transparent;
            lblDownloadProgress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            lblDownloadProgress.ForeColor = System.Drawing.Color.White;
            lblDownloadProgress.Location = new System.Drawing.Point(12, 410);
            lblDownloadProgress.Name = "lblDownloadProgress";
            lblDownloadProgress.Size = new System.Drawing.Size(82, 14);
            lblDownloadProgress.TabIndex = 2;
            lblDownloadProgress.Text = "File Download";
            // 
            // lblTotalProgress
            // 
            lblTotalProgress.AutoSize = true;
            lblTotalProgress.BackColor = System.Drawing.Color.Transparent;
            lblTotalProgress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            lblTotalProgress.ForeColor = System.Drawing.Color.White;
            lblTotalProgress.Location = new System.Drawing.Point(10, 425);
            lblTotalProgress.Name = "lblTotalProgress";
            lblTotalProgress.Size = new System.Drawing.Size(85, 14);
            lblTotalProgress.TabIndex = 3;
            lblTotalProgress.Text = "Total Progress";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            label1.ForeColor = System.Drawing.Color.DarkGray;
            label1.Location = new System.Drawing.Point(11, 449);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(151, 13);
            label1.TabIndex = 4;
            label1.Text = "2005-2024 (c) HellFire, Russia";
            // 
            // progressBarDownload
            // 
            progressBarDownload.Location = new System.Drawing.Point(97, 413);
            progressBarDownload.Name = "progressBarDownload";
            progressBarDownload.Size = new System.Drawing.Size(330, 10);
            progressBarDownload.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBarDownload.TabIndex = 1;
            // 
            // progressBarTotal
            // 
            progressBarTotal.Location = new System.Drawing.Point(97, 429);
            progressBarTotal.Name = "progressBarTotal";
            progressBarTotal.Size = new System.Drawing.Size(330, 10);
            progressBarTotal.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            progressBarTotal.TabIndex = 5;
            // 
            // btnStart
            // 
            btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnStart.Image = Properties.ImageResources.ButtonStart4;
            btnStart.Location = new System.Drawing.Point(445, 400);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(100, 45);
            btnStart.TabIndex = 6;
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnCheck.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btnCheck.ForeColor = System.Drawing.Color.White;
            btnCheck.Image = Properties.ImageResources.ButtonBlack;
            btnCheck.Location = new System.Drawing.Point(548, 400);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new System.Drawing.Size(100, 20);
            btnCheck.TabIndex = 7;
            btnCheck.Text = "Check file";
            btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            btnCheck.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnCancel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Image = Properties.ImageResources.ButtonBlack;
            btnCancel.Location = new System.Drawing.Point(548, 425);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 20);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // webView
            // 
            webView.AllowExternalDrop = false;
            webView.CreationProperties = null;
            webView.DefaultBackgroundColor = System.Drawing.Color.White;
            webView.Location = new System.Drawing.Point(10, 18);
            webView.Name = "webView";
            webView.Size = new System.Drawing.Size(638, 360);
            webView.TabIndex = 9;
            webView.ZoomFactor = 1D;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = System.Drawing.Color.Transparent;
            lblStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            lblStatus.ForeColor = System.Drawing.Color.White;
            lblStatus.Location = new System.Drawing.Point(97, 381);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(330, 29);
            lblStatus.TabIndex = 10;
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.ImageResources.background;
            ClientSize = new System.Drawing.Size(660, 465);
            Controls.Add(lblStatus);
            Controls.Add(webView);
            Controls.Add(btnCancel);
            Controls.Add(btnCheck);
            Controls.Add(btnStart);
            Controls.Add(progressBarTotal);
            Controls.Add(progressBarDownload);
            Controls.Add(label1);
            Controls.Add(lblTotalProgress);
            Controls.Add(lblDownloadProgress);
            Controls.Add(lblMainTitle);
            Controls.Add(picBoxCloseApp);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Lineage II client autoupdate";
            ((System.ComponentModel.ISupportInitialize)picBoxCloseApp).EndInit();
            ((System.ComponentModel.ISupportInitialize)webView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxCloseApp;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblDownloadProgress;
        private System.Windows.Forms.Label lblTotalProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBarDownload;
        private System.Windows.Forms.ProgressBar progressBarTotal;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnCancel;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.Label lblStatus;
    }
}
