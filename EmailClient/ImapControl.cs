using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public class ImapControl
    {
        int port;

        TcpClient tcpClient = null;
        SslStream ssl = null;

        StreamReader sr;
        StreamWriter sw;

        int bytes = -1;
        byte[] buffer;
        StringBuilder sb;
        byte[] dummy;

        public ImapControl(int port)
        {
            this.port = port;
        }

        public bool Connect(LoginInfo user)
        {
            try
            {
                Console.WriteLine("Connecting...");
                tcpClient = new TcpClient(user.ImapAddress, port);
                ssl = new SslStream(tcpClient.GetStream());
                ssl.AuthenticateAsClient(user.ImapAddress);

                sr = new StreamReader(tcpClient.GetStream());
                sw = new StreamWriter(tcpClient.GetStream());

                receiveResponse("");
                receiveResponse("$ LOGIN " + user.Username + " " + user.Password + "  \r\n");

                if (tcpClient.Connected)
                return true;
            else
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            };
        }


        public void receiveResponse(string command)
        { 
            sb = new StringBuilder();
            try
            {
                if (command != "")
                {
                    if (tcpClient.Connected)
                    {
                        dummy = Encoding.ASCII.GetBytes(command);
                        ssl.Write(dummy, 0, dummy.Length);
                        //sw.Write(command);
                    }
                    else
                    {
                        throw new ApplicationException("TCP CONNECTION DISCONNECTED");
                    }
                }
                ssl.Flush();


                buffer = new byte[2048];
                bytes = ssl.Read(buffer, 0, 2048);
                sb.Append(Encoding.ASCII.GetString(buffer));


                Console.WriteLine(sb.ToString());
                //sw.WriteLine(sb.ToString());

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

    }
}
