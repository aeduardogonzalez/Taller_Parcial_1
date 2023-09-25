using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
using System.IO;

namespace BLL
{
    public class LiquidacionService
    {
        private LiquidacionRepository liquidacionRepository = null;
        private List<Liquidacion> liquidacionList = null;

        public LiquidacionService()
        {
            liquidacionRepository = new LiquidacionRepository();
            liquidacionList = liquidacionRepository.ConsultarTodos();

        }

        public string Guardar(Liquidacion liquidacion)
        {
            if (liquidacion == null)
            {
                return $"No se pueden agregar espacios nulos";
            }
            return (liquidacionRepository.Guardar(liquidacion));
        }

        public List<Liquidacion> ConsultarTodos()
        {
            return liquidacionList;
        }

        public string EliminarRegistro(string Eliminar_ID)
        {
            try
            {
                var eliminarRegistro = liquidacionList.FirstOrDefault(p => p.IDPaciente == Eliminar_ID);

                if (eliminarRegistro != null)
                {
                    liquidacionList.Remove(eliminarRegistro);
                    var liquidacion = new DAL.LiquidacionRepository();
                    var LiquidacionList = liquidacion.Guardar(liquidacionList);
                    return "Registro de paciente eliminado correctamente";
                }
                else
                {
                    return "No se encontró un registro con el ID proporcionado.";
                }
            }
            catch (IOException)
            {
                return "Ocurrió un error al intentar eliminar el registro.";
            }
        }

        private Liquidacion ObtenerPeciente(string id)
        {
            foreach (var item in liquidacionList)
            {
                if (id == item.IDPaciente)
                {
                    return item;
                }
            }
            return null;

        }

    }
}