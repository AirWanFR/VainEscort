using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class ClientDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Récupère la liste des employés actifs pour remplir la ComboBox à droite
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

        // Récupère tous les clients avec les infos de l'employé attitré
        public DataTable GetAllClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // CORRECTION : Utilisation de "EstAttitreA" pour la table Clients
                string sql = @"SELECT c.ID_Client, c.Prenom, c.Nom, 
                               e.Nom + ' ' + e.Prenom AS [Employé Attitré], c.EstAttitreA AS Employe_ID_Hidden
                               FROM Clients c
                               LEFT JOIN Employes e ON c.EstAttitreA = e.ID_Employe";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        public bool Insert(string prenom, string nom, int idEmp)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // CORRECTION : Utilisation de "EstAttitreA"
                string sql = "INSERT INTO Clients (Prenom, Nom, EstAttitreA) VALUES (@prenom, @nom, @idEmp)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@idEmp", idEmp);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(int idClient, string prenom, string nom, int idEmp)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // CORRECTION : Utilisation de "EstAttitreA"
                string sql = "UPDATE Clients SET Prenom = @prenom, Nom = @nom, EstAttitreA = @idEmp WHERE ID_Client = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idClient);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@nom", nom);
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