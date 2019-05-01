using System;
using System.Collections.Generic;
using System.Text;

namespace AKQA.BusinessLayer
{
    public interface IConvertNumberToWord
    {
        string GetSalaryInWords(double salary);
    }
}
