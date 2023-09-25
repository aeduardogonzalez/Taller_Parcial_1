using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {

        public int IDLiquidacion { get; set; }
        public string IDPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public char TipoAfiliacion { get; set; }
        public double SalarioPaciente { get; set; }
        public double ValorServicio { get; set; }
        public double salarioMinimo { get; set; }
        public double ValorLiquidado { get; set; }
        

        public Liquidacion()
        {

        }

        public Liquidacion(int idLiquidacion, string idPaciente, string nombrePaciente, char tipoAfiliacion, int salarioPaciente, int valorServicio)
        {
            IDLiquidacion = idLiquidacion;
            IDPaciente = idPaciente;
            NombrePaciente = nombrePaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioPaciente = salarioPaciente;
            ValorServicio = valorServicio;
            salarioMinimo = 1160000;
        }

        public double CuotaModeradora()
        {
            if (TipoAfiliacion == 'S')
            {
                SalarioPaciente = 0;
                return SalarioPaciente;
            }
            else if (TipoAfiliacion == 'C')
            {
                if (SalarioPaciente < salarioMinimo * 2)
                {
                    ValorLiquidado = (SalarioPaciente * 0.15);
                    if (ValorLiquidado > 250000)
                    {
                        ValorLiquidado = 250000;
                    }
                }
                else if ((SalarioPaciente > salarioMinimo * 2) && (SalarioPaciente < salarioMinimo * 5))
                {
                    ValorLiquidado = (SalarioPaciente * 0.20);
                    if ((ValorLiquidado > 900000))
                    {
                        ValorLiquidado = 900000;
                    }
                }
                else if (SalarioPaciente > salarioMinimo * 5)
                {
                    ValorLiquidado = (SalarioPaciente * 0.25);

                    if (ValorLiquidado > 1500000)
                    {
                        ValorLiquidado = 1500000;
                    }

                }

            }
            return ValorLiquidado;
        }

    }
}