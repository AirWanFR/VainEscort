using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class CatalogueDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // Récupère tous les types de prestations disponibles
        public DataTable GetTypesPrestations()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Type, Libelle, TarifHoraire FROM TypePrestations ORDER BY Libelle ASC";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        // Récupère tous les employés actifs
        public DataTable GetEmployesActifs()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT ID_Employe, Nom + ' ' + Prenom AS NomComplet, Email, Telephone FROM Employes WHERE Actif = 1 ORDER BY Nom ASC";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }
    }
}