using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class PrestaDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // --- CATALOGUES POUR LES COMBOS ---
        public DataTable GetEmployes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Employe, Nom + ' ' + Prenom AS Affichage FROM Employes WHERE Actif = 1";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public DataTable GetClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Client, Nom + ' ' + Prenom AS Affichage FROM Clients";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public DataTable GetTypes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Type, Libelle FROM TypePrestations";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        // --- GESTION DES PRESTATIONS (CRUD) ---
        public DataTable GetAllPrestations()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Sélection avec alias propres et les IDs d'origines masqués pour l'UI
                string sql = @"SELECT p.ID_Prestation, p.DatePrestation, 
                               c.Nom + ' ' + c.Prenom AS Client, p.ID_Client AS Client_ID_Hidden,
                               e.Nom + ' ' + e.Prenom AS [Employé], p.ID_Employe AS Employe_ID_Hidden,
                               t.Libelle AS Type, p.DureeHeures
                               FROM Prestations p
                               JOIN Clients c ON p.ID_Client = c.ID_Client
                               JOIN Employes e ON p.ID_Employe = e.ID_Employe
                               JOIN TypePrestations t ON p.ID_Type = t.ID_Type
                               ORDER BY p.DatePrestation DESC";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public bool Insert(int idEmp, int idCli, int idType, DateTime date, decimal duree)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "INSERT INTO Prestations (ID_Employe, ID_Client, ID_Type, DatePrestation, DureeHeures, EstFacture) VALUES (@e,@c,@t,@d,@h,0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@e", idEmp);
                cmd.Parameters.AddWithValue("@c", idCli);
                cmd.Parameters.AddWithValue("@t", idType);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@h", duree);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(int idPresta, int idEmp, int idCli, int idType, DateTime date, decimal duree)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"UPDATE Prestations 
                               SET ID_Employe = @e, ID_Client = @c, ID_Type = @t, DatePrestation = @d, DureeHeures = @h 
                               WHERE ID_Prestation = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idPresta);
                cmd.Parameters.AddWithValue("@e", idEmp);
                cmd.Parameters.AddWithValue("@c", idCli);
                cmd.Parameters.AddWithValue("@t", idType);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@h", duree);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int idPresta)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "DELETE FROM Prestations WHERE ID_Prestation = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idPresta);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}