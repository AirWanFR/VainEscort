using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class FacturationManager
    {
        private FacturationDAL _dal = new FacturationDAL();

        public DataTable ChargerPrestationsEnAttente() => _dal.GetPrestationsAFacturer();

        public bool ValiderLigneFacture(int id) => _dal.ValiderFacturePrestation(id);
    }
}