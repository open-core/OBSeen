using OBSeen.Models;
using OBSeen.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OBSeen.Views.Pages
{
    /// <summary>
    /// Interaction logic for pagExerciseView.xaml
    /// </summary>
    public partial class pagExerciseView : Page
    {
        public pagExerciseView()
        {
            InitializeComponent();
            DataContext = this;
        }



        #region Event Handlers

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bdrPlanner.Visibility = Visibility.Collapsed;
            bdrSheets.Visibility = Visibility.Collapsed;
            bdrProgress.Visibility = Visibility.Collapsed;
            ocSelections.Add("Sheets");
            ocSelections.Add("Planner");
            ocSelections.Add("Progress");

            ChartDate = DataHandler.dtExerciseDate;
            // Subscribe to the Chart Date Changed Event
            DataHandler.ExerciseDateChanged += new ViewModels.EventHandler(ChartDateChangedHandler);
        }

        public void ChartDateChangedHandler()
        {
            ChartDate = DataHandler.dtExerciseDate;

            DataHandler.UserChanged += new ViewModels.EventHandler(UserChanged);
            UserChanged();
        }

        private void UserChanged()
        {
            if (DataHandler.pmSelectedPerson != null)
            {
                PageVisible = true;
            }
            else
            {
                PageVisible = false;
            }
        }

        #region Click Events


        private void lbxSelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((string)lbxSelection.SelectedItem)
            {
                case "Sheets":
                    bdrPlanner.Visibility = Visibility.Collapsed;
                    bdrProgress.Visibility = Visibility.Collapsed;
                    bdrSheets.Visibility = Visibility.Visible;
                    break;
                case "Planner":
                    bdrSheets.Visibility = Visibility.Collapsed;
                    bdrProgress.Visibility = Visibility.Collapsed;
                    bdrPlanner.Visibility = Visibility.Visible;
                    break;
                case "Progress":
                    bdrSheets.Visibility = Visibility.Collapsed;
                    bdrPlanner.Visibility = Visibility.Collapsed;
                    bdrProgress.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }


        #endregion

        #endregion

        #region Dependency Properties



        public bool PageVisible
        {
            get { return (bool)GetValue(PageVisibleProperty); }
            set { SetValue(PageVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageVisibleProperty =
            DependencyProperty.Register("PageVisible", typeof(bool), typeof(pagExerciseView), new PropertyMetadata(false));



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



        public ObservableCollection<string> ocSelections
        {
            get { return (ObservableCollection<string>)GetValue(ocSelectionsProperty); }
            set { SetValue(ocSelectionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocSelections.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocSelectionsProperty =
            DependencyProperty.Register("ocSelections", typeof(ObservableCollection<string>), typeof(pagExerciseView), new PropertyMetadata(new ObservableCollection<string>()));



        #endregion

    }
}
