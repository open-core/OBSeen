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
using System.Windows.Shapes;
using OrganisationBitches.Views.Pages;
using OrganisationBitches.ViewModels;
using System.Collections.ObjectModel;
using OrganisationBitches.Models;

namespace OrganisationBitches.Views
{
    /// <summary>
    /// Interaction logic for winMainView.xaml
    /// </summary>
    public partial class winMainView : Window
    {
        public winMainView()
        {
            InitializeComponent();
            DataContext = this;

            pgTimesheetView = new pagTimesheetView();
            pgRosterView = new pagRostersView();
            pgPersonsView = new pagPersonsView();
            pgExerciseView = new pagExerciseView();
        }
        
        #region Properties

        public pagExerciseView pgExerciseView { get; set; }

        public pagTimesheetView pgTimesheetView { get; set; }

        public pagPersonsView pgPersonsView { get; set; }

        public pagRostersView pgRosterView { get; set; }


        #endregion

        #region Dependency Properties



        public ObservableCollection<Page> ocPages
        {
            get { return (ObservableCollection<Page>)GetValue(ocPagesProperty); }
            set { SetValue(ocPagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocPages.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocPagesProperty =
            DependencyProperty.Register("ocPages", typeof(ObservableCollection<Page>), typeof(winMainView), new PropertyMetadata(null));




        public ObservableCollection<PersonModel> ocPersons
        {
            get { return (ObservableCollection<PersonModel>)GetValue(ocPersonsProperty); }
            set { SetValue(ocPersonsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocPersons.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocPersonsProperty =
            DependencyProperty.Register("ocPersons", typeof(ObservableCollection<PersonModel>), typeof(winMainView), new PropertyMetadata(null));



        #endregion
        
        #region Click Event Handlers

        private void btnTimesheet_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(pgTimesheetView);
        }

        private void btnPersons_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(pgPersonsView);
        }

        private void btnExercise_Click(object sender, RoutedEventArgs e)
        {
            frmMain.Navigate(pgExerciseView);
        }

        private void cbxPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = cbxPersons.SelectedItem as PersonModel;
            if (obj != null)
            {
                DataHandler.UpdateUser(obj);
            }
        }

        #endregion

        #region Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Add Pages to Pages List
            ocPages = new ObservableCollection<Page>();
            ocPages.Add(pgTimesheetView);
            ocPages.Add(pgRosterView);
            ocPages.Add(pgExerciseView);
            ocPages.Add(pgPersonsView);

            // Subscribed to UserChangedEvent
            DataHandler.UserChanged += new ViewModels.EventHandler(PersonsChangedHandler);
            // Initialise DataHandler
            DataHandler.Initialise();
        }

        private void PersonsChangedHandler()
        {
            ocPersons = DataHandler.ocPersons;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbxPageNavigation.SelectedItem != null)
            {
                frmMain.Navigate(lbxPageNavigation.SelectedItem);
            }
        }

        #endregion
    }
}
