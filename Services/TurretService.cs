using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial class Service : IService
    {
        //Metodi per Turrets
        public List<Turrets> GetAllTurrets()
        {
            return _repository.GetAllTurrets();
        }

        public Turrets GetTurretsById(int id)
        {
            return _repository.GetTurretById(id);
        }

        public void InsertTurrets(Turrets turret)
        {
            _repository.InsertTurret(turret);
        }

        public void UpdateTurrets(Turrets turret)
        {
            _repository.UpdateTurret(turret);
        }

        public void DeleteTurrets(string turretCode)
        {
            _repository.DeleteTurrets(turretCode);
        }
    }
}
