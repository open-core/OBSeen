using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSeen.Models
{
    public class ExerciseChartModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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

        private int _durationDays;

        public int DurationDays
        {
            get { return _durationDays; }
            set { _durationDays = value; }
        }

        private ObservableCollection<ResistanceExerciseModel> _resistanceExercises;

        public ObservableCollection<ResistanceExerciseModel> ResistanceExercises
        {
            get { return _resistanceExercises; }
            set { _resistanceExercises = value; }
        }

        private ObservableCollection<CardioExerciseModel> _cardioExercises;

        public ObservableCollection<CardioExerciseModel> CardioExercises
        {
            get { return _cardioExercises; }
            set { _cardioExercises = value; }
        }

        private ObservableCollection<FlexibilityExerciseModel> _flexibilityExercises;

        public ObservableCollection<FlexibilityExerciseModel> FlexibilityExercises
        {
            get { return _flexibilityExercises; }
            set { _flexibilityExercises = value; }
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class ResistanceExerciseModel : ExerciseModel
    {
        public ObservableCollection<SetModel> Sets { get; set; }
    }

    public class CardioExerciseModel : ExerciseModel
    {
        private double _distance;

        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private TimeSpan _duration;

        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private int _difficulty;

        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }

    }

    public class FlexibilityExerciseModel : ExerciseModel
    {
        private TimeSpan _duration;

        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged("Duration");
            }
        }

        private int _difficulty;

        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                OnPropertyChanged("Difficulty");
            }
        }
    }

    public class ExerciseModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private DateTime _exerciseDate;

        public DateTime ExerciseDate
        {
            get { return _exerciseDate; }
            set
            {
                _exerciseDate = value;
                OnPropertyChanged("ExerciseDate");
            }
        }

        private int _effortExerted;

        public int EffortExerted
        {
            get { return _effortExerted; }
            set
            {
                _effortExerted = value;
                OnPropertyChanged("EffortExerted");
            }
        }



        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class SetModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _setNumber;

        public int SetNumber
        {
            get { return _setNumber; }
            set { _setNumber = value; }
        }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged("Weight");
            }
        }

        private int _reps;

        public int Reps
        {
            get { return _reps; }
            set
            {
                _reps = value;
                OnPropertyChanged("Reps");
            }
        }

        private int _effortExerted;

        public int EffortExerted
        {
            get { return _effortExerted; }
            set
            {
                _effortExerted = value;
                OnPropertyChanged("EffortExerted");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
