﻿using Repository.Entities;
using System.Security.Permissions;

namespace Entra21.CSharp.Area21.Repository.Entities
{
    internal class Notification : EntityBase
    {
        public bool RegisteredVehicle { get; set; }
        public string Address { get; set; }

        public Guard Guard { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
