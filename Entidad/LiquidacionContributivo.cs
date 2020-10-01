using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class LiquidacionContributivo : LiquidacionCuotaModeradora
    {
        public LiquidacionContributivo()
        {
        }

        public LiquidacionContributivo(string numeroLiquidacion, string idPaciente, string tipoAfiliacion, double salarioPaciente, double valorServicio) : base(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio)
        {
        }

        public override void CalcularTarifa()
        {
             if ((SalarioPaciente < 2))
            {
                Tarifa = 0.15;
            }
            else if ((SalarioPaciente >= 2) && (SalarioPaciente <= 5))
            {
                Tarifa = 0.20;
            }
            else if (SalarioPaciente > 5)
            {
                Tarifa = 0.25;
            }
        }

        public override void CalcularTope()
        {
            if ((SalarioPaciente < 2))
            {
                Tope= 250000;
            }
            else if ((SalarioPaciente >= 2) && (SalarioPaciente <= 5) )
            {
                Tope = 9000000;
            }
            else if ((SalarioPaciente > 5) )
            {
                Tope = 1500000;
            }
        }
    }
}
