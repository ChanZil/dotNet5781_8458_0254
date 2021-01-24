using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace PO
{
    public class POLines : DependencyObject
    {
        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id",
            typeof(int), typeof(POLines));

        public int Code
        {
            get { return (int)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code",
            typeof(int), typeof(POLines));

        public BO.Areas Area
        {
            get { return (BO.Areas)GetValue(AreaProperty); }
            set { SetValue(AreaProperty, value); }
        }
        public static readonly DependencyProperty AreaProperty =
            DependencyProperty.Register("Area",
            typeof(BO.Areas), typeof(POLines));

        public TimeSpan StartAt
        {
            get { return (TimeSpan)GetValue(StartAtProperty); }
            set { SetValue(StartAtProperty, value); }
        }
        public static readonly DependencyProperty StartAtProperty =
            DependencyProperty.Register("StartAt",
            typeof(TimeSpan), typeof(POLines));

        public TimeSpan FinishAt
        {
            get { return (TimeSpan)GetValue(FinishAtProperty); }
            set { SetValue(FinishAtProperty, value); }
        }
        public static readonly DependencyProperty FinishAtProperty =
            DependencyProperty.Register("FinishAt",
            typeof(TimeSpan), typeof(POLines));

        public TimeSpan Frequency
        {
            get { return (TimeSpan)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency",
            typeof(TimeSpan), typeof(POLines));

        public ObservableCollection<POStationInLine> ListOfStationInLine { get; set; } = new ObservableCollection<POStationInLine>();
    }
}
