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
string postdata = "";

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

        switch (a[0]) {
            case "GET":
                string homepage = File.ReadAllText("index.html");
                homepage = homepage.Replace("$$", postdata);
                wr.WriteLine($"HTTP/1.0 200 OK\r\nContent-Type: text/html\r\n\r\n"+homepage);
                break;
            case "POST":
                string? b;
                do b = rd.ReadLine(); while (!String.IsNullOrEmpty(b));
                char[] body = new char[200];
                int n = rd.Read(body, 0, 200);
                string data = new String(body);
                System.Console.WriteLine(data);
                postdata = data.Split("=")[1];
                wr.WriteLine($"HTTP/1.0 302 Found\r\nLocation: /\r\n\r\nOK");
                break;
        }
        wr.Flush();
    }
    cl.Close();

}