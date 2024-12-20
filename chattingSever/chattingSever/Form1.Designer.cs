namespace chattingSever
{
    partial class txtChatMsg 
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
            textBox1 = new TextBox();
            btnStart = new Button();
            lblMsg = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 12);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(292, 341);
            textBox1.TabIndex = 0;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(181, 370);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(123, 50);
            btnStart.TabIndex = 1;
            btnStart.Text = "서버 시작";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Location = new Point(21, 388);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(80, 15);
            lblMsg.TabIndex = 2;
            lblMsg.Tag = "Stop";
            lblMsg.Text = "Sever 중지 됨";
            // 
            // txtChatMsg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 442);
            Controls.Add(lblMsg);
            Controls.Add(btnStart);
            Controls.Add(textBox1);
            Name = "txtChatMsg";
            Text = "Form1";
            FormClosed += txtChatMsg_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnStart;
        private Label lblMsg;
    }
}
