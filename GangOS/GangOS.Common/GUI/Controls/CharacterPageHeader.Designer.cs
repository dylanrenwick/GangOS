namespace GangOS.Common.GUI.Controls
{
    partial class CharacterPageHeader
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDNA = new System.Windows.Forms.Label();
            this.lblMedals = new System.Windows.Forms.Label();
            this.lblGang = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(13, 13);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 22);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblDNA
            // 
            this.lblDNA.AutoSize = true;
            this.lblDNA.ForeColor = System.Drawing.Color.Green;
            this.lblDNA.Location = new System.Drawing.Point(20, 41);
            this.lblDNA.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblDNA.Name = "lblDNA";
            this.lblDNA.Size = new System.Drawing.Size(75, 13);
            this.lblDNA.TabIndex = 1;
            this.lblDNA.Text = "DNA: 123,456";
            // 
            // lblMedals
            // 
            this.lblMedals.AutoSize = true;
            this.lblMedals.ForeColor = System.Drawing.Color.Black;
            this.lblMedals.Location = new System.Drawing.Point(20, 54);
            this.lblMedals.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblMedals.Name = "lblMedals";
            this.lblMedals.Size = new System.Drawing.Size(74, 13);
            this.lblMedals.TabIndex = 2;
            this.lblMedals.Text = "Medals: 1,234";
            // 
            // lblGang
            // 
            this.lblGang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGang.AutoSize = true;
            this.lblGang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGang.Location = new System.Drawing.Point(275, 41);
            this.lblGang.Name = "lblGang";
            this.lblGang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblGang.Size = new System.Drawing.Size(73, 13);
            this.lblGang.TabIndex = 3;
            this.lblGang.Text = "Gang Name";
            this.lblGang.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CharacterPageHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGang);
            this.Controls.Add(this.lblMedals);
            this.Controls.Add(this.lblDNA);
            this.Controls.Add(this.lblUsername);
            this.Name = "CharacterPageHeader";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(361, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDNA;
        private System.Windows.Forms.Label lblMedals;
        private System.Windows.Forms.Label lblGang;
    }
}
