using System;

namespace MVVM
{
    [Serializable]
    public class PropertySync
    {
        private PropertyEndPoint _source;
        private PropertyEndPoint _dest;

        private ValueConverterBase _toSourceConverter;
        private ValueConverterBase _toDestConverter;

        public PropertySync(PropertyEndPoint source, PropertyEndPoint dest, ValueConverterBase toSourceConverter = null,
            ValueConverterBase toDestConverter = null)
        {
            _source = source;
            _dest = dest;

            _toSourceConverter = toSourceConverter;
            _toDestConverter = toDestConverter;
        }

        public void SyncFromSource()
        {
            if (_toDestConverter != null)
            {
                var sourceValue = _toDestConverter.Convert(_source.GetValue());
                _dest.SetValue(Convert.ChangeType(sourceValue, _dest.PropertyType));
            }
            else
            {
                _dest.SetValue(_source.GetValue());
            }
        }

        public void SyncFromDest()
        {
            if (_toSourceConverter != null)
            {
                var destValue = _toSourceConverter.Convert(_dest.GetValue());
                _source.SetValue(Convert.ChangeType(destValue, _source.PropertyType));
            }
            else
            {
                _source.SetValue(_dest.GetValue());
            }
        }
    }
}