namespace GangOS.Common.GUI.Controls
{
    partial class TwitchItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgTwitchAvatar = new System.Windows.Forms.PictureBox();
            this.lblTwitchUser = new System.Windows.Forms.Label();
            this.lblViewerCount = new System.Windows.Forms.Label();
            this.lblFollowerCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitchAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // imgTwitchAvatar
            // 
            this.imgTwitchAvatar.Location = new System.Drawing.Point(8, 8);
            this.imgTwitchAvatar.Name = "imgTwitchAvatar";
            this.imgTwitchAvatar.Size = new System.Drawing.Size(86, 86);
            this.imgTwitchAvatar.TabIndex = 0;
            this.imgTwitchAvatar.TabStop = false;
            // 
            // lblTwitchUser
            // 
            this.lblTwitchUser.AutoSize = true;
            this.lblTwitchUser.Location = new System.Drawing.Point(100, 12);
            this.lblTwitchUser.Name = "lblTwitchUser";
            this.lblTwitchUser.Size = new System.Drawing.Size(90, 13);
            this.lblTwitchUser.TabIndex = 1;
            this.lblTwitchUser.Text = "Twitch Username";
            // 
            // lblViewerCount
            // 
            this.lblViewerCount.AutoSize = true;
            this.lblViewerCount.Location = new System.Drawing.Point(100, 37);
            this.lblViewerCount.Name = "lblViewerCount";
            this.lblViewerCount.Size = new System.Drawing.Size(56, 13);
            this.lblViewerCount.TabIndex = 2;
            this.lblViewerCount.Text = "Viewers: 0";
            // 
            // lblFollowerCount
            // 
            this.lblFollowerCount.AutoSize = true;
            this.lblFollowerCount.Location = new System.Drawing.Point(100, 50);
            this.lblFollowerCount.Name = "lblFollowerCount";
            this.lblFollowerCount.Size = new System.Drawing.Size(63, 13);
            this.lblFollowerCount.TabIndex = 3;
            this.lblFollowerCount.Text = "Followers: 0";
            // 
            // TwitchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFollowerCount);
            this.Controls.Add(this.lblViewerCount);
            this.Controls.Add(this.lblTwitchUser);
            this.Controls.Add(this.imgTwitchAvatar);
            this.MinimumSize = new System.Drawing.Size(270, 102);
            this.Name = "TwitchItem";
            this.Size = new System.Drawing.Size(270, 102);
            ((System.ComponentModel.ISupportInitialize)(this.imgTwitchAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgTwitchAvatar;
        private System.Windows.Forms.Label lblTwitchUser;
        private System.Windows.Forms.Label lblViewerCount;
        private System.Windows.Forms.Label lblFollowerCount;
    }
}
