﻿namespace Library.Entities.Entities
{
    public class Editorial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int NLibros { get; set; }
    }
}