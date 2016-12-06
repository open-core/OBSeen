using OrganisationBitches.Models;
using OrganisationBitches.ViewModels;
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

namespace OrganisationBitches.Views.Pages
{
    /// <summary>
    /// Interaction logic for pagTimesheetView.xaml
    /// </summary>
    public partial class pagTimesheetView : Page
    {
        public pagTimesheetView()
        {
            InitializeComponent();
            DataContext = this;
        }


        #region Dependency Properties
        

        public ObservableCollection<TimesheetEntryModel> ocTimeSheet
        {
            get { return (ObservableCollection<TimesheetEntryModel>)GetValue(ocTimeSheetProperty); }
            set { SetValue(ocTimeSheetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocTimeSheet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocTimeSheetProperty =
            DependencyProperty.Register("ocTimeSheet", typeof(ObservableCollection<TimesheetEntryModel>), typeof(pagTimesheetView), new PropertyMetadata(new ObservableCollection<TimesheetEntryModel>()));



        public bool PageVisible
        {
            get { return (bool)GetValue(PageVisibleProperty); }
            set { SetValue(PageVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageVisibleProperty =
            DependencyProperty.Register("PageVisible", typeof(bool), typeof(pagTimesheetView), new PropertyMetadata(false));



        public bool CanEditEntries
        {
            get { return (bool)GetValue(CanEditEntriesProperty); }
            set { SetValue(CanEditEntriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanEditEntries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditEntriesProperty =
            DependencyProperty.Register("CanEditEntries", typeof(bool), typeof(pagTimesheetView), new PropertyMetadata(false));



        #endregion


        #region Event Handlers

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ocTimeSheet = DataHandler.ocTimesheetEntires;
            DataHandler.TimesheetEntriesChanged += new ViewModels.EventHandler(TimesheetEntriesChangedHandler);
            dgTimesheets.SelectedItem = DataHandler.teSelectedTimesheetEntry;
            DataHandler.SelectedTimesheetEntryChanged += new ViewModels.EventHandler(SelectedTimesheetEntryChanged);
            DataHandler.UserChanged += new ViewModels.EventHandler(UserChanged);
            UserChanged();
        }

        private void TimesheetEntriesChangedHandler()
        {
            ocTimeSheet = DataHandler.ocTimesheetEntires;
        }

        private void SelectedTimesheetEntryChanged()
        {
            dgTimesheets.SelectedItem = DataHandler.teSelectedTimesheetEntry;
        }

        private void UserChanged()
        {
            if (DataHandler.pmSelectedPerson != null)
            {
                CanEditEntries = DataHandler.pmSelectedPerson.UserLevel.CanEditAllUsersData;
                PageVisible = true;
            }
            else
            {
                CanEditEntries = false;
                PageVisible = false;
            }
        }

        #region Click Event Handlers

        private void btnClockIn_Click(object sender, RoutedEventArgs e)
        {
            DataHandler.ClockIn();
        }

        private void btnBreakStart_Click(object sender, RoutedEventArgs e)
        {
            DataHandler.StartBreak();
        }

        private void btnBreakStop_Click(object sender, RoutedEventArgs e)
        {
            DataHandler.StopBreak();
        }

        private void btnClockOut_Click(object sender, RoutedEventArgs e)
        {
            DataHandler.ClockOut();
        }
        private void dgTimesheets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataHandler.UpdateSelectedTimesheetEntry(dgTimesheets.SelectedItem as TimesheetEntryModel);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #endregion


    }
}
