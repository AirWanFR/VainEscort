using System.Data;
using VainEscort.DAL; // Référence à la couche accès aux données

namespace VainEscort.BLL
{
    public class DashboardManager
    {
        private DashboardDAL _dal = new DashboardDAL();

        public DataTable ObtenirApercuPrestations()
        {
            // La BLL peut filtrer ou formater ici si besoin
            return _dal.SelectDernieresPrestations();
        }

        public DataTable ObtenirListeEmployes() => _dal.SelectAllEmployes();
        public DataTable ObtenirListeClients() => _dal.SelectAllClients();

        public int CompterPrestationsNonFacturees()
        {
            DataTable dt = _dal.SelectPrestationsAByEtat(false); // false = non facturé
            return dt.Rows.Count; // La BLL transforme la table en un simple chiffre
        }

        public bool EstConnecte()
        {
            return _dal.TesterConnexion();
        }
    }
}