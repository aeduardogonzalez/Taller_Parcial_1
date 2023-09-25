using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    //public class LiquidacionRepository
    //{
    //    string filename = "Liquidacion.txt";
    //    public string Guardar(Liquidacion liquidacion)
    //    {
    //        var writer = new StreamWriter(filename, true);
    //        writer.WriteLine(liquidacion.ToString());
    //        writer.Close();
    //        return $"Se ha guardado al paciente {liquidacion.NombrePaciente} correctamente";
    //    }
    //    public string Guardar(List<Liquidacion> liquidacionList)
    //    {
    //        var writer = new StreamWriter(filename);
    //        foreach (var i in liquidacionList)
    //        {
    //            writer.WriteLine(i.ToString());
    //        }
    //        writer.Close();
    //        return "Se han hecho los registros correctamente";
    //    }

    //    public List<Liquidacion> ConsultarTodos()
    //    {
    //        var liquidacionList = new List<Liquidacion>();
    //        try
    //        {
    //            StreamReader reader = new StreamReader(filename);
    //            while (!reader.EndOfStream)
    //            {
    //                liquidacionList.Add(map(reader.ReadLine()));
    //            }
    //            reader.Close();
    //            return liquidacionList;
    //        }
    //        catch (IOException)
    //        {
    //            return null;
    //        }
    //    }
    //    private Liquidacion map(string linea)
    //    {
    //        var liquidacion = new Liquidacion();
    //        liquidacion.IDLiquidacion = int.Parse(linea.Split(';')[0]);
    //        liquidacion.IDPaciente = linea.Split(';')[1];
    //        liquidacion.NombrePaciente = linea.Split(';')[2];
    //        liquidacion.TipoAfiliacion = char.Parse(linea.Split(';')[3]);
    //        liquidacion.SalarioPaciente = double.Parse(linea.Split(';')[4]);
    //        liquidacion.ValorServicio = double.Parse(linea.Split(';')[5]);
    //        liquidacion.ValorLiquidado = double.Parse(linea.Split(';')[6]);

    //        return liquidacion;
    //    }
    //}
}