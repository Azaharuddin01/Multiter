using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using CommanLayer.Models;

namespace DataAccessLayer
{
   public class EmployeeDataAccessDb
    {
        private DbConnection db = new DbConnection();

        public List<Employees> GetEmployees()
        {
            string query = "select* from employees";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> employees = new List<Employees>();
            while(reader.Read())
            {
                Employees emp = new Employees();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Address = reader["Address"].ToString();
                employees.Add(emp);
            }
            db.Cnn.Close();
            return employees;
        }


        public Employees GetEmployeesById(int Id)
        {
            string query = "select* from employees where Id=" +Id+"";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = db.Cnn;
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
           
                Employees emp = new Employees();
                emp.Id = (int)reader["Id"];
                emp.Name = reader["Name"].ToString();
                emp.Email = reader["Email"].ToString();
                emp.Mobile = reader["Mobile"].ToString();
                emp.Address = reader["Address"].ToString();

            db.Cnn.Close();
            return emp;
        }

        public bool CreateEmployee(Employees employee)
        {
            string query="insert into Employees values('"+employee.Name+"','"+
                employee.Email+"','"+employee.Mobile+"','"+employee.Address+"')";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool UpdateEmployee(Employees employee)
        {
            string query = "update Employees set Name=" + employee.Name + ",Email=" + employee.Email + "" +
                ",Mobile=" + employee.Name + ",Address=" + employee.Name + "where Id=" + employee.Id + "";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

        public bool DeleteEmployee(int id)
        {
            string query = "delete from Employees where id=" + id + "";
            SqlCommand cmd = new SqlCommand(query, db.Cnn);
            if (db.Cnn.State == System.Data.ConnectionState.Closed)
                db.Cnn.Open();
            int i = cmd.ExecuteNonQuery();
            db.Cnn.Close();
            return Convert.ToBoolean(i);
        }

       
    }
}
