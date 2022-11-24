// ================================================
// Examples from Lecture VSYS
//
//  TCP Server
// ================================================

using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

X509Certificate crt = new X509Certificate(@"server.pfx", "");

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
    using (SslStream ssl = new(ns)) {
        ssl.AuthenticateAsServer(crt);
        using (StreamReader rd = new(ssl))
        using (StreamWriter wr = new(ssl))
        {
            String request = rd.ReadLine()??"";
            System.Console.WriteLine($"client request = {request}");
            wr.WriteLine(DateTime.Now.ToString());
            wr.Flush();
            ssl.Flush();
            ns.Flush();
        }
    }
    System.Console.WriteLine("time sent");
    cl.Close();

}