using EjercicioFactoriaEjercitoC.Ejercito;
using EjercicioFactoriaEjercitoC.GrupoDeEjercitos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFactoriaEjercitoC.ValidadorNombreEjercito
{
    public class ValidaNombreEjercitocs : IValidadorNombreEjercito
    {
        public bool ValidaElNombreEjercito(IEjercito Ejercito, List<IEjercito> GrupoEjercitosTotal)
        {
            foreach (IEjercito ElEjercito in GrupoEjercitosTotal)
            {
                return (ElEjercito.NombreEjercito.Equals(Ejercito.NombreEjercito) ? false : true);
            }
            return true;
        }
    }
}
