namespace GangOS.Common.GUI.Controls
{
    partial class CharacterItem
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
            this.lblUser = new System.Windows.Forms.Label();
            this.lblDNA = new System.Windows.Forms.Label();
            this.lblMedals = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(12, 12);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Username";
            // 
            // lblDNA
            // 
            this.lblDNA.AutoSize = true;
            this.lblDNA.Location = new System.Drawing.Point(12, 35);
            this.lblDNA.Name = "lblDNA";
            this.lblDNA.Size = new System.Drawing.Size(42, 13);
            this.lblDNA.TabIndex = 2;
            this.lblDNA.Text = "DNA: 0";
            // 
            // lblMedals
            // 
            this.lblMedals.AutoSize = true;
            this.lblMedals.Location = new System.Drawing.Point(12, 48);
            this.lblMedals.Name = "lblMedals";
            this.lblMedals.Size = new System.Drawing.Size(53, 13);
            this.lblMedals.TabIndex = 3;
            this.lblMedals.Text = "Medals: 0";
            // 
            // CharacterItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMedals);
            this.Controls.Add(this.lblDNA);
            this.Controls.Add(this.lblUser);
            this.MinimumSize = new System.Drawing.Size(115, 75);
            this.Name = "CharacterItem";
            this.Size = new System.Drawing.Size(115, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblDNA;
        private System.Windows.Forms.Label lblMedals;
    }
}
