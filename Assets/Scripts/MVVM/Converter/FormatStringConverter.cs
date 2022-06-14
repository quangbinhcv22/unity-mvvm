using UnityEngine;

namespace MVVM
{
    public class FormatStringConverter : ValueConverterBase
    {
        [SerializeField, TextArea] private string format = "{0}";


        public override object Convert(object value)
        {
            return string.Format(format, value);
        }
    }
}