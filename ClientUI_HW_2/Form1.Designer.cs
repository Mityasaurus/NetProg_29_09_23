namespace ClientUI_HW_2
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
            tb_IP = new TextBox();
            label2 = new Label();
            tb_Port = new TextBox();
            btnConnect = new Button();
            btnGetDate = new Button();
            btnGetTime = new Button();
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
            // tb_IP
            // 
            tb_IP.Location = new Point(35, 6);
            tb_IP.Name = "tb_IP";
            tb_IP.Size = new Size(147, 23);
            tb_IP.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 9);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 2;
            label2.Text = "Port";
            // 
            // tb_Port
            // 
            tb_Port.Location = new Point(238, 6);
            tb_Port.Name = "tb_Port";
            tb_Port.Size = new Size(122, 23);
            tb_Port.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(378, 6);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(85, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnGetDate
            // 
            btnGetDate.Location = new Point(35, 54);
            btnGetDate.Name = "btnGetDate";
            btnGetDate.Size = new Size(147, 23);
            btnGetDate.TabIndex = 5;
            btnGetDate.Text = "Get date";
            btnGetDate.UseVisualStyleBackColor = true;
            btnGetDate.Click += btnGetDate_ClickAsync;
            // 
            // btnGetTime
            // 
            btnGetTime.Location = new Point(238, 54);
            btnGetTime.Name = "btnGetTime";
            btnGetTime.Size = new Size(122, 23);
            btnGetTime.TabIndex = 6;
            btnGetTime.Text = "Get time";
            btnGetTime.UseVisualStyleBackColor = true;
            btnGetTime.Click += btnGetTime_ClickAsync;
            // 
            // tb_Responce
            // 
            tb_Responce.Location = new Point(35, 113);
            tb_Responce.Name = "tb_Responce";
            tb_Responce.ReadOnly = true;
            tb_Responce.Size = new Size(325, 23);
            tb_Responce.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 161);
            Controls.Add(tb_Responce);
            Controls.Add(btnGetTime);
            Controls.Add(btnGetDate);
            Controls.Add(btnConnect);
            Controls.Add(tb_Port);
            Controls.Add(label2);
            Controls.Add(tb_IP);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tb_IP;
        private Label label2;
        private TextBox tb_Port;
        private Button btnConnect;
        private Button btnGetDate;
        private Button btnGetTime;
        private TextBox tb_Responce;
    }
}