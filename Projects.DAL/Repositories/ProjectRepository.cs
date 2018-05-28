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
    public class ProjectRepository : IRepository<Project>
    {
        SqlConnection sqlConnection;

        public ProjectRepository()
        {
            string connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Олег\source\repos\Projects\Projects.DAL\Projects.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionstring);
        }

        public void Create(Project item)
        {
            sqlConnection.Open();
            string sqlString = "Insert into Project (Id,Name,ManagerId,Description,ProjectStart,ProjectEnd) "
            + "values(@Id,@Name,@ManagerId,@Description,@ProjectStart,@ProjectEnd)";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@Id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@ManagerId", item.ManagerId);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@ProjectStart", item.ProjectStart);
            command.Parameters.AddWithValue("@ProjectEnd", item.ProjectEnd);
            command.ExecuteNonQuery();
            sqlConnection.Close();

        }

        public void Delete(int id)
        {
            sqlConnection.Open();
            string sqlString = "Delete FROM Project WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Project Get(int id)
        {
            sqlConnection.Open();
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
                    projects.ProjectStart = reader.GetDateTime(3);
                    projects.ProjectEnd = reader.GetDateTime(4);
                    projects.Description = reader.GetString(5);
                    sqlConnection.Close();
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
            sqlConnection.Open();
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
                    projects.ProjectStart = reader.GetDateTime(3);
                    projects.ProjectEnd = reader.GetDateTime(4);
                    projects.Description = reader.GetString(5);
                    yield return projects;
                }
            }
            sqlConnection.Close();
        }

        public void Update(Project item)
        {
            sqlConnection.Open();
            string sqlString = "UPDATE Project SET Name=@Name,ManagerId=@ManagerId,Description=@Description,ProjectStart=@ProjectStart," +
                "ProjectEnd=@ProjectEnd WHERE id=@id";
            SqlCommand command = new SqlCommand(sqlString, sqlConnection);
            command.Parameters.AddWithValue("@id", item.Id);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@ManagerId",item.ManagerId);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@ProjectStart", item.ProjectStart);
            command.Parameters.AddWithValue("@ProjectEnd", item.ProjectEnd);
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
