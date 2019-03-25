using System;
namespace ionautics.io
{
    public interface IPort
    {
        bool IsOpen();
        bool Open();
        void Close();
        Command Write(Command values);
        Command Read(Command parameter);
    }
}
