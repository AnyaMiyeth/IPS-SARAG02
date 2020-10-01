using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.IO;

namespace Datos
{
    public class LiquidacionCuotaModeradoraRepository
    {
        private readonly string FileName = "LiquidacionPaciente.txt";
        public void Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{liquidacionCuotaModeradora.NumeroLiquidacion};{liquidacionCuotaModeradora.IdentificacionPaciente};{liquidacionCuotaModeradora.TipoAfiliacion};{liquidacionCuotaModeradora.SalarioPaciente};{liquidacionCuotaModeradora.ValorServicio};{liquidacionCuotaModeradora.Tarifa};{liquidacionCuotaModeradora.InicialCuotaModeradora}");
            writer.Close();
            file.Close();
        }
        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = ConsultarTodos();
            foreach(var item in liquidacionCuotaModeradoras)
            {
                if (Encontrado(item.NumeroLiquidacion, numeroLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }

        private bool Encontrado( string idPacienteRegistrado, string idPacienteBuscado)
        {
            return idPacienteRegistrado == idPacienteBuscado;

        }
        public List<LiquidacionCuotaModeradora> ConsultarTodos()
        {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
            FileStream file = new FileStream(FileName,FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;

            while ((linea= reader.ReadLine())!= null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = Map(linea);
                liquidacionCuotaModeradoras.Add(liquidacionCuotaModeradora);
            }
            reader.Close();
            file.Close();
            return liquidacionCuotaModeradoras;

        }

        private LiquidacionCuotaModeradora Map(string linea)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;
            char delimiter = ';';
            string[] VectorLiquidacion = linea.Split(delimiter);

            if (VectorLiquidacion[2] == "C")
            {
                liquidacionCuotaModeradora = new LiquidacionContributivo();
            }
            else
            {
                liquidacionCuotaModeradora = new LiquidacionSubsidiado();
            }
            liquidacionCuotaModeradora.NumeroLiquidacion = VectorLiquidacion[0];
            liquidacionCuotaModeradora.IdentificacionPaciente = VectorLiquidacion[1];
            liquidacionCuotaModeradora.TipoAfiliacion = VectorLiquidacion[2];
            liquidacionCuotaModeradora.SalarioPaciente =double.Parse( VectorLiquidacion[3]);
            liquidacionCuotaModeradora.ValorServicio = double.Parse(VectorLiquidacion[4]);
            liquidacionCuotaModeradora.Tarifa = double.Parse(VectorLiquidacion[5]);
            liquidacionCuotaModeradora.InicialCuotaModeradora = double.Parse(VectorLiquidacion[6]);
            return liquidacionCuotaModeradora;
        }
        public void Eliminar(String idPaciente)
        {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
            liquidacionCuotaModeradoras = ConsultarTodos();
            FileStream file = new FileStream(FileName, FileMode.Create);
            file.Close();
            foreach (var item in liquidacionCuotaModeradoras)
            {
                if (!Encontrado(item.IdentificacionPaciente, idPaciente))
                {
                    Guardar(item);
                }
            }
        }
            public void Modificar(LiquidacionCuotaModeradora liquidacionfirst, LiquidacionCuotaModeradora liquidacionNew)
                {
            List<LiquidacionCuotaModeradora> liquidacionCuotaModeradoras = new List<LiquidacionCuotaModeradora>();
            liquidacionCuotaModeradoras = ConsultarTodos();
            FileStream file = new FileStream(FileName, FileMode.Create);
            file.Close();
            foreach (var item in liquidacionCuotaModeradoras)
            {
                if (!Encontrado(item.IdentificacionPaciente, liquidacionfirst.IdentificacionPaciente))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacionNew);
                }
            }
                }  
            }
        }
