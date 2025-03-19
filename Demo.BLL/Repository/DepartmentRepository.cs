using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repository
{
    public class DepartmentRepository :IDepartmentRepository
    {
        private readonly AppDbContext dbContext;

        //GetAll Department, GetById, Delete, Create, Update
        //Dependancy Injection
        //FirstWay
        //[FromService]
        //Prop
        //Second Way
        //Function([FromService]arg)
        //Third Way
        //Constructor

        public DepartmentRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Department> GetAll()
        {
       
            var Departments=dbContext.Departments.ToList();
            return Departments;
        }
        public Department? GetById(int id)
            =>dbContext.Departments.Find(id);

        public void Delete(Department department)
        {

            dbContext.Departments.Remove(department);
            dbContext.SaveChanges();
        }

        public void Add(Department department)
        {
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
        }
        
        public void Update(Department department)
        {
            dbContext.Departments.Update(department);
            dbContext.SaveChanges();
        }
    }
}
