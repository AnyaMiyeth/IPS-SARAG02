using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Logica
{
    public class LiquidacionCuotaModeradoraService
    {
        private LiquidacionCuotaModeradoraRepository liquidacionCuotaModeradoraRepository;
        private int numeroLiquidacion;
        private string idPaciente;
        private string tipoAfiliacion;
        private double salarioPaciente;
        private double valorServicio;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionCuotaModeradoraRepository = new LiquidacionCuotaModeradoraRepository();
        }

        public string Guardar(LiquidacionCuotaModeradora liquidacionCuota)
        {
            try
            {
                if (liquidacionCuotaModeradoraRepository.Buscar(liquidacionCuota.NumeroLiquidacion) == null)
                {
                    liquidacionCuotaModeradoraRepository.Guardar(liquidacionCuota);
                    return "Se guardaron los datos Satisfactoriamente";
                }
                return "No es posible Guardar los Datos";
            }
            catch (Exception e)
            {

                return "Error de Aplicacion:" + e.Message;
            }
        }

        public LiquidacionConsultaResponse Consultar() {
            try
            {
                List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras=liquidacionCuotaModeradoraRepository.ConsultarTodos();
                var response = new LiquidacionConsultaResponse(liquidacionCuotaModeradoras);
                return response;
            }
            catch (Exception e)
            {
                var response = new LiquidacionConsultaResponse("Error de Aplicacion:" + e.Message);
                return response;
            }

        }






    }

    public class LiquidacionConsultaResponse
    {
        public List<LiquidacionCuotaModeradora> Liquidaciones { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        public LiquidacionConsultaResponse(string message)
        {
            Error = true;
            Message = message;
        }
        public LiquidacionConsultaResponse(List<LiquidacionCuotaModeradora> liquidaciones)
        {
            Liquidaciones = liquidaciones;
            Error = false;
        }
    }

} 


