using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace ProjectQLBH
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection LastHourSeries { get; set; }
        public SeriesCollection LastHourSeries1 { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new StackedColumnSeries
                {
                    Values = new ChartValues<double> {12,52,81,63},
                    StackMode = StackMode.Values,
                    DataLabels = true
                },
                 new StackedColumnSeries
                {
                    Values = new ChartValues<double> {-18,-35,-20,-19},
                    StackMode = StackMode.Values,
                    DataLabels = true
                }
            };
            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(9),
                        new ObservableValue(4),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(1),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            LastHourSeries1 = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(13),
                        new ObservableValue(11),
                        new ObservableValue(9),
                        new ObservableValue(14),
                        new ObservableValue(5),
                        new ObservableValue(3),
                        new ObservableValue(12),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(7),
                    }
                }
            };
            Labels = new[] { "Thang 4", "Thang 5", "Thang 6", "Thang 7" };
            Formatter = value => value.ToString();
            DataContext = this;
            string imgCartoon = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString()}\\Images\\cartoon-woman-pretty.png";
            ImgCartoon.Source = new BitmapImage(new Uri(imgCartoon));
        }
    }
}
