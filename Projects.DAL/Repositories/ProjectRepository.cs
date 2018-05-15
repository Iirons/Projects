using Projects.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Projects.DAL.Repositories
{
    class ProjectRepository : IRepository<Project>
    {
        SqlConnection sqlConnection;

        public ProjectRepository()
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=
            C:\Users\Олег\source\repos\Projects\Projects.DAL\Projects.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionstring);

            sqlConnection.Open();
            
        }

        public void Close()
        {
            sqlConnection.Close();
        }

        public void Create(Project item)
        {
            string sqlString = "Insert into Project (Name,ManagerId) "
            + "values(@Name,@ManagerId)";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@ManagerId", item.ManagerId);
            command.ExecuteNonQuery();

        }

        public void Delete(int id)
        {
            string sqlString = "Delete FROM Project WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public Project Get(int id)
        {
            string sqlString = "Select * from Project WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    var projects = new Project();
                    projects.Id = reader.GetInt32(0);
                    projects.Name = reader.GetString(1);
                    projects.ManagerId = reader.GetInt32(2);
                    return projects;
                }
                else
                {
                    throw new System.InvalidOperationException("Cannot get project with id=" +id.ToString());
                }
            }
        }

        public IEnumerable<Project> GetAll()
        {
            string sqlString = "Select * from Project";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var projects = new Project();
                    projects.Id = reader.GetInt32(0);
                    projects.Name = reader.GetString(1);
                    projects.ManagerId = reader.GetInt32(2);
                    yield return projects;
                }
            }
            
        }

        public void Update(Project item)
        {
            string sqlString = "UPDATE Project SET Name=@Name,ManagerId=@ManagerId WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@ManagerId",item.ManagerId);
            command.ExecuteNonQuery();
        }
    }
}
