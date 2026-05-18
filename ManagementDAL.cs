using System;
using System.Data;
using Microsoft.Data.SqlClient; // Le nouveau standard Microsoft

namespace VainEscort.DAL
{
    public class ManagementDAL
    {
        private string _connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=GestionEscortDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // --- 1. Chiffre d'Affaire Mensuel ---
        public DataTable GetChiffreAffairesMensuel()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT 
                        FORMAT(p.DatePrestation, 'yyyy-MM') AS Mois,
                        SUM(p.DureeHeures * tp.TarifHoraire) AS ChiffreAffaires
                    FROM Prestations p
                    INNER JOIN TypePrestations tp ON p.ID_Type = tp.ID_Type
                    WHERE p.EstFacture = 1
                    GROUP BY FORMAT(p.DatePrestation, 'yyyy-MM')
                    ORDER BY Mois ASC;";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        // --- 2. Rentabilité par Employé ---
        public DataTable GetRentabiliteEmployes()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT 
                        e.Nom + ' ' + e.Prenom AS Employe,
                        SUM(p.DureeHeures) AS HeuresPrestees,
                        SUM(p.DureeHeures * tp.TarifHoraire) AS TotalGenere
                    FROM Employes e
                    LEFT JOIN Prestations p ON e.ID_Employe = p.ID_Employe
                    LEFT JOIN TypePrestations tp ON p.ID_Type = tp.ID_Type
                    GROUP BY e.Nom, e.Prenom
                    ORDER BY TotalGenere DESC;";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }

        // --- 3. Liste des Clients Attitrés ---
        public DataTable GetClientsAttitres()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string sql = @"
                    SELECT 
                        e.Nom + ' ' + e.Prenom AS Employe,
                        c.Nom + ' ' + c.Prenom AS Client,
                        c.Telephone AS TelephoneClient,
                        c.Email AS EmailClient
                    FROM Clients c
                    INNER JOIN Employes e ON c.EstAttitreA = e.ID_Employe
                    ORDER BY e.Nom, c.Nom;";
                new SqlDataAdapter(sql, conn).Fill(dt);
            }
            return dt;
        }
    }
}