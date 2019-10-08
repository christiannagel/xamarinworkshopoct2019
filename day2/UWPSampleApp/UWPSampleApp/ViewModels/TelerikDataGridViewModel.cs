using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using UWPSampleApp.Core.Models;
using UWPSampleApp.Core.Services;
using UWPSampleApp.Helpers;

namespace UWPSampleApp.ViewModels
{
    public class TelerikDataGridViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public TelerikDataGridViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
