namespace ProiectMasini_FormsT8
{
    partial class ModificaT8
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
            this.introducereLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.idTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // introducereLbl
            // 
            this.introducereLbl.AutoSize = true;
            this.introducereLbl.Location = new System.Drawing.Point(55, 49);
            this.introducereLbl.Name = "introducereLbl";
            this.introducereLbl.Size = new System.Drawing.Size(339, 17);
            this.introducereLbl.TabIndex = 0;
            this.introducereLbl.Text = "Introduceti ID-ul masinii pe care doriti sa o modificati:";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(275, 95);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // idTxt
            // 
            this.idTxt.Location = new System.Drawing.Point(58, 95);
            this.idTxt.Name = "idTxt";
            this.idTxt.Size = new System.Drawing.Size(100, 22);
            this.idTxt.TabIndex = 2;
            // 
            // ModificaT8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 169);
            this.Controls.Add(this.idTxt);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.introducereLbl);
            this.Name = "ModificaT8";
            this.Text = "ModificaT8";
            this.Load += new System.EventHandler(this.ModificaT8_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label introducereLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.TextBox idTxt;
    }
}