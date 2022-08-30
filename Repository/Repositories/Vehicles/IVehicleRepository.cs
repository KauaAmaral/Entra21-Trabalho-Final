using Entra21.CSharp.Area21.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    internal interface IVehicleRepository
    {
        Vehicle Cadastrar(Vehicle vehicles);
        void Editar(Vehicle vehicle);
        bool Apagar(int id);
        Vehicle? ObterPorId(int id);
        IList<Vehicle> ObterTodos();
    }
}
