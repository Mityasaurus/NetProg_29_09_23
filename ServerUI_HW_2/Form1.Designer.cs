namespace ServerUI_HW_2
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
            btn_start = new Button();
            tb_log = new TextBox();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Location = new Point(184, 12);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(125, 31);
            btn_start.TabIndex = 0;
            btn_start.Text = "Start server";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // tb_log
            // 
            tb_log.Location = new Point(12, 57);
            tb_log.Multiline = true;
            tb_log.Name = "tb_log";
            tb_log.Size = new Size(460, 192);
            tb_log.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 261);
            Controls.Add(tb_log);
            Controls.Add(btn_start);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private TextBox tb_log;
    }
}