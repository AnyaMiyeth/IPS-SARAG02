using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public abstract class LiquidacionCuotaModeradora

    {
        

        public LiquidacionCuotaModeradora(string numeroLiquidacion, string idPaciente, string tipoAfiliacion, double salarioPaciente, double valorServicio)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdentificacionPaciente = idPaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioPaciente = salarioPaciente;


            ValorServicio = valorServicio;


        }
        public LiquidacionCuotaModeradora()
        {
        }

        
        
        public double CuotaModeradora { get; set; }
        public double Tarifa { get; set; }
        public string NumeroLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string TipoAfiliacion { get; set; }
        public double SalarioPaciente { get; set; }
        public double ValorServicio { get; set; }
        public double Liquidacion { get; set; }
        public double Tope { get; set; }
        public double InicialCuotaModeradora { get; set; }
        public  void CalcularCuotaModeradora()
        {
            CalcularTarifa();
            InicialCuotaModeradora = ValorServicio * Tarifa;
            CalcularTope();
            CuotaModeradora = DefinirCuotaModeradora();
        }

        public abstract void CalcularTarifa();
        public abstract void CalcularTope();

        public double DefinirCuotaModeradora()
        {
            if (InicialCuotaModeradora > Tope)
            {
                return Tope;
            }
            return InicialCuotaModeradora;
        }

        public override string ToString()
        {
            return $"NumeroLiquidacion: {NumeroLiquidacion}-Identificacion: {IdentificacionPaciente} - tipo afiliacion:{TipoAfiliacion}--liquidacion: {CuotaModeradora}";
        }
    }
}
