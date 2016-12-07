using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OBSeen.Views.Controls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
        }

        #region Properties

        public DateTime time { get; set; }

        #endregion

        #region Dependency Properties


        public int hour
        {
            get { return (int)GetValue(hourProperty); }
            set { SetValue(hourProperty, value); }
        }

        // Using a DependencyProperty as the backing store for hour.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty hourProperty =
            DependencyProperty.Register("hour", typeof(int), typeof(TimePicker), new PropertyMetadata(0,OnHourChanged));



        public int minute
        {
            get { return (int)GetValue(minuteProperty); }
            set { SetValue(minuteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for minute.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty minuteProperty =
            DependencyProperty.Register("minute", typeof(int), typeof(TimePicker), new PropertyMetadata(0, OnMinuteChanged));



        #endregion

        #region Event Handlers

        private static void OnHourChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as TimePicker;
            if (element != null)
            {
                element.time = new DateTime(element.time.Year, element.time.Month, element.time.Day, (int)e.NewValue, element.time.Minute, element.time.Second);
            }
        }

        private static void OnMinuteChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as TimePicker;
            if (element != null)
            {
                element.time = new DateTime(element.time.Year, element.time.Month, element.time.Day, element.time.Hour, (int)e.NewValue, element.time.Second);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            hour = time.Hour;
            minute = time.Minute;
        }

        private void txtHour_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /// XXX: Make this Regular Expression check for numbers between 0 and 23
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txtMinute_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /// XXX: Make this Regular Expression check for numbers between 0 and 59
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #region Click Events

        private void btnHourUp_Click(object sender, RoutedEventArgs e)
        {
            hour = (hour >= 23) ? 0 : hour + 1;
        }

        private void btnHourDown_Click(object sender, RoutedEventArgs e)
        {
            hour = (hour <= 0) ? 23 : hour - 1;
        }

        private void btnMinUp_Click(object sender, RoutedEventArgs e)
        {
            minute = (minute >= 59) ? 0 : minute + 1;
        }

        private void btnMinDown_Click(object sender, RoutedEventArgs e)
        {
            minute = (minute <= 0) ? 59 : minute - 1;
        }

        #endregion

        #endregion
        
    }
}
