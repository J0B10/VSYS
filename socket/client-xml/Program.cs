// ================================================
// Examples from Lecture VSYS
//
//  TCP Client
// ================================================

using System.Net.Sockets;
using System.Xml.Serialization;

string adr = "127.0.0.1";
int Port = 9000;

Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
s.Connect(adr, Port);
using (NetworkStream ns = new(s))
using (StreamReader rd = new(ns))
using (StreamWriter wr = new(ns))
{
    wr.WriteLine("time"); wr.Flush();
    // string time = rd.ReadLine()??"ERROR";
    // System.Console.WriteLine("Server time = "+time);
    XmlSerializer ser = new(typeof(Info));
    Info? inf = ser.Deserialize(rd) as Info;
    if (inf != null) {
        System.Console.WriteLine($"{inf.Server}: {inf.Time}");
    }
}
s.Close();
