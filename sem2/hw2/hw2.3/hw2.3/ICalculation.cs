using System;

namespace hw2._3
{
    interface ICalculation
    {
        string Expression { get; set; }
        int CalculationProcess();
    }
}
