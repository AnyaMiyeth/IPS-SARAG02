using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;
using Entidad;

namespace Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {
            string numeroLiquidacion;
            string idPaciente;
            string tipoAfiliacion;
            double salarioPaciente;
            double valorServicio;

            Console.WriteLine("Digite numero de liquidacion:");
            numeroLiquidacion = Console.ReadLine();
            Console.WriteLine("DIgite su identificacion:");
            idPaciente = Console.ReadLine();
            Console.WriteLine("Digite tipo de afiliación: S=> para regimen Subsidiado y C=>Contribitivo");
            tipoAfiliacion = Console.ReadLine();
            Console.WriteLine("Digite su salario devengado:");
            salarioPaciente = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite el valor del servicio prestado");
            valorServicio = double.Parse(Console.ReadLine());
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;

            if (tipoAfiliacion=="C")
            {
                liquidacionCuotaModeradora= new LiquidacionContributivo(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio);
            }
            else
            {
                liquidacionCuotaModeradora = new LiquidacionSubsidiado(numeroLiquidacion, idPaciente, tipoAfiliacion, salarioPaciente, valorServicio);
            }

            LiquidacionCuotaModeradoraService liquidacionCuotaModeradoraService = new LiquidacionCuotaModeradoraService();
            
            liquidacionCuotaModeradora.CalcularCuotaModeradora();
            Console.WriteLine(liquidacionCuotaModeradoraService.Guardar(liquidacionCuotaModeradora));
            var response =liquidacionCuotaModeradoraService.Consultar();
            if (response.Error)
            {
                Console.WriteLine(response.Message);
            }
            else
            {
                foreach (var item in response.Liquidaciones)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine($"Su liquidacion es:{liquidacionCuotaModeradora.CuotaModeradora}");
            Console.ReadKey();


    }
    }
}
