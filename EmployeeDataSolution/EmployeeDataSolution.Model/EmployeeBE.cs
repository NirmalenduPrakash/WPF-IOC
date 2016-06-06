using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace EmployeeDataSolution.Model
{
    public class EmployeeBE : IDataErrorInfo, INotifyPropertyChanged
    {
        #region variables
        private string id;
        private string age;
        private string name;
        private Dictionary<string, List<string>> errorList;
        #endregion

        #region Constructor
        public EmployeeBE()
        {
            errorList = new Dictionary<string, List<string>>();
        }
        #endregion

        #region Properties
        public string Id
        {
            get { return id; }
            set
            {
                ValidateEmptyString(value, "Id");
                ValidatePositiveInteger(value, "Id");
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                ValidateEmptyString(value, "Age");
                ValidatePositiveInteger(value, "Age");
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                ValidateEmptyString(value, "Name");
                ValidateName(value, "Name");
                name = value;
                OnPropertyChanged("Name");
            }
        }
        #endregion

        #region PropertyChnaged
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region constants
        private const string negativeIntegerMessage = "Please enter a non-negative value.";
        private const string speciCharacterMessage = "Special characters are not allowed.";
        #endregion

        #region error handling
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public bool HasError
        {
            get { return errorList.Count > 0; }
        }

        public string this[string columnName]
        {
            get
            {
                return GetError(columnName);
            }
        }

        public string GetError(string propertyName)
        {
            string error=null;
            if (errorList.ContainsKey(propertyName))
            {
                error = errorList[propertyName][errorList[propertyName].Count - 1];
            }
            return error;
        }

        public string ValidatePositiveInteger(string value,string propertyName)
        {
            int result;
            string errorMsg = string.Empty;
            if (!int.TryParse(value, out result) || result < 0)
            {
                errorMsg = negativeIntegerMessage;
                AddError(propertyName,errorMsg);
            }
            else
            {
                RemoveError(propertyName, errorMsg);
            }
            return errorMsg;
        }

        public string ValidateName(string value,string propertyName)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s]+$");
            string errorMsg = string.Empty;
            if (!regex.IsMatch(value))
            {
                errorMsg = speciCharacterMessage;
                AddError(propertyName, errorMsg);
            }
            else
            {
                RemoveError(propertyName, errorMsg);
            }
            return errorMsg;
        }

        public string ValidateEmptyString(string value, string propertyName)
        {
            string errorMsg = string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                errorMsg = negativeIntegerMessage;
                AddError(propertyName, errorMsg);
            }
            else
            {
                RemoveError(propertyName, errorMsg);
            }
            return errorMsg;
        }

        private void AddError(string propertyName, string errorMessage)
        {
            if (errorList.ContainsKey(propertyName))
            {
                if (errorList[propertyName].Where(msg=>msg.Equals(errorMessage)).FirstOrDefault()==null)
                    errorList[propertyName].Add(errorMessage);
            }
            else
                errorList.Add(propertyName, new List<string>() { errorMessage });
        }

        private void RemoveError(string propertyName,string errorMessage)
        {
            if (errorList.ContainsKey(propertyName))
            {
                errorList[propertyName].Remove(errorMessage);
                if (errorList[propertyName].Count != 0)
                {
                    errorList.Remove(propertyName);
                }
            }
        }
        #endregion        
    }
}
