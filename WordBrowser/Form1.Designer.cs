namespace WordBrowser
{
    partial class Form1
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
            this.fc_btn = new System.Windows.Forms.Button();
            this.rf_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fc_btn
            // 
            this.fc_btn.Location = new System.Drawing.Point(12, 51);
            this.fc_btn.Name = "fc_btn";
            this.fc_btn.Size = new System.Drawing.Size(83, 41);
            this.fc_btn.TabIndex = 0;
            this.fc_btn.Text = "Choose Word File";
            this.fc_btn.UseVisualStyleBackColor = true;
            this.fc_btn.Click += new System.EventHandler(this.fc_btn_Click);
            // 
            // rf_btn
            // 
            this.rf_btn.Location = new System.Drawing.Point(189, 51);
            this.rf_btn.Name = "rf_btn";
            this.rf_btn.Size = new System.Drawing.Size(83, 41);
            this.rf_btn.TabIndex = 2;
            this.rf_btn.Text = "Convert File";
            this.rf_btn.UseVisualStyleBackColor = true;
            this.rf_btn.Click += new System.EventHandler(this.rf_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 164);
            this.Controls.Add(this.rf_btn);
            this.Controls.Add(this.fc_btn);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Word Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fc_btn;
        private System.Windows.Forms.Button rf_btn;
    }
}

