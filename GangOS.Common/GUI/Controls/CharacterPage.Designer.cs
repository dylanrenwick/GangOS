namespace GangOS.Common.GUI.Controls
{
    partial class CharacterPage
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
            this.characterPageHeader = new GangOS.Common.GUI.Controls.CharacterPageHeader();
            this.SuspendLayout();
            // 
            // characterPageHeader
            // 
            this.characterPageHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.characterPageHeader.Location = new System.Drawing.Point(0, 0);
            this.characterPageHeader.Name = "characterPageHeader";
            this.characterPageHeader.Padding = new System.Windows.Forms.Padding(10);
            this.characterPageHeader.Size = new System.Drawing.Size(361, 98);
            this.characterPageHeader.TabIndex = 0;
            // 
            // CharacterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.characterPageHeader);
            this.Name = "CharacterPage";
            this.Size = new System.Drawing.Size(361, 507);
            this.ResumeLayout(false);

        }

        #endregion

        private CharacterPageHeader characterPageHeader;
    }
}
