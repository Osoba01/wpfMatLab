using Practice.WPF.Statistics.Commands;
using Practice.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.WPF.Statistics.ViewModels
{
    public class GroupDataViewModel: ValidationViewModel
    {

        public GroupDataViewModel()
        {
            nvalues = new();
            xValues=new();
            AddToListCommand = new(this);
            SolveGroupDataCommand=new(this);


        }
        private double xValue;

        public double XValue
        {
            get { return xValue; }
            set {
                xValue = value;
                OnPropertyChanged();
                AddToListCommand.RaiseCanExecute();
                SolveGroupDataCommand.RaiseCanExecute();
               
            }
        }

        private int nValue;

        public int NValue
        {
            get { return nValue; }
            set {
                nValue = value;
                OnPropertyChanged();
                AddToListCommand.RaiseCanExecute();
                SolveGroupDataCommand.RaiseCanExecute();
                //if (nValue<1)
                //{
                //    AddError(nameof(NValue), "N-Value can not be less than 3");
                //}
                //else
                //{
                //    ClearErrors(nameof(NValue));
                //}
            }
        }

        private ObservableCollection<double> xValues;

        public ObservableCollection<double> XValues
        {
            get { return xValues; }
            set {
                xValues = value;
      
               
            }
        }

        private ObservableCollection<int> nvalues;

        public ObservableCollection<int> NValues
        {
            get { return nvalues; }
            set {
                nvalues = value;
 
            }
        }

        public AddToListCommand AddToListCommand { get; set; }

        public SolveGroupDataCommand SolveGroupDataCommand { get; set; }    


        private double mean;

        public double Mean
        {
            get { return mean; }
            set {
                mean = value;
                OnPropertyChanged();
            }
        }

        private double mode;

        public double Mode
        {
            get { return mode; }
            set {
                mode = value;
                OnPropertyChanged();
            }
        }

        private double meadian;

        public double Meadian
        {
            get { return meadian; }
            set { 
                meadian = value;
                OnPropertyChanged();
            }
        }


    }
}
