using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace ServerService
{
    enum Command
    {
        Login,      //Log into the server
        Logout,     //Logout of the server
        Message,    //Send a text message to all the chat clients
        List,       //Get a list of users in the chat room from the server
        Null,        //No command
        UpdateForm
    }
    public partial class MyServerService : ServiceBase
    {
        struct ClientInfo
        {
            public Socket socket;   //Socket of the client
            public string strName;  //Name by which the user logged into the chat room
        }

        //The collection of all clients logged into the room (an array of type ClientInfo)
        ArrayList clientList;

        //The main socket on which the server listens to the clients
        Socket serverSocket;

        byte[] byteData = new byte[1024];
        public MyServerService()
        {
            clientList = new ArrayList();
            InitializeComponent();
            if (!System.Diagnostics.EventLog.SourceExists("DoDyLogSourse"))
                System.Diagnostics.EventLog.CreateEventSource("DoDyLogSourse",
                                                                      "DoDyLog");

            eventLog1.Source = "DoDyLogSourse";
            // the event log source by which 


            //the application is registered on the computer


            eventLog1.Log = "DoDyLog";

        }
        public string getIP()
        {
            //String strHostName = Dns.GetHostName();

            //// Find host by name
            //IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            //// Grab the first IP addresses
            //String IPStr = "";
            //foreach (IPAddress ipaddress in iphostentry.AddressList)
            //{
            //    IPStr = ipaddress.ToString();
            //    return IPStr;
            //}
            //return IPStr;
            string path = "C:\\Ip.txt";
            return FileReadWrite.ReadFile(path);

        }
        protected override void OnStart(string[] args)
        {
            bool kt = true;
            while (kt)
            {

                try
                {
                    //We are using TCP sockets
                    eventLog1.Clear();
                    eventLog1.WriteEntry("On start");
                    serverSocket = new Socket(AddressFamily.InterNetwork,
                                              SocketType.Stream,
                                              ProtocolType.Tcp);

                    //Assign the any IP of the machine and listen on port number 1000
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(getIP()), 9999);
                    eventLog1.WriteEntry("ip server " + ipEndPoint.Address.ToString());
                    //Bind and listen on the given address
                    serverSocket.Bind(ipEndPoint);
                    eventLog1.WriteEntry("Server is binding");
                    serverSocket.Listen(100);
                    eventLog1.WriteEntry("Server is listening");
                    //Accept the incoming clients
                    serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
                    kt = false;
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message, " Connecting",
                    //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    eventLog1.WriteEntry(ex.Message.ToString() + " in Connecting");
                    Thread.Sleep(5000);
                }        
            }
                

        }
        private void OnAccept(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                //Start listening for more clients
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);

                //Once the client connects then start receiving the commands from her
                clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None,
                    new AsyncCallback(OnReceive), clientSocket);
            }
            catch (Exception ex)
            {
                eventLog1.WriteEntry(ex.Message.ToString() + " in Accepting");
                serverSocket.BeginAccept(new AsyncCallback(OnAccept), null);
            }
        }
        private void OnReceive(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            try
            {
                clientSocket.EndReceive(ar);
                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                Data msgReceived = new Data(byteData);

                //We will send this object in response the users request
                Data msgToSend = new Data();

                byte[] message;

                //If the message is to login, logout, or simple text message
                //then when send to others the type of the message remains the same
                msgToSend.cmdCommand = msgReceived.cmdCommand;
                msgToSend.strName = msgReceived.strName;

                switch (msgReceived.cmdCommand)
                {
                    case Command.Login:

                        //When a user logs in to the server then we add her to our
                        //list of clients

                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.socket = clientSocket;
                        clientInfo.strName = msgReceived.strName;

                        clientList.Add(clientInfo);

                        //Set the text of the message that we will broadcast to all users
                        msgReceived.strName = clientSocket.Handle.ToString();
                        msgToSend.strMessage = "<<<" + msgReceived.strName + " has joined the room>>>";
                        eventLog1.WriteEntry(msgToSend.strMessage);
                        break;

                    case Command.Logout:

                        //When a user wants to log out of the server then we search for her 
                        //in the list of clients and close the corresponding connection

                        int nIndex = 0;
                        foreach (ClientInfo client in clientList)
                        {
                            if (client.socket.Equals(clientSocket))
                            {
                                clientList.RemoveAt(nIndex);
                                break;
                            }
                            ++nIndex;
                        }

                        clientSocket.Close();

                        msgToSend.strMessage = "<<<" + msgReceived.strName + " has left the room>>>";
                        eventLog1.WriteEntry(msgToSend.strMessage);
                        break;

                    case Command.Message:

                        //Set the text of the message that we will broadcast to all users
                        msgToSend.strMessage = msgReceived.strName + ": " + msgReceived.strMessage;
                        break;

                    case Command.List:

                        //Send the names of all users in the chat room to the new user
                        msgToSend.cmdCommand = Command.List;
                        msgToSend.strName = null;
                        msgToSend.strMessage = null;

                        //Collect the names of the user in the chat room
                        foreach (ClientInfo client in clientList)
                        {
                            //To keep things simple we use asterisk as the marker to separate the user names
                            msgToSend.strMessage += client.strName + "*";
                        }

                        message = msgToSend.ToByte();

                        //Send the name of the users in the chat room
                        clientSocket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                new AsyncCallback(OnSend), clientSocket);
                        break;
                }

                if (msgToSend.cmdCommand != Command.List)   //List messages are not broadcasted
                {
                    message = msgToSend.ToByte();
                    int i = 0;
                    foreach (ClientInfo clientInfo in clientList)
                    {
                        try
                        {
                            if (clientInfo.socket != clientSocket &&
                            msgToSend.cmdCommand == Command.Message)
                            {
                                //Send the message to all users
                                clientInfo.socket.BeginSend(message, 0, message.Length, SocketFlags.None,
                                    new AsyncCallback(OnSend), clientInfo.socket);
                            }
                        }
                        catch (Exception ex)
                        {
                            eventLog1.WriteEntry("client error 1111   "   +  ex);
                            clientInfo.socket.Close();
                            clientList.RemoveAt(i);
                        }
                        

                        i++;
                    }
                    //setText(msgToSend.strMessage);
                    //if(txtLog.InvokeRequired)
                    //    txtLog.Invoke(new )
                    //txtLog.Text += msgToSend.strMessage + "\r\n";
                }

                //If the user is logging out then we need not listen from her
                if (msgReceived.cmdCommand != Command.Logout)
                {
                    try
                    {
                        //Start listening to the message send by the user
                        clientSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(OnReceive), clientSocket);
                    }
                    catch (Exception ex)
                    {
                        clientSocket.Close();

                        eventLog1.WriteEntry(" error recive  !   "  + ex.ToString());
                    }
                    
                }
            }
            catch (Exception ex)
            {
                //clientList.Clear();
                //MessageBox.Show(ex.Message, "SGSserverTCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //int i = 0;
                for (int j = 0; j < clientList.Count; j++)
                {
                    ClientInfo a = (ClientInfo)clientList[j];
                    if (a.socket.Equals(clientSocket))
                    {
                        clientList.RemoveAt(j);
                    }
                }
                //foreach (ClientInfo clientInfo in clientList)
                //{
                //    if(clientInfo.socket == clientSocket)
                //    {
                //        //clientSocket.Close();
                //        clientList.RemoveAt(i);
                //    }
                //    i++;
                //}
                eventLog1.WriteEntry("client error    " + ex.ToString());
            }
        }
        public void OnSend(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;
                client.EndSend(ar);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "SGSserverTCP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                eventLog1.WriteEntry("error On Send : " + ex);
            }
        }
        protected override void OnStop()
        {
            foreach (ClientInfo clientInfo in clientList)
            {
                if(clientInfo.socket.Connected)
                {
                    clientInfo.socket.Close();
                }
            }
            clientList.Clear();
            if(serverSocket.Connected)
                serverSocket.Close();
        }
    }
    class Data
    {
        //Default constructor
        public Data()
        {
            this.cmdCommand = Command.Null;
            this.strMessage = null;
            this.strName = null;
        }

        //Converts the bytes into an object of type Data
        public Data(byte[] data)
        {
            //The first four bytes are for the Command
            this.cmdCommand = (Command)BitConverter.ToInt32(data, 0);

            //The next four store the length of the name
            int nameLen = BitConverter.ToInt32(data, 4);

            //The next four store the length of the message
            int msgLen = BitConverter.ToInt32(data, 8);

            //This check makes sure that strName has been passed in the array of bytes
            if (nameLen > 0)
                this.strName = Encoding.UTF8.GetString(data, 12, nameLen);
            else
                this.strName = null;

            //This checks for a null message field
            if (msgLen > 0)
                this.strMessage = Encoding.UTF8.GetString(data, 12 + nameLen, msgLen);
            else
                this.strMessage = null;
        }

        //Converts the Data structure into an array of bytes
        public byte[] ToByte()
        {
            List<byte> result = new List<byte>();

            //First four are for the Command
            result.AddRange(BitConverter.GetBytes((int)cmdCommand));

            //Add the length of the name
            if (strName != null)
                result.AddRange(BitConverter.GetBytes(strName.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Length of the message
            if (strMessage != null)
                result.AddRange(BitConverter.GetBytes(strMessage.Length));
            else
                result.AddRange(BitConverter.GetBytes(0));

            //Add the name
            if (strName != null)
                result.AddRange(Encoding.UTF8.GetBytes(strName));

            //And, lastly we add the message text to our array of bytes
            if (strMessage != null)
                result.AddRange(Encoding.UTF8.GetBytes(strMessage));

            return result.ToArray();
        }

        public string strName;      //Name by which the client logs into the room
        public string strMessage;   //Message text
        public Command cmdCommand;  //Command type (login, logout, send message, etcetera)
    } 
}
