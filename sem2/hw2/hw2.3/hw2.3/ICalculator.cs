using System;

namespace hw2._3
{
    interface ICalculator
    {
        string Expression { get; set; }
        int Calculation(IStack stack);
    }
}
