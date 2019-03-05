using System;

namespace hw2._2
{
    interface IHashTable
    {
        int NumberOfElements { get; }
        bool Exists(int data);
        bool Add(int data);
        bool Delete(int data);
        void Print();
    }
}
