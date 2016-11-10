using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganisationBitches.Models
{
    public class TimesheetEntryModel : INotifyPropertyChanged
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

        private DateTime? _clockIn;

        public DateTime? ClockIn
        {
            get { return _clockIn; }
            set
            {
                _clockIn = value;
                OnPropertyChanged("ClockIn");
            }
        }

        private DateTime? _clockOut;

        public DateTime? ClockOut
        {
            get { return _clockOut; }
            set
            {
                _clockOut = value;
                OnPropertyChanged("ClockOut");
            }
        }

        private TimeSpan? _unpaidTime;

        public TimeSpan? UnpaidTime
        {
            get { return _unpaidTime; }
            set
            {
                _unpaidTime = value;
                OnPropertyChanged("UnpaidTime");
            }
        }

        public long? UnpaidTimeSpanTicks
        {
            get { return (UnpaidTime == null)? (long?)null : UnpaidTime.Value.Ticks; }
            set
            {
                if(value == null)
                    UnpaidTime = new TimeSpan(0);
                else
                    UnpaidTime = new TimeSpan((long)value);
            }
        }


        private TimeSpan? _paidTime;

        public TimeSpan? PaidTime
        {
            get { return _paidTime; }
            set
            {
                _paidTime = value;
                OnPropertyChanged("PaidTime");
            }
        }

        public long? PaidTimeSpanTicks
        {
            get { return (PaidTime == null) ? (long?)null : PaidTime.Value.Ticks; }
            set
            {
                if (value == null)
                    PaidTime = new TimeSpan(0);
                else
                    PaidTime = new TimeSpan((long)value);
            }
        }
    }
}
