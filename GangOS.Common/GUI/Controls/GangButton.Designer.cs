namespace GangOS.Common.GUI.Controls
{
    partial class GangButton
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
            this.lblGangName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGangName
            // 
            this.lblGangName.AutoSize = true;
            this.lblGangName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGangName.Location = new System.Drawing.Point(12, 12);
            this.lblGangName.Name = "lblGangName";
            this.lblGangName.Size = new System.Drawing.Size(73, 13);
            this.lblGangName.TabIndex = 1;
            this.lblGangName.Text = "Gang Name";
            // 
            // GangButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblGangName);
            this.MinimumSize = new System.Drawing.Size(96, 38);
            this.Name = "GangButton";
            this.Size = new System.Drawing.Size(96, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGangName;
    }
}
