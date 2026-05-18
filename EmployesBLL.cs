using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class EmployeManager
    {
        private EmployeDAL _dal = new EmployeDAL();

        public DataTable GetAll() => _dal.GetAll();
        public bool Ajouter(string p, string n) => _dal.Insert(p, n);
        public bool Modifier(int id, string p, string n) => _dal.Update(id, p, n);
        public bool Supprimer(int id) => _dal.Delete(id);
    }
}