using System;
using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class PrestaManager
    {
        private PrestaDAL _dal = new PrestaDAL();

        public DataTable ChargerEmployes() => _dal.GetEmployes();
        public DataTable ChargerClients() => _dal.GetClients();
        public DataTable ChargerTypes() => _dal.GetTypes();
        public DataTable ChargerHistorique() => _dal.GetAllPrestations();

        public bool Ajouter(int e, int c, int t, DateTime d, decimal h) => _dal.Insert(e, c, t, d, h);
        public bool Modifier(int id, int e, int c, int t, DateTime d, decimal h) => _dal.Update(id, e, c, t, d, h);
        public bool Supprimer(int id) => _dal.Delete(id);
    }
}