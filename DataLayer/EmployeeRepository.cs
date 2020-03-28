using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLModel;

namespace DataLayer
{
    public class EmployeeRepository
    {
        public int AddEmployee(EmployeeModel model)
        {
            using (var dbContext = new DBFirstEmployeeEntities())
            {
                Employee emp = new Employee()
                {
                    first_name = model.first_name,
                    last_name = model.last_name,
                    email = model.email,
                    address_id = model.address_id,
                    emp_code = model.emp_code
                };

                if (model.Address != null)
                {
                    emp.Address = new Address()
                    {
                        address1 = model.Address.address1,
                        city = model.Address.city,
                        state = model.Address.state,
                        country = model.Address.country
                    };
                }

                dbContext.Employee.Add(emp);
                dbContext.SaveChanges();

                return emp.id;
            }
        }

        public List<EmployeeModel> showAllEmployees()
        {
            using (var dbContext = new DBFirstEmployeeEntities())
            {
                var result = dbContext.Employee
                     .Select(x => new EmployeeModel()
                     {
                         id = x.id,
                         first_name = x.first_name,
                         last_name = x.last_name,
                         email = x.email,
                         emp_code = x.emp_code,
                         address_id = x.address_id,
                         Address = new AddressModel()
                         {
                             address1 = x.Address.address1,
                             city = x.Address.city,
                             state = x.Address.state,
                             country = x.Address.country
                         }
                     }).ToList();

                return result;

            }


        }

        public EmployeeModel GetEmployee( int id)
        {
            using (var dbContext = new DBFirstEmployeeEntities())
            {
                var result = dbContext.Employee
                    .Where(x => x.id == id)
                     .Select(x => new EmployeeModel()
                     {
                         id = x.id,
                         first_name = x.first_name,
                         last_name = x.last_name,
                         email = x.email,
                         emp_code = x.emp_code,
                         address_id = x.address_id,
                         Address = new AddressModel()
                         {
                             address1 = x.Address.address1,
                             city = x.Address.city,
                             state = x.Address.state,
                             country = x.Address.country
                         }
                     }).FirstOrDefault();

                return result;

            }


        }

        public bool UpdateEmployee(EmployeeModel model)
        {
            using (var dbContext = new DBFirstEmployeeEntities())
            {
                var employee = dbContext.Employee.FirstOrDefault(x => x.id == model.id); // db hit one time

                if (employee != null)
                {
                    employee.first_name = model.first_name;
                    employee.last_name = model.last_name;
                    employee.email = model.email;
                    employee.emp_code = model.emp_code;
                    employee.Address.address1 = model.Address.address1;
                    employee.Address.city = model.Address.city;
                    employee.Address.state = model.Address.state;
                    employee.Address.country = model.Address.country;
                }

                int val = dbContext.SaveChanges(); // db hit 2nd time , you can update employee in 1 db hit only by changing the state of entity. see delete function

                if (val > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var dbContext = new DBFirstEmployeeEntities())
            {
                //var employee = dbContext.Employee.FirstOrDefault(x => x.id == id); 

                //dbContext.Employee.Remove(employee);
                //dbContext.SaveChanges();

                //Above code hit database 2 times. let see how to delete employee in only one db hit
                // We have to change the state of entity manualy

                var employee = new Employee()
                {
                    id=id
                };

                dbContext.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();
                return true;
            }
        }
    }
}
