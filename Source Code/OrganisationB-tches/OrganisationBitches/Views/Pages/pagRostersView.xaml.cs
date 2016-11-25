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
    /// Interaction logic for pagRostersView.xaml
    /// </summary>
    public partial class pagRostersView : Page
    {
        public pagRostersView()
        {
            InitializeComponent();
        }

        #region Dependency Properties

        public bool PageVisible
        {
            get { return (bool)GetValue(PageVisibleProperty); }
            set { SetValue(PageVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageVisibleProperty =
            DependencyProperty.Register("PageVisible", typeof(bool), typeof(pagRostersView), new PropertyMetadata(false));



        public bool CanEditEntries
        {
            get { return (bool)GetValue(CanEditEntriesProperty); }
            set { SetValue(CanEditEntriesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanEditEntries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditEntriesProperty =
            DependencyProperty.Register("CanEditEntries", typeof(bool), typeof(pagRostersView), new PropertyMetadata(false));



        public ObservableCollection<RosterModel> ocRosters
        {
            get { return (ObservableCollection<RosterModel>)GetValue(ocRostersProperty); }
            set { SetValue(ocRostersProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocRosters.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocRostersProperty =
            DependencyProperty.Register("ocRosters", typeof(ObservableCollection<RosterModel>), typeof(pagRostersView), new PropertyMetadata(null));





        public double? dblPermAllocHoursDiff
        {
            get { return (double?)GetValue(dblPermAllocHoursDiffProperty); }
            set { SetValue(dblPermAllocHoursDiffProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dblPermAllocHoursDiff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dblPermAllocHoursDiffProperty =
            DependencyProperty.Register("dblPermAllocHoursDiff", typeof(double?), typeof(pagRostersView), new PropertyMetadata(null));



        public double? dblCasAllocHoursDiff
        {
            get { return (double?)GetValue(dblCasAllocHoursDiffProperty); }
            set { SetValue(dblCasAllocHoursDiffProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dblCasAllocHoursDiff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dblCasAllocHoursDiffProperty =
            DependencyProperty.Register("dblCasAllocHoursDiff", typeof(double?), typeof(pagRostersView), new PropertyMetadata(null));



        public double? dblTotalAllocHoursDiff
        {
            get { return (double?)GetValue(dblTotalAllocHoursDiffProperty); }
            set { SetValue(dblTotalAllocHoursDiffProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dblTotalAllocHoursDiff.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty dblTotalAllocHoursDiffProperty =
            DependencyProperty.Register("dblTotalAllocHoursDiff", typeof(double?), typeof(pagRostersView), new PropertyMetadata(null));
        

        #endregion

        #region Event Handlers

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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataHandler.UserChanged += new ViewModels.EventHandler(UserChanged);
            UserChanged();
        }

        private void txtPermAllocHours_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCasAllocHours_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtTotAllocHours_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        #region Click Events

        private void btnNewRoster_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditRoster_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveRoster_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteRoster_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #endregion

    }
}
