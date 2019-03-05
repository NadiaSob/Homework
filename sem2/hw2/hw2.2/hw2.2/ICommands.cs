using System;

namespace hw2._2
{
    interface ICommands
    {
        void PrintCommands();
        void CommandExecution(HashTable hashTable, int command);
    }
}
