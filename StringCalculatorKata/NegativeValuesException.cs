using System;

namespace StringCalculatorKata
{
    public class NegativeValuesException : Exception
    {
        public NegativeValuesException(string message) : base(message)
        {
        }
    }
}