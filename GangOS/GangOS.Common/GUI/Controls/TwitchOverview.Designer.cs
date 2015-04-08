namespace GangOS.Common.GUI.Controls
{
    partial class TwitchOverview
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
            this.labelNoLivestreams = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNoLivestreams
            // 
            this.labelNoLivestreams.BackColor = System.Drawing.Color.Transparent;
            this.labelNoLivestreams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelNoLivestreams.Location = new System.Drawing.Point(0, 0);
            this.labelNoLivestreams.Name = "labelNoLivestreams";
            this.labelNoLivestreams.Size = new System.Drawing.Size(361, 507);
            this.labelNoLivestreams.TabIndex = 0;
            this.labelNoLivestreams.Text = "Nobody is currently streaming Gangs of Space";
            this.labelNoLivestreams.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TwitchOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.labelNoLivestreams);
            this.Name = "TwitchOverview";
            this.Size = new System.Drawing.Size(361, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNoLivestreams;
    }
}
