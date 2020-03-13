namespace Serv
{
    partial class ServerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.bConnect = new System.Windows.Forms.Button();
            this.tAddress = new System.Windows.Forms.TextBox();
            this.tPort = new System.Windows.Forms.TextBox();
            this.lAddress = new System.Windows.Forms.Label();
            this.lPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(129, 118);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(75, 23);
            this.bConnect.TabIndex = 0;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.button1_Click);
            // 
            // tAddress
            // 
            this.tAddress.Location = new System.Drawing.Point(60, 24);
            this.tAddress.Name = "tAddress";
            this.tAddress.ReadOnly = true;
            this.tAddress.Size = new System.Drawing.Size(133, 20);
            this.tAddress.TabIndex = 1;
            this.tAddress.Text = "127.0.0.1";
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(60, 66);
            this.tPort.Name = "tPort";
            this.tPort.ReadOnly = true;
            this.tPort.Size = new System.Drawing.Size(53, 20);
            this.tPort.TabIndex = 2;
            this.tPort.Text = "1000";
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Location = new System.Drawing.Point(12, 27);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(45, 13);
            this.lAddress.TabIndex = 3;
            this.lAddress.Text = "Address";
            // 
            // lPort
            // 
            this.lPort.AutoSize = true;
            this.lPort.Location = new System.Drawing.Point(12, 73);
            this.lPort.Name = "lPort";
            this.lPort.Size = new System.Drawing.Size(26, 13);
            this.lPort.TabIndex = 4;
            this.lPort.Text = "Port";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 166);
            this.Controls.Add(this.lPort);
            this.Controls.Add(this.lAddress);
            this.Controls.Add(this.tPort);
            this.Controls.Add(this.tAddress);
            this.Controls.Add(this.bConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerForm";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox tAddress;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.Label lPort;
    }
}

