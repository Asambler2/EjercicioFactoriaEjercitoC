using EjercicioFactoriaEjercitoC.Unidades;
using EjercicioFactoriaEjercitoC.ValidadorPresupuesto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFactoriaEjercitoC.Ejercito
{
    public class EjercitoNuevo : IEjercito, Ipresupuesto
    {
        public string NombreEjercito { get; set; }
        public int NumElementos { get; set; }
        public int PotenciaFuegoTotal { get; set; } = 0;
        public int BlindajeTotal { get; set; } = 0;
        public int VelocidadTotal { get; set; } = 0;
        public float GastoTotal { get; set; } = 0;
        public double CapacidadMilitar { get; set; } = 0;
        public float Presupuesto { get; set; }
        public IValidadorPresupuesto Validador { get; set; }
        public List<IMilitarizable> EjercitoListaUnidades { get; set; } = new List<IMilitarizable>();

        public EjercitoNuevo(string NombreEjercito, float Presupuesto, IValidadorPresupuesto Validador )
        {
            this.NombreEjercito = NombreEjercito;
            this.Presupuesto = Presupuesto;
            this.Validador = Validador;
        }

        public void AddUnidad(IMilitarizable Unidad)
        {
            if(Validador.ValidarAddUnidad(Unidad as Unidad, GastoTotal, Presupuesto))
            {
                EjercitoListaUnidades.Add(Unidad);
                this.NumElementos++;
                this.PotenciaFuegoTotal += Unidad.PotenciaFuego;
                this.BlindajeTotal += Unidad.Blindaje;
                this.VelocidadTotal += Unidad.Velocidad;
                this.GastoTotal += (Unidad as ICosteable).Precio;
                this.CapacidadMilitar = CalculoCapacidadMilitar();
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"No hay suficiente presupuesto para esta unidad siendo el presupuesto: {this.Presupuesto}" +
                    $" , el gasto total acumulado hasta entonces: {this.GastoTotal}, siendo el precio: {(Unidad as ICosteable).Precio} " +
                    $" y siendo el deficit del presupuesto de {this.Presupuesto - this.GastoTotal - (Unidad as ICosteable).Precio}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public double CalculoCapacidadMilitar()
        {
            return (((double)this.PotenciaFuegoTotal * (double)this.VelocidadTotal) / 2) / (100 - (double)this.BlindajeTotal);
        }

        public string MostrarEjercito()
        {
            return $"Nombre Ejercito: {this.NombreEjercito}, Número de elementos: {this.NumElementos}, Potencia total: {this.PotenciaFuegoTotal}, " +
                $"Blindaje total {this.BlindajeTotal}, Velocidad total: {this.VelocidadTotal}, Gasto total: {this.GastoTotal}, Capacidad militar: {Math.Round(this.CapacidadMilitar, 2)}, " +
                $"Presupuesto: {this.Presupuesto}, Presupuesto disponible: {this.Presupuesto - this.GastoTotal}";
        }
        public string MostrarUnidadesEjercito()
        {
            string Cadena = "";
            foreach (IMilitarizable Unidad in EjercitoListaUnidades)
            {
                Cadena += Unidad.Mostrar();
            }
            return Cadena;
        }
    }
}
