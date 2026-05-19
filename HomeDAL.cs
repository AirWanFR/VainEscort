using System.Data;
using Microsoft.Data.SqlClient;

namespace VainEscort.DAL
{
    public class DashboardDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public DataTable SelectDernieresPrestations()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"SELECT p.DatePrestation, c.Nom AS Client, e.Nom + ' ' + e.Prenom AS [Employé Attitré], p.EstFacture
                       FROM Prestations p
                       JOIN Clients c ON p.ID_Client = c.ID_Client
                       JOIN Employes e ON p.ID_Employe = e.ID_Employe 
                       ORDER BY p.DatePrestation DESC";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SelectPrestationsAByEtat(bool estFacture)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Prestations WHERE EstFacture = @etat";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@etat", estFacture);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SelectAllEmployes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // On utilise 'Actif' à la place de 'Specialite'
                string sql = "SELECT Nom, Prenom, Actif FROM Employes";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SelectAllClients()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // ISNULL remplace la valeur null par "Aucun(e)"
                string sql = @"SELECT c.Nom, c.Prenom, c.Telephone, 
                       ISNULL(e.Nom + ' ' + e.Prenom, 'Aucun(e)') AS [Employé Attitré]
                       FROM Clients c
                       LEFT JOIN Employes e ON c.EstAttitreA = e.ID_Employe";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public bool TesterConnexion()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}