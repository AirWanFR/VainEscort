using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class ClientBLL
    {
        private ClientDAL _dal = new ClientDAL();

        public DataTable ChargerEmployes() => _dal.GetEmployesActifs();
        public DataTable ChargerClients() => _dal.GetAllClients();

        public bool Ajouter(string prenom, string nom, int idEmp) => _dal.Insert(prenom, nom, idEmp);
        public bool Modifier(int id, string prenom, string nom, int idEmp) => _dal.Update(id, prenom, nom, idEmp);
        public bool Supprimer(int id) => _dal.Delete(id);
    }
}