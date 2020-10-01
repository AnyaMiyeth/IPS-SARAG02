using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public class LiquidacionSubsidiado:LiquidacionCuotaModeradora
    {
        

        public LiquidacionSubsidiado()
        {
        }

        public LiquidacionSubsidiado(string numeroLiquidacion, string idPaciente, string tipoAfiliacion, double salarioPaciente, double valorServicio) : base(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio)
        {
        }

        public override void CalcularTarifa()
        {
           Tarifa=0.05;
        }

        public override void CalcularTope()
        {
            Tope = 200000;
        }
    }
}
