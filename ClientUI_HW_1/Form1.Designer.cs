namespace ClientUI_HW_1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            tb_IP = new TextBox();
            tb_Port = new TextBox();
            btnConnect = new Button();
            btnSendMessage = new Button();
            label3 = new Label();
            tb_Responce = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(194, 9);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // tb_IP
            // 
            tb_IP.Location = new Point(35, 6);
            tb_IP.Name = "tb_IP";
            tb_IP.Size = new Size(153, 23);
            tb_IP.TabIndex = 2;
            // 
            // tb_Port
            // 
            tb_Port.Location = new Point(229, 6);
            tb_Port.Name = "tb_Port";
            tb_Port.Size = new Size(98, 23);
            tb_Port.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(345, 6);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(104, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSendMessage
            // 
            btnSendMessage.Location = new Point(180, 52);
            btnSendMessage.Name = "btnSendMessage";
            btnSendMessage.Size = new Size(118, 23);
            btnSendMessage.TabIndex = 5;
            btnSendMessage.Text = "Send a greeting";
            btnSendMessage.UseVisualStyleBackColor = true;
            btnSendMessage.Click += btnSendMessage_ClickAsync;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(208, 90);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Responce";
            // 
            // tb_Responce
            // 
            tb_Responce.Location = new Point(35, 124);
            tb_Responce.Name = "tb_Responce";
            tb_Responce.ReadOnly = true;
            tb_Responce.Size = new Size(414, 23);
            tb_Responce.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 172);
            Controls.Add(tb_Responce);
            Controls.Add(label3);
            Controls.Add(btnSendMessage);
            Controls.Add(btnConnect);
            Controls.Add(tb_Port);
            Controls.Add(tb_IP);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_IP;
        private TextBox tb_Port;
        private Button btnConnect;
        private Button btnSendMessage;
        private Label label3;
        private TextBox tb_Responce;
    }
}