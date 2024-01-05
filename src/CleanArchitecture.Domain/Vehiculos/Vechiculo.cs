using CleanArchitecture.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.vehiculos
{
    public sealed class Vechiculo : Entity
    {
        public Vechiculo(
            Guid id,
            Modelo modelo,
            Vin vin,
            Direccion direccion,
            Moneda precio,
            Moneda mantenimiento,
            DateTime fechaUltimaAlquiler,
            List<Accesorios?> accesorios
            
            ) : base(id)
        {
            Modelo = modelo;
            Vin = vin;
            Direccion = direccion;
            Precio = precio;
            Mantenimiento = mantenimiento;
            FechaUltimaAlquiler = fechaUltimaAlquiler;
            Accesorios = accesorios;

        }

        public Modelo? Modelo { get; private set; }

        public Vin? Vin {  get; private set; }

        public Direccion? Direccion { get; private set; }

        public Moneda Precio {  get; private set; }

        public Moneda Mantenimiento {  get; private set; }


        public DateTime? FechaUltimaAlquiler {  get; internal set; }

        public List<Accesorios?> Accesorios {  get; private set; } = new();
            

    }
}
