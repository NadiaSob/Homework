using System;

namespace hw2._2
{
    interface IList
    {
        int Size { get; }
        bool IsEmpty();
        bool AddElement(int position, int data);
        bool DeleteElementByPosition(int position);
        void DeleteElementByData(int data);
        int GetData(int position);
        bool SetData(int position, int data);
        void PrintList();
        bool Exists(int data);
    }
}
