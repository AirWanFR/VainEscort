using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class EmployeDAL
    {
        private string _conn = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable GetAll()
        {
            DataTable dt = new DataTable();
            using (SqlConnection c = new SqlConnection(_conn))
            {
                new SqlDataAdapter("SELECT ID_Employe, Prenom, Nom, Actif FROM Employes", c).Fill(dt);
            }
            return dt;
        }

        public bool Insert(string prenom, string nom)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Employes (Prenom, Nom, Actif) VALUES (@p, @n, 1)", c);
                cmd.Parameters.AddWithValue("@p", prenom);
                cmd.Parameters.AddWithValue("@n", nom);
                c.Open(); return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(int id, string prenom, string nom)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employes SET Prenom=@p, Nom=@n WHERE ID_Employe=@id", c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@p", prenom);
                cmd.Parameters.AddWithValue("@n", nom);
                c.Open(); return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employes WHERE ID_Employe=@id", c);
                cmd.Parameters.AddWithValue("@id", id);
                c.Open(); return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}