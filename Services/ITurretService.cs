using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public partial interface IService
    {
        List<Turrets> GetAllTurrets();
        Turrets GetTurretsById(int id);
        void InsertTurrets(Turrets turret);
        void UpdateTurrets(Turrets turret);
        void DeleteTurrets(string turretCode);
    }
}
