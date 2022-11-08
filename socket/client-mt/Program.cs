// ================================================
// Examples from Lecture VSYS
//
//  TCP Client, multithreaded (n concurent clients)
// ================================================

using System.Net.Sockets;

string adr = "127.0.0.1";
int Port = 9000;
int NumClients = 10;

DateTime start;
DateTime end;

List<Thread> tl = new();

start = DateTime.Now;
for (int i = 0; i < NumClients; i++)
{
    Thread t = new Thread(()=>{
        Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        s.Connect(adr, Port);
        using (NetworkStream ns = new(s))
        using (StreamWriter wr = new(ns))
        using (StreamReader rd = new(ns))
        {
            wr.WriteLine("time"); wr.Flush();
            string time = rd.ReadLine()??"ERROR";
            System.Console.WriteLine("Time = "+time);
        }
        s.Close();

    });
    tl.Add(t);
    t.Start();
   
}

tl.ForEach(t=>t.Join());
end = DateTime.Now;
System.Console.WriteLine((end-start).ToString());