using ionautics.io;

namespace ionautics
{
    interface IRunningControl {

        void permittEditing();
        void preventEditing();
        Unit getUnit();
    }
}