using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrganisationBitches.Models;
using System.Collections.ObjectModel;

namespace OrganisationBitches.ViewModels
{
    class clsDataViewModel
    {
    }

    public delegate void EventHandler();

    public static class DataHandler
    {
        #region Event Declarations

        public static event EventHandler ExerciseDateChanged;
        public static event EventHandler SelectedExerciseChartChanged;
        public static event EventHandler UserChanged;
        public static event EventHandler TimesheetEntriesChanged;

        #endregion

        #region Properties


        private static Exception _errorLogException;
        public static Exception ErrorLogException
        {
            get { return _errorLogException; }
            set
            {
                _errorLogException = value;
                if (_errorLogException != null)
                    ErrorLogExceptionHandler();
            }
        }

        public static DateTime? dtExerciseDate { get; set; }

        public static ExerciseChartModel ecSelectedChart { get; set; }

        public static ObservableCollection<PersonModel> ocPersons { get; set; }

        public static ObservableCollection<TimesheetEntryModel> ocTimesheetEntires { get; set; }

        public static PersonModel pmSelectedPerson { get; set; }

        #endregion

        #region Private Methods

        private static void GetAllData()
        {
            dtExerciseDate = DateTime.Now;

            
        }

        private static void GetPersons()
        {
            string strQuery = "SELECT * FROM Persons";
            var results = DatabaseModel.Query<PersonModel>(strQuery);
            ocPersons = new ObservableCollection<PersonModel>(results);

            if (UserChanged != null)
            {
                UserChanged.Invoke();
            }
        }

        private static void GetAllTimesheetEntriesForPerson()
        {
            string strQuery = "SELECT t.ID, t.ClockIn, t.ClockOut, t.UnpaidTime UnpaidTimeSpanTicks, t.PaidTime PaidTimeSpanTicks FROM TimesheetEntries t WHERE PersonID = @ID; ";
            var queryResults = DatabaseModel.Query<TimesheetEntryModel>(strQuery, pmSelectedPerson);
            if (queryResults != null)
            {
                ocTimesheetEntires = new ObservableCollection<TimesheetEntryModel>(queryResults);
            }
            else
            {
                ocTimesheetEntires = null;
            }

            if (TimesheetEntriesChanged != null)
            {
                TimesheetEntriesChanged.Invoke();
            }
        }


        private static void InsertTimesheetEntries(IEnumerable<TimesheetEntryModel> timesheetEntries)
        {
            string strQuery = "spInsertTimesheetEntriesForPerson";

            int affectedRows = DatabaseModel.StoredProcedureExecute(strQuery, timesheetEntries.ToArray());

            if (affectedRows < 0)
            {
                throw new DatabaseErrorException("Error writing to Database");
            }
            else
            {
                GetAllTimesheetEntriesForPerson();
            }
        }


        private static void InsertTimesheetEntry(TimesheetEntryModel timesheetEntry)
        {
            List<TimesheetEntryModel> entry = new List<TimesheetEntryModel>();
            entry.Add(timesheetEntry);

            InsertTimesheetEntries(entry);
        }

        private static void UpdateTimesheetEntries(IEnumerable<TimesheetEntryModel> timesheetEntries)
        {
            string strQuery = "spUpdateTimesheetEntriesForPerson";

            /// XXX: Throws exception complaining that stored procedure can't be found
            int affectedRows = DatabaseModel.StoredProcedureExecute(strQuery, timesheetEntries.ToArray());

            if (affectedRows < 0)
            {
                throw new DatabaseErrorException("Error writing to Database");
            }
            else
            {
                GetAllTimesheetEntriesForPerson();
            }
        }

        private static void UpdateTimesheetEntry(TimesheetEntryModel timesheetEntry)
        {
            List<TimesheetEntryModel> entry = new List<TimesheetEntryModel>();
            entry.Add(timesheetEntry);

            UpdateTimesheetEntries(entry);
        }

        #endregion

            #region Public Methods

        public static void Initialise()
        {
            GetPersons();

            GetAllData();
        }


        /// <summary>
        /// Change the Date of the currently Selected Exercise Chart
        /// </summary>
        /// <param name="newDateTime"></param>
        public static void UpdateExerciseDate(DateTime? newDateTime)
        {
            dtExerciseDate = newDateTime;

            // Fire Exercise Date Changed Event
            if (ExerciseDateChanged != null)
            {
                ExerciseDateChanged.Invoke();
            }
        }

        public static void UpdateSelectedExerciseChart(DateTime? dt)
        {
            // Get the chart whose date range includes dt

            // Fire Selected Exercise Chart Changed Event
            if(SelectedExerciseChartChanged != null)
            {
                SelectedExerciseChartChanged.Invoke();
            }
        }

        public static void UpdateUser(PersonModel person)
        {
            pmSelectedPerson = person;

            if (pmSelectedPerson != null)
            {
                GetAllTimesheetEntriesForPerson();
            }
            else
            {
                ocTimesheetEntires = null;
                if (TimesheetEntriesChanged != null)
                {
                    TimesheetEntriesChanged.Invoke();
                }
            }
        }


        public static void ClockIn()
        {
            // Check if there are any unfinished shifts
            var entries = ocTimesheetEntires.FirstOrDefault(x => x.ClockOut == null);
            // If there aren't any, add a new shift
            if (entries == null)
            {
                TimesheetEntryModel shift = new TimesheetEntryModel();
                shift.ClockIn = DateTime.Now;

                InsertTimesheetEntry(shift);
            }
        }

        public static void ClockOut()
        {
            // Check for any unfinished shifts
            var shifts = ocTimesheetEntires.Where(x => x.ClockOut == null).ToList();
            // If there are, end the shift
            if(shifts != null && shifts.Count() > 0)
            {
                foreach (var s in shifts)
                {
                    s.ClockOut = DateTime.Now;
                    s.PaidTime = s.ClockOut - s.ClockIn - s.UnpaidTime.GetValueOrDefault();
                }

                UpdateTimesheetEntries(shifts);
            }
        }

        public static void StopBreak()
        {
            throw new NotImplementedException();
        }

        public static void StartBreak()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Event Handlers

        private static void ErrorLogExceptionHandler()
        {
            // Implement Messenger Later
            Console.WriteLine("EXCEPTION THROWN: " + ErrorLogException.Message);
        }

        #endregion
    }
}
