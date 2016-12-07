using Dapper;
using MySql.Data.MySqlClient;
using OBSeen.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSeen.Models
{

    public class PersonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private int _userLevelID;

        public int UserLevelID
        {
            get { return _userLevelID; }
            set
            {
                _userLevelID = value;
                OnPropertyChanged("UserLevelID");
            }
        }

        private UserLevelModel _userLevel;

        public UserLevelModel UserLevel
        {
            get { return _userLevel; }
            set
            {
                _userLevel = value;
                UserLevelID = value.ID;
                OnPropertyChanged("UserLevel");
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

    public class EmployeeModel : PersonModel
    {
        private EmploymentLevelModel _employmentLevel;

        public EmploymentLevelModel EmploymentLevel
        {
            get { return _employmentLevel; }
            set
            {
                _employmentLevel = value;
                OnPropertyChanged("EmploymentLevel");
            }
        }

    }

    public class EmploymentLevelModel
    {
        public int ID { get; set; }

        public string EmploymentLevelName { get; set; }
    }

    public class UserLevelModel
    {
        public int ID { get; set; }

        public string UserLevelName { get; set; }

        public bool CanViewAllUsersData { get; set; }

        public bool CanEditAllUsersData { get; set; }

        public bool HasSetupPrivileges { get; set; }
    }

    public static class DatabaseModel
    {
        /// <summary>
        /// Reads Data from DB then maps results to specified object type
        /// </summary>
        /// <typeparam name="T">The object type to map to</typeparam>
        /// <param name="strQuery">Database query</param>
        /// <param name="paramMap">Any parameters required for query in object form</param>
        /// <returns>Results of query in the same type as T</returns>
        public static IEnumerable<T> Query<T>(string strQuery, object paramMap = null)
        {
            using (MySqlConnection sql = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    if (paramMap == null)
                        return sql.Query<T>(strQuery);
                    else
                        return sql.Query<T>(strQuery, paramMap);
                }
                catch (Exception e)
                {
                    DataHandler.ErrorLogException = e;
                    return null;
                }
            }
        }

        /// <summary>
        /// Writes Data to DB
        /// </summary>
        /// <param name="strQuery">Execute Statement</param>
        /// <param name="paramMap">Objects to be writen</param>
        /// <returns>Number or Database rows affected. Or, -1 if failed</returns>
        public static int Execute(string strQuery, object paramMaps = null)
        {
            using (MySqlConnection sql = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                if (paramMaps == null)
                    return sql.Execute(strQuery);
                else
                    return sql.Execute(strQuery, paramMaps);
            }
        }

        /// <summary>
        /// Runs a Stored Procedure Query on Database then maps results to specified object type
        /// </summary>
        /// <typeparam name="T">The object type to map to</typeparam>
        /// <param name="strSP">The stored procedure to be executed</param>
        /// <param name="paramMap">Any parameters required to run SP, in object form</param>
        /// <returns>Results of Stored Procedure in the same type as T</returns>
        public static IEnumerable<T> StoredProcedureQuery<T>(string strSP, object paramMap = null)
        {
            using (MySqlConnection sql = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    if (paramMap == null)
                        return sql.Query<T>(strSP, commandType: CommandType.StoredProcedure);
                    else
                        return sql.Query<T>(strSP, paramMap, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    DataHandler.ErrorLogException = e;
                    return null;
                }
            }
        }

        public static IEnumerable<TElement> StoredProcedureQuery<TKey, TElement>(string strSP, Func<TKey, TElement, TElement> queryLambda, object paramMap = null)
        {
            using (MySqlConnection sql = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                if (paramMap == null)
                    return sql.Query<TKey, TElement, TElement>(strSP, queryLambda, commandType: CommandType.StoredProcedure);
                else
                    return sql.Query<TKey, TElement, TElement>(strSP, queryLambda, paramMap, commandType: CommandType.StoredProcedure);
            }
        }

        /// Runs a stored procedure on Database that stores object parameters into the correct tables
        /// </summary>
        /// <param name="strSP">The stored procedure to be executed</param>
        /// <param name="paramObjects">The objects to be stored into DB</param>
        /// <returns>Number or Database rows affected. Or, -1 if failed</returns>
        public static int StoredProcedureExecute(string strSP, object[] paramObjects = null)
        {
            using (MySqlConnection sql = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                try
                {
                    if (paramObjects == null || paramObjects.Count() == 0)
                        return sql.Execute(strSP, commandType: CommandType.StoredProcedure);
                    else
                        return sql.Execute(strSP, paramObjects, commandType: CommandType.StoredProcedure);
                }
                catch (Exception e)
                {
                    DataHandler.ErrorLogException = e;
                    return -1;
                }
            }
        }
    }
}
