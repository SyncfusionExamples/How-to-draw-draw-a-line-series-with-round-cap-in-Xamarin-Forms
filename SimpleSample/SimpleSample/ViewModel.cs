using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SimpleSample
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model> LineSeriesData { get; set; }

        public ViewModel()
        {
            LineSeriesData = new ObservableCollection<Model>();

            Random random = new Random();
            var dateTime = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                dateTime = dateTime.AddHours(1);
                LineSeriesData.Add(new Model(dateTime, random.Next(1, 3), random.Next(4,6), random.Next(7, 9), random.Next(10, 12)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
