using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.DataLayar
{
    public class EmployeeValidation
    {
        public List<string>  Erorrs= new List<string>();
        public void Check(Employee employee)
        {
            Erorrs.Clear();
            if (employee.FirstName.Length < 3)
            {
                if (string.IsNullOrEmpty(employee.FirstName))
                    Erorrs.Add("The First Name can't be Empty");
                else Erorrs.Add("The First Name can't be less then 3 letters");
            }
            if (string.IsNullOrEmpty(employee.LastName))
                Erorrs.Add("The Last Name can't be empty");
            if (employee.Salary < 0)
                Erorrs.Add("The Salary Can't be Less then 0");
            if (string.IsNullOrEmpty(employee.StartDate))
                Erorrs.Add("The Start Data can't be empty");
        }
        public bool IsValid()
        {
            return Erorrs.Count == 0;
        }
    }
}
