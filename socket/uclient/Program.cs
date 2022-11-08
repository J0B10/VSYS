// ================================================
// Examples from Lecture VSYS
//
//  UDP Client, using broadcast
// ================================================

using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress adr = IPAddress.Parse("192.168.2.255");
int Port = 9000;
IPEndPoint ep = new IPEndPoint(adr, Port);

Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
s.EnableBroadcast = true;

byte[] data = Encoding.ASCII.GetBytes("Hallo UDP");
s.SendTo(data, ep);
