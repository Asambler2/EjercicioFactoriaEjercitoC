using EjercicioFactoriaEjercitoC.Ejercito;
using EjercicioFactoriaEjercitoC.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFactoriaEjercitoC.GrupoDeEjercitos
{
    public class GrupoEjercitos : IGrupo
    {
        public List<IEjercito> GrupoEjercitosTotal { get; set; } = new List<IEjercito>();

        public void AddEjercito(IEjercito Ejercito)
        {
            GrupoEjercitosTotal.Add(Ejercito);
        }

        public string MostrarGrupoEjercitos()
        {
            string Cadena = "";
            foreach (IEjercito Ejercito in GrupoEjercitosTotal)
            {
                Cadena += Ejercito.MostrarEjercito();
                Console.WriteLine($"{Ejercito.MostrarEjercito()}");
            }
            return Cadena;
        }
    }
}
