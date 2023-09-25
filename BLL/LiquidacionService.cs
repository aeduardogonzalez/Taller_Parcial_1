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
    //public class LiquidacionService
    //{
    //    private LiquidacionRepository liquidacionRepository = null;
    //    private List<Liquidacion> liquidacionList = null;

    //    public LiquidacionService()
    //    {
    //        liquidacionRepository = new LiquidacionRepository();
    //        liquidacionList = liquidacionRepository.ConsultarTodos();

    //    }

    //    public String Guardar(Liquidacion liquidacion)
    //    {
    //        if (liquidacion == null)
    //        {
    //            return $"No se pueden agregar espacios nulos";
    //        }
    //        return (liquidacionRepository.Guardar(liquidacion));
    //    }

    //    public List<Liquidacion> ConsultarTodos()
    //    {
    //        return liquidacionList;
    //    }

    //    //public string EliminarRegistro(string idAEliminar)
    //    //{
    //    //    try
    //    //    {
    //    //        var productoAEliminar = productoList.FirstOrDefault(p => p.IdPaciente == idAEliminar);

    //    //        if (productoAEliminar != null)
    //    //        {
    //    //            productoList.Remove(productoAEliminar);
    //    //            productoRepository.Guardar(productoList);
    //    //            return "Registro eliminado con éxito.";
    //    //        }
    //    //        else
    //    //        {
    //    //            return "No se encontró un registro con el ID proporcionado.";
    //    //        }
    //    //    }
    //    //    catch (IOException)
    //    //    {
    //    //        return "Ocurrió un error al intentar eliminar el registro.";
    //    //    }
    //    //}
    //}
}