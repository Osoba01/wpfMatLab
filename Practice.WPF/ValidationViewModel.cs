using Practice.WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.WPF
{
    public class ValidationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        private readonly Dictionary<string, List<string>> _propertyErrors = new();

        public IEnumerable GetErrors(string? propertyName)
        {
            return propertyName is not null && _propertyErrors.ContainsKey(propertyName)
                 ? _propertyErrors[propertyName]
                 : Enumerable.Empty<string>();
        }

        protected void AddError(string propertyName, string error)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors[propertyName] = new List<string>();
            }
            if (!_propertyErrors[propertyName].Contains(error))
            {
                _propertyErrors[propertyName].Add(error);
            }
            OnErrorChange(propertyName);
        }

        protected void ClearErrors(string propertyName)
        {
            if (_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Remove(propertyName);
            }
        }

        public void OnErrorChange(string PropertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(PropertyName));
        }
    }
}
