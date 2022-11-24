// ================================================
// Examples from Lecture VSYS
//
//  TCP Server, multithreaded
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

    ThreadPool.SetMaxThreads(5, 5);
    ThreadPool.SetMinThreads(5, 5);
    ThreadPool.QueueUserWorkItem(o=>{
        using (NetworkStream ns = new(cl))
        using (StreamReader rd = new(ns))
        using (StreamWriter wr = new(ns))
        {
            String request = rd.ReadLine()??"";
            Thread.Sleep(1000);
            wr.WriteLine(DateTime.Now.ToString());
            wr.Flush();
        }
        cl.Close();

    });

}