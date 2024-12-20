namespace ChattingClient
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
            txtName = new TextBox();
            label1 = new Label();
            btnConncet = new Button();
            textChatMsg = new TextBox();
            txtMsg = new TextBox();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(93, 25);
            txtName.Name = "txtName";
            txtName.Size = new Size(141, 23);
            txtName.TabIndex = 0;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 28);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 1;
            label1.Text = "대화명";
            // 
            // btnConncet
            // 
            btnConncet.Location = new Point(251, 24);
            btnConncet.Name = "btnConncet";
            btnConncet.Size = new Size(75, 23);
            btnConncet.TabIndex = 2;
            btnConncet.Text = "입장";
            btnConncet.UseVisualStyleBackColor = true;
            btnConncet.Click += btnConncet_Click;
            // 
            // textChatMsg
            // 
            textChatMsg.Location = new Point(27, 72);
            textChatMsg.Multiline = true;
            textChatMsg.Name = "textChatMsg";
            textChatMsg.ScrollBars = ScrollBars.Vertical;
            textChatMsg.Size = new Size(299, 237);
            textChatMsg.TabIndex = 3;
            // 
            // txtMsg
            // 
            txtMsg.Location = new Point(29, 329);
            txtMsg.Name = "txtMsg";
            txtMsg.Size = new Size(297, 23);
            txtMsg.TabIndex = 4;
            txtMsg.KeyPress += txtMsg_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 369);
            Controls.Add(txtMsg);
            Controls.Add(textChatMsg);
            Controls.Add(btnConncet);
            Controls.Add(label1);
            Controls.Add(txtName);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Button btnConncet;
        private TextBox textChatMsg;
        private TextBox txtMsg;
    }
}
