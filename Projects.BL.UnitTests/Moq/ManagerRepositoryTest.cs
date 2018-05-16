﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.DAL.Repositories;
using Projects.DAL.Domain;
using System.Data.SqlClient;
using System.Data;

namespace Projects.BL.UnitTests.Moq
{
    public class ManagerRepositoryTest:IRepository<Manager>
    {
        SqlConnection sqlConnection;

        public ManagerRepositoryTest()
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
C:\Users\Олег\source\repos\Projects\Projects.BL.UnitTests\TestDB.mdf;Integrated Security=True;Connect Timeout=30";

            sqlConnection = new SqlConnection(connectionstring);

            sqlConnection.Open();

        }

        public ManagerRepositoryTest(string connectionstring)
        {

            sqlConnection = new SqlConnection(connectionstring);

            sqlConnection.Open();

        }

        public void Close()
        {
            sqlConnection.Close();
        }

        public void Create(Manager item)
        {
            string sqlString = "Insert into Manager (Id,Name) values(@Id,@Name)";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            string sqlString = "Delete FROM Manager WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public Manager Get(int id)
        {
            string sqlString = "Select * from Manager WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var manager = new Manager();
                    manager.Id = reader.GetInt32(0);
                    manager.Name = reader.GetString(1);
                    return manager;
                }
                else
                {
                    throw new System.InvalidOperationException("Cannot get Manager with id=" + id.ToString());
                }
            }
        }

        public IEnumerable<Manager> GetAll()
        {
            string sqlString = "Select * from Project";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var manager = new Manager();
                    manager.Id = reader.GetInt32(0);
                    manager.Name = reader.GetString(1);
                    yield return manager;
                }
            }

        }

        public void Update(Manager item)
        {
            string sqlString = "UPDATE Manager SET Name=@Name WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.ExecuteNonQuery();
        }
    }
}