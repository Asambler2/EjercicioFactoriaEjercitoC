using EjercicioFactoriaEjercitoC.Ejercito;
using EjercicioFactoriaEjercitoC.GrupoDeEjercitos;
using EjercicioFactoriaEjercitoC.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFactoriaEjercitoC
{
    public class Menu
    {
        IGrupo GrupoEjercitos = new GrupoEjercitos();
        public void GenerarMenu()
        {
            int Comando = 0;
            Comando = OpcionesGrupoEjercitos();
            switch(Comando)
            {
                case 1: GrupoEjercitos.GrupoEjercitosTotal.Add(CrearEjercito());
                    break;
                case 2: GrupoEjercitos.MostrarGrupoEjercitos();
                    break;  
                case 3: IEjercito Ejercito = BuscarEjercito();
                    MenuEjercito(Ejercito);
                    break;
            }
            if (Comando != 0) GenerarMenu();
        }

        public int OpcionesGrupoEjercitos()
        {
            Console.WriteLine("Pulsa 0 para salir.");
            Console.WriteLine("Pulsa 1 para generar un nuevo ejercito.");
            if (this.GrupoEjercitos.GrupoEjercitosTotal.Count != 0)Console.WriteLine("Pulsa 2 para mostrar Ejercitos.");
            if (this.GrupoEjercitos.GrupoEjercitosTotal.Count != 0) Console.WriteLine("Pulsa 3 para buscar un ejercito existente.");
            return int.Parse(Console.ReadLine());
        }

        public IEjercito BuscarEjercito()
        {
            string ColeccionNombres = "";
            Console.WriteLine("Introduce el nombre del ejercito a buscar");
            string NombreEjercito = Console.ReadLine();
            foreach(IEjercito Ejercito in GrupoEjercitos.GrupoEjercitosTotal)
            {
                ColeccionNombres += $"\n{Ejercito.NombreEjercito}";
                if(Ejercito.NombreEjercito.Equals(NombreEjercito))return Ejercito;
            }
            Console.WriteLine($"Introduce un nombre de ejercito existente de entre estos nombres. \n{ColeccionNombres}");
            BuscarEjercito();
            return new EjercitoNuevo("", 0);
        }

        public IEjercito CrearEjercito()
        {
            string NombreEjercito = "";
            float Presupuesto = 0;
            Console.WriteLine("Introduce el nombre del nuevo ejercito.");
            NombreEjercito = Console.ReadLine();
            foreach (IEjercito Ejercito in GrupoEjercitos.GrupoEjercitosTotal)
            {
                if (Ejercito.NombreEjercito == NombreEjercito) {
                    Console.WriteLine("Ese Ejercito ya existe, introduce otro.");
                    CrearEjercito();
                };
            }
            Console.WriteLine("Introduce el presupuesto del nuevo ejercito.");
            Presupuesto = float.Parse(Console.ReadLine());
            return new EjercitoNuevo(NombreEjercito, Presupuesto);
        }
        public int OpcionesEjercito(IEjercito Ejercito)
        {
            int Comando = 0;
            Console.WriteLine("Introduce 1 para añadir una nueva unidad al ejercito.");
            Console.WriteLine("Introduce 2 para mostar información del ejercito.");
            if (Ejercito.EjercitoListaUnidades.Count != 0) {
                Console.WriteLine("Introduce 3 para mostrar todas las unidades del ejercito.");
            }
            Console.WriteLine("Introduce 0 ir al menu de ejercito.");
            Comando = int.Parse(Console.ReadLine());
            return Comando;
        }

        public void MenuEjercito(IEjercito Ejercito)
        {
            int Comando = 0;
            Comando = OpcionesEjercito(Ejercito);
            switch (Comando) {
                case 1: Ejercito = CrearUnidad(Ejercito); 
                    break;
                case 2: Console.WriteLine(Ejercito.MostrarEjercito());
                    break;
                case 3: Ejercito.MostrarUnidadesEjercito();
                    break;
            }
            if (Comando != 0) MenuEjercito(Ejercito);
        }

        public IEjercito CrearUnidad(IEjercito Ejercito)
        {
            string NombreUnidad = "";
            int Velocidad = 0;
            int Blindaje = 0;
            int PotenciaFuego = 0;
            float Precio = 0;
            Console.WriteLine("Escribe el nombre de la unidad");
            NombreUnidad = Console.ReadLine();
            foreach(Unidad LaUnidad in Ejercito.EjercitoListaUnidades) { 
                if(NombreUnidad.Equals(LaUnidad.Titulo)) {
                    Console.WriteLine("Esa unidad ya existe introduce un nuevo nombre.");
                    CrearUnidad(Ejercito);
                }
            }
            Console.WriteLine("Escribe la velocidad de la unidad");
            Velocidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Escribe el blindaje de la unidad");
            Blindaje = int.Parse(Console.ReadLine());
            Console.WriteLine("Escribe la potencia de fuego de la unidad");
            PotenciaFuego = int.Parse(Console.ReadLine());
            Console.WriteLine("Escribe el precio de la unidad");
            Precio = float.Parse(Console.ReadLine());
            if (Ejercito.GastoTotal + Precio > (Ejercito as EjercitoNuevo).Presupuesto)
            {
                Console.WriteLine("Excede el presupuesto del ejercito, vuelve a generar una unidad con un precio menor o cero." 
                    + " Excedente:" + (Ejercito.GastoTotal + Precio - (Ejercito as EjercitoNuevo).Presupuesto));
                CrearUnidad(Ejercito);
            }
            IMilitarizable LaUnidadNueva = new Unidad(NombreUnidad, Velocidad, Blindaje, PotenciaFuego, Precio);
            Ejercito.AddUnidad(LaUnidadNueva);
            return Ejercito;
        }
    }
}
