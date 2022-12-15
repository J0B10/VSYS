class MyLocalTime : ITime
{
    public string time()
    {
        return DateTime.Now.ToString();
    }
}