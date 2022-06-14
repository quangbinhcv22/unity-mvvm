using System;
using MVVM;

public class StringToIntConverter : ValueConverterBase
{
    public override object Convert(object value)
    {
        return Int32.Parse(value.ToString());
    }
}