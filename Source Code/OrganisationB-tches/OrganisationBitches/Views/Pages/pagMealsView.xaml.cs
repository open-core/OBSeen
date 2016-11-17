using OrganisationBitches.ViewModels;
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

namespace OrganisationBitches.Views.Pages
{
    /// <summary>
    /// Interaction logic for pagMealsView.xaml
    /// </summary>
    public partial class pagMealsView : Page
    {
        public pagMealsView()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Dependency Properties
        
        public bool PageVisible
        {
            get { return (bool)GetValue(PageVisibleProperty); }
            set { SetValue(PageVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageVisibleProperty =
            DependencyProperty.Register("PageVisible", typeof(bool), typeof(pagMealsView), new PropertyMetadata(false));
        
        #endregion



        #region Event Handlers

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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

        #endregion
    }
}
