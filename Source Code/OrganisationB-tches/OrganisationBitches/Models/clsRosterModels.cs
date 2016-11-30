using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OrganisationBitches.Models
{
    public class RosterModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        private double? _allocatedPermanentHours;

        public double? AllocatedPermanentHours
        {
            get { return _allocatedPermanentHours; }
            set
            {
                _allocatedPermanentHours = value;
                OnPropertyChanged("AllocatedPermanentHours");
            }
        }

        private double? _allocatedCasualHours;

        public double? AllocatedCasualHours
        {
            get { return _allocatedCasualHours; }
            set
            {
                _allocatedCasualHours = value;
                OnPropertyChanged("AllocatedCasualHours");
            }
        }

        private double? _allocatedHours;

        public double? AllocatedHours
        {
            get { return _allocatedHours; }
            set
            {
                _allocatedHours = value;
                OnPropertyChanged("AllocatedHours");
            }
        }

        private double? _totalHours;

        public double? TotalHours
        {
            get { return _totalHours; }
            set
            {
                _totalHours = value;
                OnPropertyChanged("TotalHours");
            }
        }

    }

    public class RosterEntryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _rosterID;

        public int RosterID
        {
            get { return _rosterID; }
            set
            {
                _rosterID = value;
                OnPropertyChanged("RosterID");
            }
        }

        private int _userID;

        public int UserID
        {
            get { return _userID; }
            set
            {
                _userID = value;
                OnPropertyChanged("UserID");
            }
        }

        private DateTime _entryDate;

        public DateTime EntryDate
        {
            get { return _entryDate; }
            set
            {
                _entryDate = value;
                OnPropertyChanged("EntryDate");
            }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }
        
        public long UnpaidTimeTicks
        {
            get { return UnpaidTime.Ticks; }
            set { UnpaidTime = new TimeSpan(value); }
        }

        private TimeSpan _unpaidTime;

        public TimeSpan UnpaidTime
        {
            get { return _unpaidTime; }
            set
            {
                _unpaidTime = value;
                OnPropertyChanged("UnpaidTime");
            }
        }
        
        public long PaidTimeTicks
        {
            get { return PaidTime.Ticks; }
            set { PaidTime = new TimeSpan(value); }
        }
        
        private TimeSpan _paidTime;

        public TimeSpan PaidTime
        {
            get { return _paidTime; }
            set
            {
                _paidTime = value;
                OnPropertyChanged("PaidTime");
            }
        }

    }

    public class RosterDisplayModel : RosterModel
    {
        private ObservableCollection<DataGridColumn> _columnCollection;

        public ObservableCollection<DataGridColumn> ColumnCollection
        {
            get { return _columnCollection; }
            set { _columnCollection = value; }
        }

        private ObservableCollection<RosterPersonModel> _rosterPersons;

        public ObservableCollection<RosterPersonModel> RosterPersons
        {
            get { return _rosterPersons; }
            set { _rosterPersons = value; }
        }

    }

    public class RosterPersonModel : PersonModel
    {
        private ObservableCollection<RosterDayEntryModel> _rosterDayEntries;

        public ObservableCollection<RosterDayEntryModel> RosterDayEntries
        {
            get { return _rosterDayEntries; }
            set { _rosterDayEntries = value; }
        }

    }

    public class RosterDayEntryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private DateTime _entryDate;

        public DateTime EntryDate
        {
            get { return _entryDate; }
            set
            {
                _entryDate = value;
                OnPropertyChanged("EntryDate");
            }
        }

        private DateTime _startTime;

        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        private DateTime _endTime;

        public DateTime EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        public long? BreakTicks
        {
            get { return (Break == null) ? (long?)null : Break.Value.Ticks; }
            set
            {
                if (value == null)
                    Break = new TimeSpan(0);
                else
                    Break = new TimeSpan((long)value);
            }
        }


        private TimeSpan? _break;

        public TimeSpan? Break
        {
            get { return _break; }
            set
            {
                _break = value;
                OnPropertyChanged("Break");
            }
        }

    }
}
