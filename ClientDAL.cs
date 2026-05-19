using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class ClientDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable GetEmployesActifs()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Employe, Nom + ' ' + Prenom AS NomComplet FROM Employes WHERE Actif = 1";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public DataTable GetAllClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Ajout de Telephone et Email
                string sql = @"SELECT c.ID_Client, c.Prenom, c.Nom, c.Telephone, c.Email, 
                               e.Nom + ' ' + e.Prenom AS [Employé Attitré], c.EstAttitreA AS Employe_ID_Hidden
                               FROM Clients c
                               LEFT JOIN Employes e ON c.EstAttitreA = e.ID_Employe";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public bool Insert(string prenom, string nom, string telephone, string email, int idEmp)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Clients (Prenom, Nom, Telephone, Email, EstAttitreA) VALUES (@prenom, @nom, @tel, @email, @idEmp)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@tel", (object)telephone ?? DBNull.Value); // Gère les champs vides
                cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idEmp", idEmp);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(int idClient, string prenom, string nom, string telephone, string email, int idEmp)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Clients SET Prenom = @prenom, Nom = @nom, Telephone = @tel, Email = @email, EstAttitreA = @idEmp WHERE ID_Client = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idClient);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@tel", (object)telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@idEmp", idEmp);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int idClient)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Clients WHERE ID_Client = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idClient);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}