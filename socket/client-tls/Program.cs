// ================================================
// Examples from Lecture VSYS
//
//  TCP Client
// ================================================

using System.Net.Security;
using System.Net.Sockets;

string adr = "localhost";
int Port = 9000;

Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
s.Connect(adr, Port);
using (NetworkStream ns = new(s)) 
using (SslStream ssl = new(ns)) {
    ssl.AuthenticateAsClient(adr);
    using (StreamReader rd = new(ssl))
    using (StreamWriter wr = new(ssl))
    {
        wr.WriteLine("time"); wr.Flush(); ssl.Flush();
        string time = rd.ReadLine()??"ERROR";
        System.Console.WriteLine("Server time = "+time);
    }
}
s.Close();
