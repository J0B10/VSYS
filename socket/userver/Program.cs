// ================================================
// Examples from Lecture VSYS
//
//  UDP Server
// ================================================

using System.Net;
using System.Net.Sockets;
using System.Text;

IPAddress adr = IPAddress.Any;
int Port = 9000;
IPEndPoint ep = new IPEndPoint(adr, Port);
Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
s.Bind(ep);

System.Console.WriteLine("server start");

while (true) {
    EndPoint cl = new IPEndPoint(0, 0);
    byte[] data = new byte[100];

    int n = s.ReceiveFrom(data, ref cl);

    String m = Encoding.ASCII.GetString(data, 0, n);
    string info="";
    IPEndPoint? cle = cl as IPEndPoint;

    if (cle != null) {
        info = cle.Address.ToString();
    }

    System.Console.WriteLine($"UDP data = {m}, client = {info}");
}