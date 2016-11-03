using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using AgCubio;

namespace AgCubio
{
    public static class Network
    {
        private const int port = 11000;
        private static System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        //private Socket client;

        public static Socket Connect_to_Server(Action<PreservedState> callback, string hostname)
        {
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress;
            try
            {
                IPHostEntry hostEntry = Dns.GetHostEntry(hostname);
                iPAddress = hostEntry.AddressList[0];

                IPEndPoint remoteEP = new IPEndPoint(iPAddress, 11000);

                Socket socket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                PreservedState state = new PreservedState(callback);
                state.socket = socket;
                socket.BeginConnect(remoteEP, new AsyncCallback(Connected_to_Server), state);

                client = socket;
            }
            catch (Exception e)
            {
                client = null;
                Console.WriteLine(e);
            }
            return client;
        }

        public static void Connected_to_Server(IAsyncResult state_in_an_ar_object)
        {
            PreservedState state = (PreservedState)state_in_an_ar_object.AsyncState;
            // Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);

            try
            {
                state.socket.EndConnect(state_in_an_ar_object);
                state.callback(state);
                state.socket.BeginReceive(state.buffer, 0, 1024, SocketFlags.None, new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                state.callback(state);
                Console.WriteLine(e);
            }

        }

        public static void ReceiveCallback(IAsyncResult state_in_an_ar_object)
        {
            ///////////////////////////////
            PreservedState state = (PreservedState)state_in_an_ar_object.AsyncState;
            Socket socket = state.socket;
            int count = socket.EndReceive(state_in_an_ar_object);
            try
            {
                if (count > 0)
                {
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, count));
                    state.callback(state);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void i_want_more_data(PreservedState state)
        {

            state.socket.BeginReceive(state.buffer, 0, 1024,
                                SocketFlags.None, new AsyncCallback(ReceiveCallback), state);

        }

        public static bool Send(Socket socket, String data)
        {
            try
            {
                byte[] bts = Encoding.UTF8.GetBytes(data);
                socket.BeginSend(bts, 0, bts.Length, SocketFlags.None, new AsyncCallback(SendCallBack), socket);

                return true;
            }
            catch (Exception)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();

                return false;
            }
        }

        public static void SendCallBack(IAsyncResult state_in_an_ar_object)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)state_in_an_ar_object.AsyncState;
                client.EndSend(state_in_an_ar_object);

                // Complete sending the data to the remote device.
                //int bytesSent = client.EndSend(state_in_an_ar_object);

                //Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}