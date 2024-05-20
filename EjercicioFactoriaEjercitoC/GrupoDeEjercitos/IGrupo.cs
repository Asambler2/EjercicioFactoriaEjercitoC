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
    public interface IGrupo
    {
        public List<IEjercito> GrupoEjercitosTotal { get; set; }
        public IValidadorNombreEjercito Validador { get; set; }
        public void AddEjercito(IEjercito Ejercito);
        public string MostrarGrupoEjercitos();
    }
}
