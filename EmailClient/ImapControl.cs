using MimeKit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
                
                //sr = new StreamReader(tcpClient.GetStream());
                //sw = new StreamWriter(tcpClient.GetStream());

                ReceiveResponse("");
                string login = ReceiveResponse("$ LOGIN " + user.Username + " " + user.Password + "  \r\n");
                //ReceiveResponse("");

                if (!login.ToLower().Contains("ok"))
                {
                    return false;
                }
                //string folders = ReceiveResponse("$ LIST " + "\"\"" + "\"*\"" + "\r\n");


                //ReceiveResponse("$ SELECT Inbox" + "\r\n");
                //ReceiveResponse("$ STATUS Inbox (MESSAGES)\r\n");

                //ReceiveResponse("$ FETCH " + 2 + " body[header]\r\n");
                //ReceiveResponse("$ FETCH " + 7 + " body[text]\r\n");

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

        public void CreateNewFloder(string folderName)
        {
            ReceiveResponse(@"$ CREATE " + folderName + "\r\n");
        }

        public void DeleteFolder(string folderName)   //WARNING dangerous method. Use with caution.
        {
            ReceiveResponse(@"$ DELETE " + folderName + "\r\n");
        }

        public List<string> GetFolderList()
        {

            List<string> foldersList = new List<string>();
            string folders = ReceiveResponse("$ LIST " + "\"\"" + " \"*\"" + "\r\n");
            string[] lines = folders.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string pattern = @"\""([\[\]\w-\/ ]){2,}\""";
            Regex regex = new Regex(pattern);

            foreach (var line in lines)
            {
                if (!line.Contains("\\HasChildren"))
                {
                    var match = regex.Match(line);
                    if (match.Value != string.Empty)
                        foldersList.Add(match.Value.Replace(@"""", ""));
                }
            }
            return foldersList;
        }

        public List<EmailTemplate> SelectFolder(string folderName)
        {
            string uids = ReceiveResponse("$ UID SEARCH ALL" + "\r\n");
            Regex regex = new Regex(@"(SEARCH )((\d*) )*(\d*)");
            uids = regex.Match(uids).Value;
            string[] lines = uids.Split(' ');
            Regex regexNum = new Regex(@"\d+");

            List<EmailTemplate> emailList = new List<EmailTemplate>();
            foreach (var line in lines)
            {
                var match = regexNum.Match(line);
                if (match.Value != "")
                {
                    string text = ReceiveResponse("$ UID FETCH " + match.Value + " BODY[HEADER.FIELDS (from to subject)]" + "\r\n");
                    EmailTemplate email = GetEmailTemplate(text);
                    email.Uid = match.Value;
                    email.Mailbox = folderName;
                    emailList.Add(email);
                    //var message = MimeMessage.Load(new MemoryStream(Encoding.ASCII.GetBytes(text)));
                }
            }
            try
            {
                emailList = (from e in emailList
                             orderby int.Parse(e.Uid)
                             descending
                             select e).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return emailList;

        }

        private EmailTemplate GetEmailTemplate(string text)
        {
            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            //Console.WriteLine(text);
            EmailTemplate email = new EmailTemplate();
            foreach (var line in lines)
            {
                if (line.StartsWith("From"))
                {
                    email.From = line.Replace("From: ", string.Empty);
                }
                if (line.StartsWith("To"))
                {
                    email.To = line.Replace("To: ", string.Empty);
                }
                if (line.StartsWith("Subject"))
                {
                    email.Subject = line.Replace("Subject: ", string.Empty);
                }
            }
            //email.From = 


            return email;
        }

        public string GetEmailBody(string uid)
        {
            string text = ReceiveResponse("$ UID FETCH " + uid + " BODY[TEXT]" + "\r\n");
            var x = text.IndexOf("quoted-printable") + "quoted-printable".Length;
            text.Replace("\0", "");
            text = text.Substring(x);

            var txt = DecodeQuotedPrintable(text, "utf-8");


            return txt;
        }


        //public void 


        public string GetMailCount(string folderName)
        {
            string selectInfo = ReceiveResponse("$ SELECT " + folderName + "\r\n");

            string pattern = @"\d+( EXISTS){1}";
            Regex regex = new Regex(pattern);
            var match = regex.Match(selectInfo);
            return match.Value.Replace("MESSAGES ", string.Empty).Replace(" EXISTS", string.Empty);
        }

        public void Logout()
        {
            ReceiveResponse("$ LOGOUT" + "\r\n");
        }

        public void DeleteMessage(EmailTemplate email)
        {
            ReceiveResponse("$ UID STORE " + email.Uid + @" +FLAGS Deleted" + "\r\n");
            ReceiveResponse("$ EXPUNGE" + "\r\n");

        }


        private string ReceiveResponse(string command)
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
                    }
                    else
                    {
                        throw new ApplicationException("TCP CONNECTION DISCONNECTED");
                    }
                }
                ssl.Flush();

                buffer = new byte[2048];
                tcpClient.ReceiveTimeout = 20000;

                Encoding iso = Encoding.GetEncoding("ISO-8859-1");

                do
                {
                    try
                    {
                        bytes = ssl.Read(buffer, 0, 2048);

                        //byte[] converted = Encoding.Convert(Encoding.GetEncoding("iso-8859-1"),
                        //Encoding.UTF8, buffer);
                        //Encoding.
                        
                        var msg = Encoding.UTF8.GetString(buffer);
                        
                        sb.Append(msg);
                        Thread.Sleep(3);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                } while (tcpClient.Available > 0);

                string text = sb.ToString().Replace("\0", string.Empty);
                //Console.WriteLine(text);

                return sb.ToString();
                //sw.WriteLine(sb.ToString());

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }


        private static string DecodeQuotedPrintable(string input, string bodycharset)
        {
            var i = 0;
            var output = new List<byte>();
            while (i < input.Length)
            {
                if (input[i] == '=' && input[i + 1] == '\r' && input[i + 2] == '\n')
                {
                    //Skip
                    i += 3;
                }
                else if (input[i] == '=')
                {
                    string sHex = input;
                    sHex = sHex.Substring(i + 1, 2);
                    try
                    {
                        int hex = Convert.ToInt32(sHex, 16);
                        byte b = Convert.ToByte(hex);
                        output.Add(b);
                        
                    } catch(Exception e)
                    {

                    }
                    i += 3;
                }
                else
                {
                    output.Add((byte)input[i]);
                    i++;
                }
            }


            if (String.IsNullOrEmpty(bodycharset))
                return Encoding.UTF8.GetString(output.ToArray());
            else
            {
                if (String.Compare(bodycharset, "ISO-2022-JP", true) == 0)
                    return Encoding.GetEncoding("Shift_JIS").GetString(output.ToArray());
                else
                    return Encoding.GetEncoding(bodycharset).GetString(output.ToArray());
            }

        }


    }
}
