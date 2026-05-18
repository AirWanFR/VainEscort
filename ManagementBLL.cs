using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class ManagementManager
    {
        private ManagementDAL _dal = new ManagementDAL();

        public DataTable ChargerCA() => _dal.GetChiffreAffairesMensuel();
        public DataTable ChargerRentabilite() => _dal.GetRentabiliteEmployes();
        public DataTable ChargerClientsAttitres() => _dal.GetClientsAttitres();
    }
}