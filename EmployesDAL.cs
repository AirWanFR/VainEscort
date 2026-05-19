using System;
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
                // On garde 'Actif' dans le SELECT pour l'afficher ou l'exploiter
                new SqlDataAdapter("SELECT ID_Employe, Prenom, Nom, Telephone, Email, Actif FROM Employes", c).Fill(dt);
            }
            return dt;
        }

        public bool Insert(string prenom, string nom, string telephone, string email)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                string sql = "INSERT INTO Employes (Prenom, Nom, Telephone, Email, Actif) VALUES (@p, @n, @t, @e, 1)";
                SqlCommand cmd = new SqlCommand(sql, c);
                cmd.Parameters.AddWithValue("@p", prenom);
                cmd.Parameters.AddWithValue("@n", nom);
                cmd.Parameters.AddWithValue("@t", (object)telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)email ?? DBNull.Value);
                c.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // CORRECTION : Prise en compte du paramètre 'actif'
        public bool Update(int id, string prenom, string nom, string telephone, string email, bool actif)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                string sql = "UPDATE Employes SET Prenom=@p, Nom=@n, Telephone=@t, Email=@e, Actif=@actif WHERE ID_Employe=@id";
                SqlCommand cmd = new SqlCommand(sql, c);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@p", prenom);
                cmd.Parameters.AddWithValue("@n", nom);
                cmd.Parameters.AddWithValue("@t", (object)telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@e", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@actif", actif); // Sauvegarde du statut 0 ou 1
                c.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (SqlConnection c = new SqlConnection(_conn))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Employes WHERE ID_Employe=@id", c);
                cmd.Parameters.AddWithValue("@id", id);
                c.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}