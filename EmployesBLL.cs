using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class EmployeManager
    {
        private EmployeDAL _dal = new EmployeDAL();

        public DataTable GetAll() => _dal.GetAll();
        public bool Ajouter(string p, string n, string t, string e) => _dal.Insert(p, n, t, e);
        public bool Modifier(int id, string p, string n, string t, string e, bool actif) => _dal.Update(id, p, n, t, e, actif);

        public bool Supprimer(int id) => _dal.Delete(id);
    }
}