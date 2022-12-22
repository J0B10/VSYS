public class MyMessageImp : IMessage
{
    string[] data = new string[]{"Message 1", "Message 2", "Message 3"};
    int idx;
    public string getMessage()
    {
        int i = idx;
        idx = (idx+1) % data.Count();
        return data[i];
    }
}