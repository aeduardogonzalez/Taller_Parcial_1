using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Liquidacion
    {

        public int NumeroLiquidacion { get; set; }
        public string IdentificacionPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public int TipoAfiliacion { get; set; }
        public int SalarioPaciente { get; set; }
        public int ValorServicio { get; set; }

        public Liquidacion()
        {

        }

        public Liquidacion(int numeroLiquidacion, string identificacionPaciente, string nombrePaciente, int tipoAfiliacion, int salarioPaciente, int valorServicio)
        {
            NumeroLiquidacion = numeroLiquidacion;
            IdentificacionPaciente = identificacionPaciente;
            NombrePaciente = nombrePaciente;
            TipoAfiliacion = tipoAfiliacion;
            SalarioPaciente = salarioPaciente;
            ValorServicio = valorServicio;
        }

    }
}
