using System.Data;
using VainEscort.DAL;

namespace VainEscort.BLL
{
    public class ClientBLL
    {
        private ClientDAL _dal = new ClientDAL();

        public DataTable ChargerEmployes() => _dal.GetEmployesActifs();
        public DataTable ChargerClients() => _dal.GetAllClients();

        public bool Ajouter(string prenom, string nom, string telephone, string email, int idEmp)
            => _dal.Insert(prenom, nom, telephone, email, idEmp);

        public bool Modifier(int id, string prenom, string nom, string telephone, string email, int idEmp)
            => _dal.Update(id, prenom, nom, telephone, email, idEmp);

        public bool Supprimer(int id) => _dal.Delete(id);
    }
}