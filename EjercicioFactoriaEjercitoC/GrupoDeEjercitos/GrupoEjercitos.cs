using EjercicioFactoriaEjercitoC.Ejercito;
using EjercicioFactoriaEjercitoC.Unidades;
using EjercicioFactoriaEjercitoC.ValidadorNombreEjercito;
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
        public IValidadorNombreEjercito Validador { get; set; }

        public GrupoEjercitos(IValidadorNombreEjercito Validador)
        {
            this.Validador = Validador;
        }

        public void AddEjercito(IEjercito Ejercito)
        {
            if(Validador.ValidaElNombreEjercito(Ejercito, GrupoEjercitosTotal))
            {
                GrupoEjercitosTotal.Add(Ejercito);
            } else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"El nombre de Ejercito { Ejercito.NombreEjercito } ya existe");
                Console.ForegroundColor = ConsoleColor.White;
            }
            
        }

        public string MostrarGrupoEjercitos()
        {
            string Cadena = "";
            foreach (IEjercito Ejercito in GrupoEjercitosTotal)
            {
                Cadena += Ejercito.MostrarEjercito();
            }
            return Cadena;
        }
    }
}
