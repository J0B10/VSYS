// ================================================
// Examples from Lecture VSYS
//
//  TCP Server
// ================================================

using System.Net;
using System.Net.Sockets;

IPAddress adr = IPAddress.Any;
int Port = 9000;
IPEndPoint ep = new IPEndPoint(adr, Port);
Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
s.Bind(ep);

System.Console.WriteLine("server start");
s.Listen(20);

while (true) {
    Socket cl = s.Accept();
    System.Console.WriteLine($"New client from {cl.RemoteEndPoint?.ToString()}");
    using (NetworkStream ns = new(cl))
    using (StreamReader rd = new(ns))
    using (StreamWriter wr = new(ns))
    {
        String request = rd.ReadLine()??"";
        System.Console.WriteLine($"client request = {request}");
        wr.WriteLine(DateTime.Now.ToString());
        wr.Flush();
    }
    System.Console.WriteLine("time sent");
    cl.Close();

}