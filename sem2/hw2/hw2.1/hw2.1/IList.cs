using System;

namespace hw2._1
{
    interface IList
    {
        int Size { get; }
        bool IsEmpty();
        bool AddElement(int position, int data);
        bool DeleteElement(int position);
        int GetData(int position);
        bool SetData(int position, int data);
        void PrintList();
    }
}
