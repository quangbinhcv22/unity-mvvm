using UnityEngine;

namespace MVVM
{
    public abstract class ValueConverterBase : MonoBehaviour, IValueConverter
    {
        public abstract object Convert(object value);
    }
}