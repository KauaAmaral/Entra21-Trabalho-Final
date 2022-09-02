using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.RepositoryDataBase;

namespace Entra21.CSharp.Area21.Repository.Repositories.Vehicles
{
    internal class VehicleRepository : IVehicleRepository
    {
        private readonly ShortTermParkingContext _context;

        public VehicleRepository(ShortTermParkingContext context)
        {
            _context = context;
        }

        public bool Apagar(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            if (vehicle == null)
                return false;

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();

            return true;
        }

        public Vehicle Cadastrar(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            return vehicle;
        }

        public void Editar(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }

        public Vehicle? ObterPorId(int id) =>
            _context.Vehicles.FirstOrDefault(x => x.Id == id);


        public IList<Vehicle> ObterTodos() =>
            _context.Vehicles.ToList();

    //     public Pet? ObterPodId(int id) => 
    //    _contexto.Pets
    //        // INNER JOIN com a tabela de Responsaveis
    //        .Include(x => x.Responsavel) 
    //        .Include(x => x.Raca)
    //        .FirstOrDefault(x => x.Id == id);

    //public IList<Pet> ObterTodos() => 
    //    _contexto.Pets
    //    // INNER JOIN com a tabela de Responsaveis
    //        .Include(x => x.Responsavel) 
    //        .Include(x => x.Raca)
    //        .ToList();
    }
}
