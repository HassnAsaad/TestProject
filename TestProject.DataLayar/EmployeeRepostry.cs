using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestProject.DataLayar
{

    public class EmployeeRepostry
    {
        //for test porpos

        private EmployeeContext _Db = new EmployeeContext();
        public List<Employee> GetAll()
        {
            return _Db.Employees.ToList();
        }

        public void Add(Employee newemployee)
        {


            _Db.Add(newemployee);
            _Db.SaveChanges();

        }

        public void Update(Employee update, int wantedId)
        {

            var updatedemployee = _Db.Employees.FirstOrDefault(x => x.EmployeeId == wantedId);
            updatedemployee.FirstName = update.FirstName;
            updatedemployee.LastName = update.LastName;
            updatedemployee.Salary = update.Salary;
            updatedemployee.StartDate = update.StartDate;
            _Db.SaveChanges();

        }

        public void Delete(int deletedId)
        {
            var deletedemployee = _Db.Employees.FirstOrDefault(x => x.EmployeeId == deletedId);
            _Db.Remove(deletedemployee);
            _Db.SaveChanges();
        }

    }
}
