﻿namespace Entra21.CSharp.Area21.Repository.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
    }
}
