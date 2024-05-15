using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjercicioFactoriaEjercitoC.Unidades;

namespace EjercicioFactoriaEjercitoC.Ejercito
{
    public interface IEjercito
    {
        public string NombreEjercito { get; set; }
    public List<IMilitarizable> EjercitoListaUnidades { get; set; }
        public int NumElementos { get; set; }
        public int PotenciaFuegoTotal { get; set; }
        public int BlindajeTotal { get; set; }
        public int VelocidadTotal { get; set; }
        public float GastoTotal { get; set; }
        public double CapacidadMilitar { get; set; }

        public void AddUnidad(IMilitarizable unidad);
        public double CalculoCapacidadMilitar();
        public string MostrarEjercito();
        public string MostrarUnidadesEjercito();
    }
}
