using System;
using System.Data;
using System.Text;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class CatalogueManager
    {
        private CatalogueDAL _dal = new CatalogueDAL();

        // Génère le code HTML complet et dynamique du catalogue
        public string GenererCatalogueHTML()
        {
            DataTable dtTypes = _dal.GetTypesPrestations();
            DataTable dtEmployes = _dal.GetEmployesActifs();

            StringBuilder html = new StringBuilder();

            // Structure HTML avec style CSS moderne embarqué (Violet et Bleu)
            html.Append("<!DOCTYPE html>");
            html.Append("<html lang='fr'>");
            html.Append("<head>");
            html.Append("    <meta charset='UTF-8'>");
            html.Append("    <style>");
            html.Append("        body { font-family: 'Segoe UI', Arial, sans-serif; color: #2d3748; margin: 20px; background-color: #f7fafc; }");
            html.Append("        .header { border-bottom: 3px solid #ffd700; padding-bottom: 15px; margin-bottom: 30px; }");
            html.Append("        h1 { color: #800080; margin: 0; font-size: 28px; text-transform: uppercase; letter-spacing: 1px; }");
            html.Append("        h2 { color: #1a365d; border-left: 4px solid #800080; padding-left: 10px; margin-top: 30px; font-size: 20px; }");
            html.Append("        .subtitle { color: #4a5568; font-style: italic; margin-top: 5px; }");
            html.Append("        table { width: 100%; border-collapse: collapse; margin-top: 15px; background: #ffffff; box-shadow: 0 2px 4px rgba(0,0,0,0.05); border-radius: 4px; overflow: hidden; }");
            html.Append("        th { background-color: #1a365d; color: #ffffff; padding: 12px; text-align: left; font-weight: bold; }");
            html.Append("        td { padding: 12px; border-bottom: 1px solid #e2e8f0; }");
            html.Append("        tr:nth-child(even) { background-color: #f8fafc; }");
            html.Append("        .price { font-weight: bold; color: #800080; text-align: right; }");
            html.Append("        .text-right { text-align: right; }");
            html.Append("        .badge { background-color: #edf2f7; color: #2d3748; padding: 4px 8px; border-radius: 12px; font-size: 12px; font-weight: 600; }");
            html.Append("        .footer { margin-top: 40px; text-align: center; font-size: 12px; color: #a0aec0; border-top: 1px solid #e2e8f0; padding-top: 15px; }");
            html.Append("    </style>");
            html.Append("</head>");
            html.Append("<body>");

            // En-tête
            html.Append("    <div class='header'>");
            html.Append("        <h1>VainEscort S.A.</h1>");
            html.Append("        <div class='subtitle'>Catalogue Web Officiel des Prestations & Équipe Connectée</div>");
            html.Append("    </div>");

            // Section 1 : Prestations possibles
            html.Append("    <h2>1. Nos Prestations Disponibles</h2>");
            html.Append("    <table>");
            html.Append("        <thead>");
            html.Append("            <tr>");
            html.Append("                <th>Type de Prestation</th>");
            html.Append("                <th class='text-right'>Tarif Horaire</th>");
            html.Append("            </tr>");
            html.Append("        </thead>");
            html.Append("        <tbody>");

            if (dtTypes.Rows.Count == 0)
            {
                html.Append("            <tr><td colspan='2' style='text-align:center; color:#718096;'>Aucune prestation configurée en base de données.</td></tr>");
            }
            else
            {
                foreach (DataRow row in dtTypes.Rows)
                {
                    string libelle = row["Libelle"]?.ToString() ?? "";
                    decimal tarif = row["TarifHoraire"] != DBNull.Value ? Convert.ToDecimal(row["TarifHoraire"]) : 0m;

                    html.Append("            <tr>");
                    html.Append($"                <td><strong>{libelle}</strong></td>");
                    html.Append($"                <td class='price'>{tarif:0.00} € / h</td>");
                    html.Append("            </tr>");
                }
            }
            html.Append("        </tbody>");
            html.Append("    </table>");

            // Section 2 : Équipe
            html.Append("    <h2>2. Notre Équipe d'Élite</h2>");
            html.Append("    <table>");
            html.Append("        <thead>");
            html.Append("            <tr>");
            html.Append("                <th>Nom & Prénom</th>");
            html.Append("                <th>Adresse E-mail</th>");
            html.Append("                <th>Téléphone</th>");
            html.Append("                <th class='text-right'>Disponibilité</th>");
            html.Append("            </tr>");
            html.Append("        </thead>");
            html.Append("        <tbody>");

            if (dtEmployes.Rows.Count == 0)
            {
                html.Append("            <tr><td colspan='4' style='text-align:center; color:#718096;'>Aucun membre du personnel actif actuellement.</td></tr>");
            }
            else
            {
                foreach (DataRow row in dtEmployes.Rows)
                {
                    string nomComplet = row["NomComplet"]?.ToString() ?? "";
                    string email = row["Email"]?.ToString() ?? "-";
                    string telephone = row["Telephone"]?.ToString() ?? "-";

                    html.Append("            <tr>");
                    html.Append($"                <td><strong>{nomComplet}</strong></td>");
                    html.Append($"                <td>{email}</td>");
                    html.Append($"                <td>{telephone}</td>");
                    html.Append("                <td class='text-right'><span class='badge'>Disponible</span></td>");
                    html.Append("            </tr>");
                }
            }
            html.Append("        </tbody>");
            html.Append("    </table>");

            // Pied de page
            html.Append("    <div class='footer'>");
            html.Append($"        Catalogue généré en temps réel le {DateTime.Now:dd/MM/yyyy à HH:mm} - Document Confidentiel VainEscort S.A.");
            html.Append("    </div>");

            html.Append("</body>");
            html.Append("</html>");

            return html.ToString();
        }
    }
}