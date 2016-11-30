using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using OrganisationBitches.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace OrganisationBitches.ViewModels
{
    public class NullToBoolConverter : IValueConverter
    {
        /// <summary>
        /// Returns True if Object is not null or false if it is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var oc = value;
            if (oc != null)
            {
                return true;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ModelConverter
    {
        public RosterDisplayModel RosterToRosterDisplayModel(RosterModel roster)
        {
            // Copy roster data to new RosterDisplayModel
            RosterDisplayModel rdModel = new RosterDisplayModel();
            rdModel.ID = roster.ID;
            rdModel.StartDate = roster.StartDate;
            rdModel.EndDate = roster.EndDate;
            rdModel.TotalHours = roster.TotalHours;
            rdModel.AllocatedCasualHours = roster.AllocatedCasualHours;
            rdModel.AllocatedHours = roster.AllocatedHours;
            rdModel.AllocatedPermanentHours = roster.AllocatedPermanentHours;

            // Create DataGridColumns for display on view
            rdModel.ColumnCollection = new ObservableCollection<DataGridColumn>();
            // Add column for showing Person Data
            // ......

            // Add Columns for displaying RosterDayEntries
            for (DateTime date = rdModel.StartDate; date <= rdModel.EndDate; date = date.AddDays(1.0))
            {
                DataGridTextColumn dgtc = new DataGridTextColumn();
                dgtc.Header = date;
                /// XXX: Binding goes here
                rdModel.ColumnCollection.Add(dgtc);
            }

            return rdModel;
        }
    }
}
