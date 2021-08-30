using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SecondProject.Pages
{
    public class NominaModel : PageModel
    {

        List<Empleados> listaNomina = new List<Empleados>();
        public void OnGet()
        {
            listaNomina.Clear();

            listaNomina.Add(new Empleados() { nombres = "Juan",         apellidos = "Perez",        cargo = "Supervisor",   salario = 25000});
            listaNomina.Add(new Empleados() { nombres = "Andres",       apellidos = "Dominguez",    cargo = "Vendedor",     salario = 12500});
            listaNomina.Add(new Empleados() { nombres = "Miguelina",    apellidos = "Juan",         cargo = "Entrenadora",  salario = 25000 });
            listaNomina.Add(new Empleados() { nombres = "Antonio",      apellidos = "Dominguez",    cargo = "Seguridad",    salario = 15000 });
            listaNomina.Add(new Empleados() { nombres = "Raysa",        apellidos = "Martinez",     cargo = "Encargada",    salario = 30000 });
            listaNomina.Add(new Empleados() { nombres = "Orlando",      apellidos = "Emeterio",     cargo = "Mensajero",    salario = 10000 });

        }

        public List<Empleados> Employee => this.listaNomina;
    }

    public class Empleados {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cargo { get; set; }
        public double salario { get; set; }
        public double afp_descuento () {
            return this.salario * 0.0287;
        }
        public double ars_descuento() {
            return this.salario * 0.0304;
        }
        public double irs_descuento() {
            double excedente = 0;

            if (this.salario >= 34686.00 && this.salario < 52028.00)
            {
                excedente = (this.salario * 12 - 416220.01);
                return excedente * 0.15 / 12;
            }
            else if (this.salario >= 52028.00 && this.salario <= 72261.00)
            {
                excedente = (this.salario * 12 - 624329.01);
                 return (excedente * 0.2 / 12) + 31216.00;
            }
            else if (this.salario >= 72261.00)
            {
                excedente = (this.salario * 12 - 867123.00);
                return (excedente * 0.25 / 12) + 79776.00;
            }

            return 0;
        }
        public double total_descuentos () {
            return this.irs_descuento() + this.afp_descuento() + this.ars_descuento();
        }
        public double salario_neto() {
              return this.salario - this.total_descuentos();
        }

        
    }
}
