namespace GangOS
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addAPIKey = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOverview = new System.Windows.Forms.TabPage();
            this.tabLivestreams = new System.Windows.Forms.TabPage();
            this.twitchOverview1 = new GangOS.Common.GUI.Controls.TwitchOverview();
            this.charOverview = new GangOS.Common.GUI.Controls.CharacterOverview();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabOverview.SuspendLayout();
            this.tabLivestreams.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAPIKey});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(512, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addAPIKey
            // 
            this.addAPIKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addAPIKey.Image = ((System.Drawing.Image)(resources.GetObject("addAPIKey.Image")));
            this.addAPIKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addAPIKey.Name = "addAPIKey";
            this.addAPIKey.Size = new System.Drawing.Size(23, 22);
            this.addAPIKey.Text = "toolStripButton1";
            this.addAPIKey.Click += new System.EventHandler(this.addAPIKey_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOverview);
            this.tabControl.Controls.Add(this.tabLivestreams);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 49);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(512, 435);
            this.tabControl.TabIndex = 2;
            // 
            // tabOverview
            // 
            this.tabOverview.Controls.Add(this.charOverview);
            this.tabOverview.Location = new System.Drawing.Point(4, 22);
            this.tabOverview.Name = "tabOverview";
            this.tabOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabOverview.Size = new System.Drawing.Size(504, 409);
            this.tabOverview.TabIndex = 0;
            this.tabOverview.Text = "Overview";
            this.tabOverview.UseVisualStyleBackColor = true;
            // 
            // tabLivestreams
            // 
            this.tabLivestreams.Controls.Add(this.twitchOverview1);
            this.tabLivestreams.Location = new System.Drawing.Point(4, 22);
            this.tabLivestreams.Name = "tabLivestreams";
            this.tabLivestreams.Padding = new System.Windows.Forms.Padding(3);
            this.tabLivestreams.Size = new System.Drawing.Size(504, 409);
            this.tabLivestreams.TabIndex = 1;
            this.tabLivestreams.Text = "Twitch Streams";
            this.tabLivestreams.UseVisualStyleBackColor = true;
            // 
            // twitchOverview1
            // 
            this.twitchOverview1.BackColor = System.Drawing.Color.Transparent;
            this.twitchOverview1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.twitchOverview1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twitchOverview1.Location = new System.Drawing.Point(3, 3);
            this.twitchOverview1.Margin = new System.Windows.Forms.Padding(0);
            this.twitchOverview1.Name = "twitchOverview1";
            this.twitchOverview1.Padding = new System.Windows.Forms.Padding(3);
            this.twitchOverview1.Size = new System.Drawing.Size(498, 403);
            this.twitchOverview1.TabIndex = 0;
            // 
            // charOverview
            // 
            this.charOverview.BackColor = System.Drawing.Color.Transparent;
            this.charOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.charOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charOverview.Location = new System.Drawing.Point(3, 3);
            this.charOverview.Name = "charOverview";
            this.charOverview.Size = new System.Drawing.Size(498, 403);
            this.charOverview.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 484);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabOverview.ResumeLayout(false);
            this.tabLivestreams.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addAPIKey;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOverview;
        private System.Windows.Forms.TabPage tabLivestreams;
        private Common.GUI.Controls.TwitchOverview twitchOverview1;
        private Common.GUI.Controls.CharacterOverview charOverview;
    }
}

