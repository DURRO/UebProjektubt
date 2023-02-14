using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace Projekt3.Pages.Client
{
    public class showProjectModel : PageModel
    {
        public List<ProjectInfo> listProject = new List<ProjectInfo>();

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source= DESKTOP-5Q45F4E;Initial Catalog=StudProjektSQL;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM projektet";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProjectInfo projectInfo = new ProjectInfo();
                                projectInfo.id = "" + reader.GetInt32(0);
                                projectInfo.title = "" + reader.GetString(1);
                                projectInfo.project_manager = "" + reader.GetString(2);
                                projectInfo.status = "" + reader.GetString(3);
                                projectInfo.salary = "" + reader.GetString(4);

                                listProject.Add(projectInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("(Exeption:" + ex.ToString());
            }
        }
    }

    public class ProjectInfo
    {
            public String id;
            public String title;
            public String project_manager;
            public String status;
            public String salary;
    }
}
