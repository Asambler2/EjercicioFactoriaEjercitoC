﻿using EjercicioFactoriaEjercitoC.Unidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioFactoriaEjercitoC.ValidadorPresupuesto
{
    public class ValidadorDelPresupuesto : IValidadorPresupuesto
    {
        public bool ValidarAddUnidad(Unidad LaUnidad, float GastoTotal, float Presupuesto)
        {
            return (LaUnidad.Precio + GastoTotal) <= Presupuesto;
        }
    }
}
