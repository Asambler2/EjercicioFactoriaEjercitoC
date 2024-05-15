using EjercicioFactoriaEjercitoC.Unidades;
using System;
using System.Collections.Generic;
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
        public List<IMilitarizable> EjercitoListaUnidades { get; set; } = new List<IMilitarizable>();

        public EjercitoNuevo(string NombreEjercito, float Presupuesto)
        {
            this.NombreEjercito = NombreEjercito;
            this.Presupuesto = Presupuesto; 
        }

        public void AddUnidad(IMilitarizable Unidad)
        {
            EjercitoListaUnidades.Add(Unidad);
            this.NumElementos++;
            this.PotenciaFuegoTotal += Unidad.PotenciaFuego;
            this.BlindajeTotal += Unidad.Blindaje;
            this.VelocidadTotal += Unidad.Velocidad;
            this.GastoTotal += (Unidad as ICosteable).Precio;
            this.CapacidadMilitar = CalculoCapacidadMilitar();

        }

        public double CalculoCapacidadMilitar()
        {
            return ((this.PotenciaFuegoTotal * this.VelocidadTotal) / 2) / (100 - this.BlindajeTotal);
        }

        public string MostrarEjercito()
        {
            return $"Nombre Ejercito: {this.NombreEjercito}, Número de elementos: {this.NumElementos}, Potencia total: {this.PotenciaFuegoTotal}, " +
                $"Blindaje total {this.BlindajeTotal}, Velocidad total: {this.VelocidadTotal}, Gasto total: {this.GastoTotal}, Capacidad militar: {this.CapacidadMilitar}, " +
                $"Presupuesto: {this.Presupuesto}, Presupuesto disponible: {this.Presupuesto - this.GastoTotal}";
        }
        public string MostrarUnidadesEjercito()
        {
            string Cadena = "";
            foreach (IMilitarizable Unidad in EjercitoListaUnidades)
            {
                Cadena += Unidad.Mostrar();
                Console.WriteLine($"{Unidad.Mostrar()}");
            }
            return Cadena;
        }
    }
}
