using Practice.WPF.Statistics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice.WPF.Statistics.Commands
{
    public class AddToListCommand : CommandBase
    {
        private readonly GroupDataViewModel _groupDataViewModel;

        public AddToListCommand(GroupDataViewModel groupDataViewModel)
        {
            _groupDataViewModel = groupDataViewModel;
        }

        public override bool CanExecute(object? parameter)
        {
            return _groupDataViewModel.NValue >0 &&
                !_groupDataViewModel.XValues.Contains(_groupDataViewModel.XValue);

        }
        public override void Execute(object? parameter)
        {
            AddToList();
        }

        private void AddToList()
        {
            if (_groupDataViewModel == null) return;

            _groupDataViewModel.XValues.Add(_groupDataViewModel.XValue);
            _groupDataViewModel.NValues.Add(_groupDataViewModel.NValue);
            _groupDataViewModel.NValue = 0;
        }
    }
}
