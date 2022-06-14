using System;
using System.Linq;
using System.Reflection;

namespace MVVM
{
    [Serializable]
    public class PropertyEndPoint
    {
        private object _owner;
        private string _propertyName;

        
        private PropertyInfo _property;

        private PropertyInfo Property
        {
            get { return _property ??= _owner.GetType().GetProperty(_propertyName); }
        }


        private string PropertyName
        {
            get => _propertyName;
            set => _propertyName = value.Split(' ').First();
        }

        public PropertyEndPoint(object owner, string propertyName)
        {
            _owner = owner;
            PropertyName = propertyName;
        }

        public Type PropertyType => Property?.PropertyType;

        public object GetValue()
        {
            return Property?.GetValue(_owner);
        }

        public void SetValue(object value)
        {
            Property?.SetValue(_owner, value);
        }

        public override string ToString()
        {
            return $"{_owner} ({Property}): {GetValue()}";
        }
    }
}