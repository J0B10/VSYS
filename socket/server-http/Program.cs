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
        System.Console.WriteLine(request);
        string[] a = request.Split(" ");
        // GET / HTTP/1.0

//        wr.WriteLine($"HTTP/1.0 200 OK\r\nContent-Type: text/plain\r\n\r\nHello World for path: {a[1]}");
        string homepage = File.ReadAllText("index.html");
        homepage = homepage.Replace("$$", DateTime.Now.ToString());
        wr.WriteLine($"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n"+homepage);
        wr.Flush();
    }
    cl.Close();

}