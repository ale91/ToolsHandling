using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial class Service : IService
    {
        protected Repository _repository;
        public Service()
        {
            _repository = new Repository();
        }
    }
}
