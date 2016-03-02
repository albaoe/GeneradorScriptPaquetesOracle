namespace GeneradorScriptPaquetesOracle
{
    partial class AddConnectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddConnectionForm));
            this.hostBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.serviceBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.aliasBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hostBox
            // 
            this.hostBox.Location = new System.Drawing.Point(10, 70);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(260, 20);
            this.hostBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOST o dirección IP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Añadir cadena de conexión";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre del servicio";
            // 
            // serviceBox
            // 
            this.serviceBox.Location = new System.Drawing.Point(10, 148);
            this.serviceBox.Name = "serviceBox";
            this.serviceBox.Size = new System.Drawing.Size(260, 20);
            this.serviceBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "User id";
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(10, 187);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(260, 20);
            this.userBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(119, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(10, 226);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(260, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Puerto";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(10, 109);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(260, 20);
            this.portBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(98, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Alias de la conexión";
            // 
            // aliasBox
            // 
            this.aliasBox.Location = new System.Drawing.Point(10, 31);
            this.aliasBox.Name = "aliasBox";
            this.aliasBox.Size = new System.Drawing.Size(260, 20);
            this.aliasBox.TabIndex = 0;
            // 
            // AddConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 305);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.aliasBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serviceBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddConnectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Añadir cadena de conexión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hostBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox serviceBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox aliasBox;
    }
}