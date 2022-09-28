﻿using Entra21.CSharp.Area21.Repository.Entities;
using Entra21.CSharp.Area21.Service.ViewModels.Vehicles;

namespace Entra21.CSharp.Area21.Service.Services.Vehicles
{
    public interface IUserController
    {
        bool Delete(int id);
        Vehicle Register(VehicleRegisterViewModel viewModel);
        bool Update(VehicleUpdateViewModel viewModel);
        Vehicle? GetById(int id);
        IList<Vehicle> GetAllById(int id);
    }
}