using Practice.WPF.Statistics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.WPF.Statistics.Commands
{
    public class SolveGroupDataCommand : CommandBase
    {
        private readonly GroupDataViewModel _groupDataViewModel;

        public SolveGroupDataCommand(GroupDataViewModel groupDataViewModel)
        {
            _groupDataViewModel = groupDataViewModel;
        }
        public override bool CanExecute(object? parameter)
        {
            return _groupDataViewModel.NValues.Count() > 0;
        }
        public override void Execute(object? parameter)
        {
            staticsOperation();
        }

        private void staticsOperation()
        {
            _groupDataViewModel.Mean = GroupData.Mean(_groupDataViewModel.XValues.ToArray(), _groupDataViewModel.NValues.ToArray());
            _groupDataViewModel.Mode = GroupData.Mode(_groupDataViewModel.XValues.ToArray(), _groupDataViewModel.NValues.ToArray());
            _groupDataViewModel.Meadian = GroupData.Meadian(_groupDataViewModel.XValues.ToArray(), _groupDataViewModel.NValues.ToArray());
        }
    }

    public static class GroupData
    {
        public static double Mean(double [] xvalues, int[] nValues)
        {

            double sumXm=0; int sumN=0;
            int length= xvalues.Length;
            for (int i = 0; i <length; i++)
            {
                sumXm+= xvalues[i]*nValues[i];
                sumN+=nValues[i];
            }
            return sumXm/sumN;
        }

        public static double Mode(double[] xvalues, int[] nValues)
        {
           
           var SortedData= SortXandN(xvalues, nValues);

            return SortedData.Item1[xvalues.Length-1];
        }

        public static double Meadian(double[] xvalues, int[] nValues)
        {
            var sortedData = SortXandN(xvalues, nValues);
            double sumN = sortedData.Item2.Sum();
            double md;
            md = (sumN % 2) > 0 ? (sumN + 1) / 2 : sumN / 2;
            double cumN = 0;
            double meadian = 0;

            for (int i = 0; i < sortedData.Item2.Length; i++)
            {
                cumN += sortedData.Item2[i];
                if (cumN >= md)
                {
                    meadian = sortedData.Item1[i];
                    break;
                }
            }
            return meadian;
        }
        public static Tuple<double[], int[]> SortXandN(double[] xvalues, int[] nValues)
        {

            double xTemp;
            int nTemp;
            int length = xvalues.Length;

            int NSwap= 1;

            while (NSwap>0)
            {
                NSwap = 0;
                for (int i = 0; i < length - 1; i++)
                {
                    if (nValues[i] > nValues[i + 1])
                    {
                        xTemp = xvalues[i+1];
                        xvalues[i+1] = xvalues[i];
                        xvalues[i] = xTemp;
                       
                        nTemp = nValues[i+1];
                        nValues[i+1] = nValues[i];
                        nValues[i] = nTemp;

                        NSwap++;
                    }
                }
            }

            return Tuple.Create(xvalues, nValues);
        }
        
    }
}
