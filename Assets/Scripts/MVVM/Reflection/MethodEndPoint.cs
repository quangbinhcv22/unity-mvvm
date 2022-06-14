using System;
using System.Linq;
using System.Reflection;

namespace MVVM
{
    [Serializable]
    public class MethodEndPoint
    {
        private object _owner;
        private string _methodName;

        private MethodInfo _methodInfo;

        private string MethodName
        {
            get => _methodName;
            set
            {
                _methodName = value.Split(' ').First();
                _methodInfo = _owner.GetType().GetMethod(_methodName);
            }
        }

        public MethodEndPoint(object owner, string propertyName)
        {
            _owner = owner;
            MethodName = propertyName;
        }

        public void Invoke()
        {
            _methodInfo?.Invoke(_owner, null);
        }

        public override string ToString()
        {
            return $"{_owner} ({_methodName})";
        }
    }
}