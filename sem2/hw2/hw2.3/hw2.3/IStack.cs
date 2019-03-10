using System;

namespace hw2._3
{
    interface IStack
    {
        bool IsEmpty();
        void Push(int data);
        int Pop();
    }
}
