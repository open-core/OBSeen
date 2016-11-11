using OrganisationBitches.Models;
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
    /// Interaction logic for pagPersonsView.xaml
    /// </summary>
    public partial class pagPersonsView : Page
    {
        public pagPersonsView()
        {
            InitializeComponent();
            DataContext = this;
            AddNavigationOptions();
        }

        #region Private Functions

        private void AddNavigationOptions()
        {
            ocNavigationOptions.Add("Add");
            ocNavigationOptions.Add("Remove");
            ocNavigationOptions.Add("Edit");
        }

        #endregion

        #region Dependency Properties



        public PersonModel SelectedPerson
        {
            get { return (PersonModel)GetValue(SelectedPersonProperty); }
            set { SetValue(SelectedPersonProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedPerson.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPersonProperty =
            DependencyProperty.Register("SelectedPerson", typeof(PersonModel), typeof(pagPersonsView), new PropertyMetadata(null));



        public ObservableCollection<string> ocNavigationOptions
        {
            get { return (ObservableCollection<string>)GetValue(ocNavigationOptionsProperty); }
            set { SetValue(ocNavigationOptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ocNavigationOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ocNavigationOptionsProperty =
            DependencyProperty.Register("ocNavigationOptions", typeof(ObservableCollection<string>), typeof(pagPersonsView), new PropertyMetadata(new ObservableCollection<string>()));



        #endregion

        #region Click Events

        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemovePerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditPerson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
