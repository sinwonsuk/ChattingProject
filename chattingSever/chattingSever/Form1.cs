using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace chattingSever
{
    delegate void SetTextDelegate(string s);

    public partial class txtChatMsg : Form
    {

        public txtChatMsg()
        {
            InitializeComponent();
        }

        TcpListener chatSever = new TcpListener(IPAddress.Parse("127.0.0.1"), 8888);

        public static ArrayList clientSocketArray = new ArrayList();

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMsg.Tag.ToString() == "Stop")
                {
                    chatSever.Start();

                    Thread thread = new Thread(new ThreadStart(AcceptClient));
                    thread.Start();



                    lblMsg.Text = "Sever 시작됨";
                    lblMsg.Tag = "Start";
                    btnStart.Text = "서버종료";

                }
                else
                {
                    chatSever.Stop();
                    foreach (Socket socket in txtChatMsg.clientSocketArray)
                    {
                        socket.Close();
                    }

                    clientSocketArray.Clear();

                    lblMsg.Text = "Sever 중지됨";
                    lblMsg.Tag = "Stop";
                    btnStart.Text = "서버 시작";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버 시작 오류" + ex.Message);
            }
        }

        void AcceptClient()
        {

            Socket socketClient = null;

            while (true)
            {
                try
                {
                    socketClient = chatSever.AcceptSocket();
                    ClientHandler clientHandler = new ClientHandler();
                    clientHandler.ClientHandler_Setup(this, socketClient, this.textBox1);
                    Thread thd_ChatProcess = new Thread(clientHandler.Chat_Process);
                    thd_ChatProcess.Start();

                }
                catch (Exception ex)
                {
                    txtChatMsg.clientSocketArray.Remove(socketClient);
                    break;
                }
               
                                     
            }
        }
        public void SetText(string text)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextDelegate d = new SetTextDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.AppendText(text);
            }
        }

        private void txtChatMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            chatSever.Stop();
        }
    }

    public class ClientHandler
    {
        private TextBox chat;
        private Socket socketClient;
        private NetworkStream netStream;
        private StreamReader strReader;
        private txtChatMsg form1;

        public void ClientHandler_Setup(txtChatMsg form1,Socket socketClient, TextBox chat)
        {
            this.chat = chat;
            this.socketClient = socketClient;
            this.netStream = new NetworkStream(socketClient);
            txtChatMsg.clientSocketArray.Add(socketClient);
            this.strReader = new StreamReader(netStream);
            this.form1 = form1;
        }

  

        public void Chat_Process()
        {
            while (true)
            {
                try
                {
                    string msg = strReader.ReadLine();

                    if (msg != null && msg!="")
                    {
                        form1.SetText(msg+"\r\n");
                        byte[] bytSand_Date = Encoding.Default.GetBytes(msg+ "\r\n");

                        lock (txtChatMsg.clientSocketArray)
                        {
                            foreach (Socket socket in txtChatMsg.clientSocketArray)
                            {
                                NetworkStream stream = new NetworkStream(socket);
                                stream.Write(bytSand_Date,0, bytSand_Date.Length);
                            }
                        }

                    }

                }
                catch(Exception e) 
                {
                    txtChatMsg.clientSocketArray.Remove(socketClient);
                    break;
                }           
            }
        }

     
    }

}
