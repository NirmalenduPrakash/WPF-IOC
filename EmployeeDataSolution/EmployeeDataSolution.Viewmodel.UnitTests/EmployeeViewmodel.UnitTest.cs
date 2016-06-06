using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeDataSolution.Viewmodel;
using EmployeeDataSolution.Model;
using System.Collections.ObjectModel;

namespace EmployeeDataSolution.Viewmodel.UnitTests
{
    [TestClass]
    public class EmployeeViewmodelUT
    {
        [TestMethod]
        public void testAddEmployee_NegativeIdValue_EmployeeCountConstant()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee = new EmployeeBE();
            employee.Id = "-1001";
            employee.Name ="Nirmal";
            employee.Age = "28";
            employeeViewmodel.AddEmployee(employee);
            Assert.AreEqual(0, employeeViewmodel.EmployeeList.Count);
        }

        [TestMethod]
        public void testAddEmployee_NegativeAgeValue_EmployeeCountConstant()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee = new EmployeeBE();
            employee.Id = "1001";
            employee.Name = "Nirmal";
            employee.Age = "-28";
            employeeViewmodel.AddEmployee(employee);
            Assert.AreEqual(0, employeeViewmodel.EmployeeList.Count);
        }

        [TestMethod]
        public void testAddEmployee_NameContainingUnderscore_EmployeeCountConstant()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee = new EmployeeBE();
            employee.Id = "1001";
            employee.Name = "Nirmal_P";
            employee.Age = "28";
            employeeViewmodel.AddEmployee(employee);
            Assert.AreEqual(0, employeeViewmodel.EmployeeList.Count);
        }

        [TestMethod]
        public void testAddEmployee_NameAgeIdBlank_EmployeeCountConstant()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee = new EmployeeBE();
            employee.Id = "";
            employee.Name = "";
            employee.Id = "";
            employeeViewmodel.AddEmployee(employee);
            Assert.AreEqual(0, employeeViewmodel.EmployeeList.Count);
        }

        [TestMethod]
        public void testAddEmployee_NameIdAgeCorrectValues_EmployeeCountIncreased()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee = new EmployeeBE();
            employee.Id = "1001";
            employee.Name = "Nirmal";
            employee.Age = "28";
            employeeViewmodel.AddEmployee(employee);
            Assert.AreEqual(1, employeeViewmodel.EmployeeList.Count);
        }

        [TestMethod]
        public void testAddEmployee_Add3EmployeesValidValues_EmployeeCountIncreasedBy3()
        {
            EmployeeViewmodel employeeViewmodel = new EmployeeViewmodel();
            employeeViewmodel.EmployeeList = new ObservableCollection<EmployeeBE>();
            EmployeeBE employee1 = new EmployeeBE();
            employee1.Id = "1001";
            employee1.Name = "Nirmal";
            employee1.Age = "28";
            employeeViewmodel.AddEmployee(employee1);
            EmployeeBE employee2 = new EmployeeBE();
            employee2.Id = "1002";
            employee2.Name = "John";
            employee2.Age = "35";
            employeeViewmodel.AddEmployee(employee2);
            EmployeeBE employee3 = new EmployeeBE();
            employee3.Id = "1003";
            employee3.Name = "Sarah";
            employee3.Age = "25";
            employeeViewmodel.AddEmployee(employee3);
            Assert.AreEqual(3, employeeViewmodel.EmployeeList.Count);
        }
    }
}
