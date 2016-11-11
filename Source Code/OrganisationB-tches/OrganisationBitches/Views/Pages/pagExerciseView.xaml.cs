using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using OrganisationBitches.Models;
using OrganisationBitches.ViewModels;

namespace OrganisationBitches.Views.Pages
{
    /// <summary>
    /// Interaction logic for pagExerciseView.xaml
    /// </summary>
    public partial class pagExerciseView : Page
    {
        public pagExerciseView()
        {
            InitializeComponent();
        }

        #region Page Element Event Handlers

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCurrentChart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewChart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbtnCalender_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dpChartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataHandler.UpdateExerciseDate(dpChartDate.SelectedDate);
        }

        #endregion

        #region Event Handlers

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ChartDate = DataHandler.dtExerciseDate;
            dpChartDate.SelectedDate = ChartDate;
            // Subscribe to the Chart Date Changed Event
            DataHandler.ExerciseDateChanged += new ViewModels.EventHandler(ChartDateChangedHandler);
        }

        public void ChartDateChangedHandler()
        {
            ChartDate = DataHandler.dtExerciseDate;
            dpChartDate.SelectedDate = ChartDate;
        }

        #endregion

        #region Dependency Properties

        public DateTime? ChartDate
        {
            get { return (DateTime?)GetValue(ChartDateProperty); }
            set { SetValue(ChartDateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChartDate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartDateProperty =
            DependencyProperty.Register("ChartDate", typeof(DateTime?), typeof(pagExerciseView), new PropertyMetadata(null));


        public ExerciseChartModel SelectedExerciseChart
        {
            get { return (ExerciseChartModel)GetValue(SelectedExerciseChartProperty); }
            set { SetValue(SelectedExerciseChartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedExerciseChart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedExerciseChartProperty =
            DependencyProperty.Register("SelectedExerciseChart", typeof(ExerciseChartModel), typeof(pagExerciseView), new PropertyMetadata(new ExerciseChartModel()));

        #endregion

    }
}
