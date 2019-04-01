namespace ionautics.io
{
    public interface IPort
    {
        string Name { get; }
        int BaudRate { get; }
        bool IsOpen();
        bool Open();
        void Close();
        Command Write(Command values);
        Command Read(Command parameter);
    }
}
