using System.Data.SqlClient;

namespace CM.TeamRepots.DataLayer.Repositories
{
    public class BaseRepository
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=TeamReport;Integrated Security=True");
        }
    }
}
