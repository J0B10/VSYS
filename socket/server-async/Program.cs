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

    Task.Run(async ()=>{
        using (NetworkStream ns = new(cl))
        using (StreamReader rd = new(ns))
        using (StreamWriter wr = new(ns))
        {
            String request = rd.ReadLine()??"";
            // Thread.Sleep(1000);
            await Task.Delay(1000);
            await wr.WriteLineAsync(DateTime.Now.ToString());
            await wr.FlushAsync();
        }
        cl.Close();

    });

}