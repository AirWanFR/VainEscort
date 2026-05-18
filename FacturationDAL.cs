using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class FacturationDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Récupère uniquement les prestations non facturées (EstFacture = 0)
        // Trié par client pour faciliter le traitement par dictionnaire
        public DataTable GetPrestationsAFacturer()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.ID_Prestation, p.DatePrestation, 
                               c.Nom + ' ' + c.Prenom AS Client, 
                               e.Nom + ' ' + e.Prenom AS [Employé], 
                               t.Libelle AS Type, p.DureeHeures,
                               (p.DureeHeures * t.TarifHoraire) AS MontantApaye
                               FROM Prestations p
                               JOIN Clients c ON p.ID_Client = c.ID_Client
                               JOIN Employes e ON p.ID_Employe = e.ID_Employe
                               JOIN TypePrestations t ON p.ID_Type = t.ID_Type
                               WHERE p.EstFacture = 0
                               ORDER BY c.Nom, p.DatePrestation DESC";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        // Met à jour la prestation en base de données pour la marquer comme payée/facturée
        public bool ValiderFacturePrestation(int idPrestation)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "UPDATE Prestations SET EstFacture = 1, DateFacturation = @date WHERE ID_Prestation = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", idPrestation);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}