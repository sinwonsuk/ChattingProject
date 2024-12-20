using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChattingClient
{
    delegate void SetTextDelegate(string text);

    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tcpClient = null;

        NetworkStream ntwStream = null;

        ChatHandler chatHandler = new ChatHandler();


        private void btnConncet_Click(object sender, EventArgs e)
        {
            if (btnConncet.Text == "����")
            {

                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(IPAddress.Parse("127.0.0.1"),8888);
                    ntwStream = tcpClient.GetStream();


                   
                    chatHandler.Setup(this, ntwStream, this.textChatMsg);
                    Thread chatThread = new Thread(chatHandler.ChatProcess);
                    chatThread.Start();

                    MessageSnd("<" + txtName.Text + "> �Բ��� ���� �ϼ̽��ϴ�.", true);
                    btnConncet.Text = "������";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sever�����߻� �Ǵ� Start�� ���� ����" + ex.Message);

                }
            }
            else
            {
                MessageSnd("<" + txtName.Text + "> �Բ��� �������� �ϼ̽��ϴ�.", false);
                btnConncet.Text = "����";
                chatHandler.ChatClose();
                ntwStream.Close();
                tcpClient.Close();
            }
        }

        public void MessageSnd(string lstMessage, bool Msg)
        {
            try
            {
                string dateToSend = lstMessage + "\r\n";
                byte[] data = Encoding.Default.GetBytes(dateToSend);

                ntwStream.Write(data, 0, data.Length);

            }
            catch (Exception ex)
            {
                if (Msg == true)
                {
                    MessageBox.Show("������ Start ���� �ʾҰų�" + ex.Message);
                    btnConncet.Text = "����";
                    chatHandler.ChatClose();
                    ntwStream.Close();
                    tcpClient.Close();
                }
            }
        }


        public void SetText(string text)
        {
            if (this.textChatMsg.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textChatMsg.AppendText(text);
            }
        }


        public class ChatHandler
        {
            private TextBox txtChatMsg;
            private NetworkStream netStream;
            private StreamReader strReader;
            private Form1 form1;

            public void ChatClose()
            {
                netStream.Close();
                strReader.Close();
            }

            public void Setup(Form1 form1, NetworkStream netStream, TextBox txtChatMsg)
            {
                this.txtChatMsg = txtChatMsg;
                this.netStream = netStream;
                this.form1 = form1;
                this.strReader = new StreamReader(this.netStream);
            }

            public void ChatProcess()
            {
                while (true)
                {
                    try
                    {
                        string lstMessage = strReader.ReadLine();

                        if (lstMessage != null && lstMessage != "")
                        {
                            form1.SetText(lstMessage + "\r\n");
                        }


                    }
                    catch (Exception ex)
                    {
                        break;

                    }




                }
            }




        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==13)
            {
                if(btnConncet.Text == "������")
                {
                    MessageSnd("<" + txtName.Text + ">" + txtMsg.Text, true);
                }

                txtMsg.Text = "";
                e.Handled = true;

            }
        }
    }
}
