namespace FirstScaffolding.Wizard
{
    partial class FormInput
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
            this.boxAPI = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxApplication = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxDomain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.boxIoC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.boxRepository = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxAPI
            // 
            this.boxAPI.FormattingEnabled = true;
            this.boxAPI.Location = new System.Drawing.Point(34, 45);
            this.boxAPI.Name = "boxAPI";
            this.boxAPI.Size = new System.Drawing.Size(327, 21);
            this.boxAPI.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "WebAPI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Application";
            // 
            // boxApplication
            // 
            this.boxApplication.FormattingEnabled = true;
            this.boxApplication.Location = new System.Drawing.Point(34, 92);
            this.boxApplication.Name = "boxApplication";
            this.boxApplication.Size = new System.Drawing.Size(327, 21);
            this.boxApplication.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Domain";
            // 
            // boxDomain
            // 
            this.boxDomain.FormattingEnabled = true;
            this.boxDomain.Location = new System.Drawing.Point(34, 140);
            this.boxDomain.Name = "boxDomain";
            this.boxDomain.Size = new System.Drawing.Size(327, 21);
            this.boxDomain.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "IoC";
            // 
            // boxIoC
            // 
            this.boxIoC.FormattingEnabled = true;
            this.boxIoC.Location = new System.Drawing.Point(34, 182);
            this.boxIoC.Name = "boxIoC";
            this.boxIoC.Size = new System.Drawing.Size(327, 21);
            this.boxIoC.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Repository";
            // 
            // boxRepository
            // 
            this.boxRepository.FormattingEnabled = true;
            this.boxRepository.Location = new System.Drawing.Point(34, 232);
            this.boxRepository.Name = "boxRepository";
            this.boxRepository.Size = new System.Drawing.Size(327, 21);
            this.boxRepository.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 293);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.boxRepository);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.boxIoC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.boxDomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.boxApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxAPI);
            this.Name = "FormInput";
            this.Text = "FormInput";
            this.Load += new System.EventHandler(this.FormInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox boxAPI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox boxApplication;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox boxDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox boxIoC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox boxRepository;
        private System.Windows.Forms.Button button1;
    }
}