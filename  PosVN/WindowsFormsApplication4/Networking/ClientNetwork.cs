using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Networking
{
    class ClientNetwork
    {
        public Socket clientSocket;
        private byte[] byteData = new byte[1024];
        public string strName{ get; set;}
        public string txtServerIP { get; set; }
        public int txtPortIP { get; set; }

        //public delegate void LoginDelegate(object o, EventArgs e);

        //public event LoginDelegate Login;
        //public Socket OnLogin(object o,EventArgs e)
        //{
        //    LoginDelegate handler = Login;
        //    if(handler!=null)
        //    {
        //        Login(this, e);
        //    }
        //    return clientSocket;
        //}
        public void Login(string Server,int port,string stringname)
        {
            strName = stringname;
            txtServerIP = Server;
            txtPortIP = port;
            if(clientSocket!=null)
                return;
            Connect();
        }
        public void LogOut()
        {

            try
            {
                //Send a message to logout of the server
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Logout;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte();
                clientSocket.Send(b, 0, b.Length, SocketFlags.None);
                clientSocket.Close();
            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex.ToString() + " Logout phia client");
            }
        }
        public void Connect()
        {
            try
            {
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                IPAddress ipAddress = IPAddress.Parse(txtServerIP);
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, txtPortIP);

                //Connect to the server
                clientSocket.BeginConnect(ipEndPoint, new AsyncCallback(OnConnect), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi "+ex.ToString()+" Connect phia client");
            }
        }
        private void OnConnect(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);
                //We are connected so we login into the server
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Login;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                byte[] b = msgToSend.ToByte();

                //Send the message to the server
                clientSocket.BeginSend(b, 0, b.Length, SocketFlags.None, new AsyncCallback(OnSend), null);
                byteData = new byte[1024];
                //Start listening to the data asynchronously
                clientSocket.BeginReceive(byteData,
                                           0,
                                           byteData.Length,
                                           SocketFlags.None,
                                           new AsyncCallback(OnReceive),
                                           byteData);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex.ToString() + " Connect phia client");
            }
            
        }
        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
                //MessageBox.Show("Onsend");
                //strName = txtName.Text;
                ////DialogResult = DialogResult.OK;
                //Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex.ToString() + " Sending phia client");
            }
        }

        public void Request(string strMess)
        {
            try
            {
                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Message;
                msgToSend.strName = strName;
                msgToSend.strMessage = strMess;

                byteData = msgToSend.ToByte();

                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                //byteData = new byte[1024];
                //Start listening to the data asynchronously
                //clientSocket.BeginReceive(byteData,
                //                           0,
                //                           byteData.Length,
                //                           SocketFlags.None,
                //                           new AsyncCallback(OnReceive),
                //                           null);
            }
            catch (Exception)
            {
                
            }
            
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                
                clientSocket.EndReceive(ar);
                byteData = (byte[])ar.AsyncState;
                Data msgReceived = new Data(byteData);
                //Accordingly process the message received
                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:
                        //lstChatters.Items.Add(msgReceived.strName);
                        break;

                    //case Command.Logout:
                    //    lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:
                        //MessageBox.Show(msgReceived.strName + " " + msgReceived.strMessage);
                        if(FrmLayout.isInstance())
                        {
                            FrmLayout.GetInstance().RefreshForm();
                        }
                        break;

                    case Command.List:
                        //lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        //lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        //txtChatBox.Text += "<<<" + strName + " has joined the room>>>\r\n";
                        break;
                }

                if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
                {
                    
                }
                    //txtChatBox.Text += msgReceived.strMessage + "\r\n";

                byteData = new byte[1024];

                clientSocket.BeginReceive(byteData,
                                          0,
                                          byteData.Length,
                                          SocketFlags.None,
                                          new AsyncCallback(OnReceive),
                                          byteData);

            }
            catch (ObjectDisposedException)
            { }
            catch (Exception ex)
            {
                Console.WriteLine("Loi " + ex.ToString() + " Receiving phia client");
            }
        }
        public void SendMess(string strMessage, Command c)
        {
            try
            {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                msgToSend.strMessage = strMessage;
                msgToSend.cmdCommand = c;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnSend), null);

                //txtMessage.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to send message to the server.", "SGSclientTCP: " + strName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
