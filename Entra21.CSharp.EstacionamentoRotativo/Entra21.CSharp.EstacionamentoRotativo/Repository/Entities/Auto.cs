using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Auto : EntitieBase
    {
        public User User { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public ModelAuto ModelAuto { get; set; }
    }
}
