using System.Data.SqlClient;

namespace AM.Data
{
    public class DAL
    {
        protected SqlConnection Con;
        protected SqlCommand Cmd;
        protected SqlDataReader Dr;
        protected SqlTransaction Tr;
        protected void OpenConnection()
        {
            Con = new SqlConnection("Data Source=prd-sql-avantti.kxc.com.br;Initial Catalog=MEDICOES;Persist Security Info=True;User ID=prisma;Password=avanttisql");
            Con.Open();
        }
    }
}
