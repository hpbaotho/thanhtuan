using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace WindowsFormsApplication4.Networking
{
    public class BTcpClient
    {
        public delegate void DisplayResultDelegate(DataGridView gridview, int index);

        ManualResetEvent allDone = new ManualResetEvent(false);
        DataPackage m_data = null;
        int m_pID = int.MinValue;
        DataGridView display_gridview;
        int row_index;
        private Handlers.UpdateFormHandler updateForm;
        public string ServerIpAddress { get; set; }
        public int ServerPort { get; set; }

        /// <summary>
        /// Display the result (pID) on the cell of the gridview
        /// </summary>
        /// <param name="gridview"></param>
        /// <param name="index"></param>
        //public void DisplayResult(DataGridView gridview, int index)
        //{
        //    if (gridview.InvokeRequired)
        //        gridview.Invoke(new DisplayResultDelegate(DisplayResult), gridview, index);
        //    else
        //    {
        //        gridview.Rows[index].Cells[7].Value = m_pID.ToString();
        //    }       
        //}

        //init m_data
        //public void init_data(int uID, double x, double y, DateTime time, int tolerant_time, double radius, byte k, DataGridView gridview,int row_index)
        //{
        //    #region fill m_data with just received paramaters
        //    //m_data = new DataPackage();
        //    //m_data.uID = uID;
        //    //m_data.x = x;
        //    //m_data.y = y;
        //    //m_data.time = time.Ticks;
        //    //m_data.tolerant_time = tolerant_time;
        //    //m_data.radius = radius;
        //    m_data.k = k;
        //    //display_gridview = gridview;
        //    //this.row_index = row_index; 
        //    #endregion
        //}

        ///
        /// Starts the client and attempts to send an object to the server
        ///
        public void get_pID()
        {
            allDone.Reset();    
            Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.BeginConnect(new IPEndPoint(IPAddress.Parse(ServerIpAddress), ServerPort), Connect, sender);
            
            allDone.WaitOne(); //halts this thread until the connection is accepted
            //DisplayResult(this.display_gridview, this.row_index);
        }

        ///
        /// Starts when the connection was accepted by the remote hosts and prepares to send data
        ///
        public void Connect(IAsyncResult result)
        {
            if (m_data != null)
            {
                try
                {
                    m_data.Socket = (Socket)result.AsyncState;
                    m_data.Socket.EndConnect(result);
                    byte[] buffer = m_data.Serialize(); //fills the buffer with data
                    m_data.Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, Send, m_data);
                }
                catch (Exception ex) { throw ex; }
            }
        }

        ///
        /// Ends sending the data, waits for a readline until the thread quits
        ///
        public void Send(IAsyncResult result)
        {
            try
            {
                DataPackage data = (DataPackage)result.AsyncState;
                int size = data.Socket.EndSend(result);


                data.Socket.BeginReceive(data.buffer, 0, data.buffer.Length, SocketFlags.None, Receive, data);

                //Console.Out.WriteLine("Send data: " + size + " bytes.");
                //Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Error in Sending");
            }
        }

        ///
        /// Receives the data, puts it in a buffer and checks if we need to receive again.
        ///
        public void Receive(IAsyncResult result)
        {
            try
            {
                DataPackage data = (DataPackage)result.AsyncState;
                int read = data.Socket.EndReceive(result);
                if (read > 0)
                {
                    for (int i = 0; i < read; i++)
                    {
                        data.TransmissionBuffer.Add(data.buffer[i]);
                    }
                    Done(data,result);
                    //we need to read again if this is true
                    //if (read == data.buffer.Length)
                    //{
                    //    data.Socket.BeginReceive(data.buffer, 0, data.buffer.Length, SocketFlags.None, Receive, data);
                    //}
                    //else
                    //{
                    //    Done(data, result);
                    //}
                }
                else
                {
                    Done(data, result);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        ///
        /// Deserializes and outputs the received object
        ///
        public void Done(DataPackage data, IAsyncResult result)
        {
            DataPackage send = data.DeSerialize();
            //int pID = BitConverter.ToInt32(send.buffer, 0);
            byte t = send.content;
            Console.WriteLine(t.ToString());

            updateForm = Handlers.UpdateFormHandler.GetInstance();

            updateForm.Process(t);
            allDone.Set(); //signals thread to continue so it sends another message
        }

        public void request_server(object _client)
        {
            BTcpClient client = (BTcpClient) _client;
            client.get_pID();
            //get_pID();
        }

        public void init_data(byte i)
        {
            m_data = new DataPackage();
            m_data.header = i;
        }
    }
}
