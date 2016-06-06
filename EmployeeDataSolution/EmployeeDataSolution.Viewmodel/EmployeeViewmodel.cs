using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDataSolution.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace EmployeeDataSolution.Viewmodel
{
    public class EmployeeViewmodel : INotifyPropertyChanged
    {
        #region variables
        private EmployeeBE employee;
        private bool isAgeChecked;
        private bool showMessage;
        private ObservableCollection<EmployeeBE> employeeList;
        # endregion

        #region Properties
        public bool ShowMessage
        {
            get { return showMessage; }
            set
            {
                showMessage = value;
                OnPropertyChanged("ShowMessage");
            }
        }

        public string Message
        {
            get { return "Please check highlighted fields."; }
        }
        public bool IsAgeChecked
        {
            get { return isAgeChecked; }
            set
            {
                isAgeChecked = value;
                OnPropertyChanged("IsAgeChecked");
            }
        }

        public EmployeeBE Employee
        {
            get { return employee; }
            set { employee = value; }
        }        

        public ObservableCollection<EmployeeBE> EmployeeList
        {
            get { return employeeList; }
            set
            {
                employeeList = value;
            }
        }

        public ICommand AddEmployeeCommand { get; set; }
        # endregion

        #region constructor
        public EmployeeViewmodel()
        {
            employee = new EmployeeBE();
            WireCommands();
            EmployeeList = new ObservableCollection<EmployeeBE>();
        }
        #endregion

        #region methods
        public void WireCommands()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee);
        }

        public void AddEmployee()
        {
            AddEmployee(Employee);
        }

        public void AddEmployee(EmployeeBE employee)
        {
            //check if employee has any validation error or properties are null
            if (!employee.HasError &&
                !string.IsNullOrEmpty(employee.Id)
                && !string.IsNullOrEmpty(employee.Age)
                && !string.IsNullOrEmpty(employee.Name))
            {
                EmployeeList.Add(employee);
            }
            else
            {
                ShowMessage = true;
            }
        }
        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged!=null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
