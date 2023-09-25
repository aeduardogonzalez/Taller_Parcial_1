using Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.BufferHeight = Console.LargestWindowHeight;
            Console.BufferWidth = Console.LargestWindowWidth;

            Program programa = new Program();
            programa.menuPrincipal();
        }

        public void menuPrincipal()
        {
            int OP;
            char Opcion = 'S';

            Console.SetCursorPosition(40, 6); Console.WriteLine("IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(35, 7); Console.WriteLine("Andres Gonzalez y Juan Carmona");
            Console.SetCursorPosition(48, 10); Console.WriteLine("MENU");
            Console.SetCursorPosition(26, 12); Console.WriteLine("1. Registrar Paciente");
            Console.SetCursorPosition(26, 13); Console.WriteLine("2. Consultar Paciente");
            Console.SetCursorPosition(26, 14); Console.WriteLine("3. Eliminar Paciente");
            Console.SetCursorPosition(26, 15); Console.WriteLine("4. Salir");
            do
            {
                Console.SetCursorPosition(26, 18); Console.WriteLine("Escoja una opcion: ");
                Console.SetCursorPosition(50, 18); OP = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(50, 18); Console.WriteLine("         ");
                Console.SetCursorPosition(26, 22); Console.WriteLine("Por favor elija una opción válida");
            } while ((OP < 1) || (OP > 4));
            Console.SetCursorPosition(26, 18); Console.WriteLine("                                     ");
            Console.SetCursorPosition(26, 21); Console.WriteLine("                                     ");

            while (Opcion == 'S')
            {
                switch (OP)
                {
                    case 1:
                        Console.Clear();
                        registrar();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        MostrarRegistro();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        EliminarRegistro();
                        Console.Clear();
                        break;
                    case 4:
                        Opcion = 'N';
                        break;
                }
            }
        }

        static void registrar()
        {
            char Option = 'S';
            while (Option == 'S')
            {
                try
                {
                    titulos();
                    Console.SetCursorPosition(35, 11); Console.WriteLine("ID de liquidacion        : ");
                    Console.SetCursorPosition(35, 12); Console.WriteLine("ID del paciente          : ");
                    Console.SetCursorPosition(35, 13); Console.WriteLine("Nombre del Paciente      : ");
                    Console.SetCursorPosition(35, 14); Console.WriteLine("Tipo de afiliación       : ");
                    Console.SetCursorPosition(35, 15); Console.WriteLine("Salario Del Paciente     : ");
                    Console.SetCursorPosition(35, 16); Console.WriteLine("Valor del servicio       : ");

                    Liquidacion liquidado = new Liquidacion();

                    Console.SetCursorPosition(62, 11); liquidado.IDLiquidacion = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(62, 12); liquidado.IDPaciente = Console.ReadLine();
                    Console.SetCursorPosition(62, 13); liquidado.NombrePaciente = Console.ReadLine();

                    do
                    {
                        Console.SetCursorPosition(35, 20); Console.WriteLine("Digite S: Subsidiado C: Contributivo");
                        Console.SetCursorPosition(62, 14); liquidado.TipoAfiliacion = Char.Parse(Console.ReadLine().ToUpper());
                        Console.SetCursorPosition(35, 20); Console.WriteLine("                                     ");
                    } while ((liquidado.TipoAfiliacion != 'S') && (liquidado.TipoAfiliacion != 'C'));

                    do
                    {
                        Console.SetCursorPosition(62, 15); liquidado.SalarioPaciente = double.Parse(Console.ReadLine());
                    } while (liquidado.SalarioPaciente < 0);

                    do
                    {
                        Console.SetCursorPosition(62, 16); liquidado.ValorServicio = Convert.ToDouble(Console.ReadLine());
                    } while (liquidado.ValorServicio < 0);

                    liquidado.CuotaModeradora();

                    var Service = new BLL.LiquidacionService();
                    Console.SetCursorPosition(35, 20); Console.WriteLine(Service.Guardar(liquidado));
                    do
                    {
                        Console.SetCursorPosition(35, 22); Console.WriteLine("¿Desea hacer otro registro? S/N: ");
                        Console.SetCursorPosition(68, 22); Option = Char.Parse(Console.ReadLine());
                        Option = char.ToUpper(Option);
                        Console.Clear();
                    } while ((Option != 'S') && (Option != 'N'));
                }
                catch (IOException)
                {
                    Console.SetCursorPosition(35, 25); Console.Write("Ingresa los datos válidos");
                }
            }
        }

        static void MostrarRegistro()
        {
            titulos();
            try
            {

                Console.SetCursorPosition(20, 15); Console.WriteLine("ID LIQUIDACION  ID PACIENTE        NOMBRE PACIENTE               TIPO AFILIACION     SALARIO PACIENTE   VALOR SERVICIO    CUOTA MODERADORA ");


                var service = new BLL.LiquidacionService();
                var liquidacionList = service.ConsultarTodos();
                if (liquidacionList == null)
                {
                    Console.Clear();
                    Console.WriteLine("archivo sin datos ");
                    Console.ReadKey();
                }
                foreach (var item in liquidacionList)
                {
                    Console.SetCursorPosition(20, 17); Console.WriteLine(item.IDLiquidacion);
                    Console.SetCursorPosition(36, 17); Console.WriteLine(item.IDPaciente);
                    Console.SetCursorPosition(55, 17); Console.WriteLine(item.NombrePaciente);
                    Console.SetCursorPosition(85, 17); Console.WriteLine(item.TipoAfiliacion);
                    Console.SetCursorPosition(105, 17); Console.WriteLine(item.SalarioPaciente);
                    Console.SetCursorPosition(130, 17); Console.WriteLine(item.ValorServicio);
                    Console.SetCursorPosition(148, 17); Console.WriteLine(item.ValorLiquidado);
                }
                Console.SetCursorPosition(41, 30); Console.WriteLine("Presione cualquier tecla para continuar.");
                Console.SetCursorPosition(41, 31); Console.ReadKey();
                Console.Clear();
            }
            catch (IOException)
            {
                Console.SetCursorPosition(35, 20); Console.Write("Perdón por el error, no hay registros que mostrar.");
            }
        }

        static void EliminarRegistro()
        {
            Console.Clear();
            titulos();
            Console.SetCursorPosition(20, 11); Console.Write("Por favor escriba el # de identificacion del paciente que desea eliminar del archivo: ");
            Console.SetCursorPosition(108, 11); string idAEliminar = Console.ReadLine();

            var service = new BLL.LiquidacionService();
            var mensaje = service.EliminarRegistro(idAEliminar);

            Console.SetCursorPosition(30, 13); Console.WriteLine(mensaje);
            Console.SetCursorPosition(30, 15); Console.WriteLine("Presione Enter para continuar.");
            Console.SetCursorPosition(50, 15); Console.ReadLine();
        }

        static void titulos()
        {
            Console.SetCursorPosition(40, 6); Console.WriteLine("IPS MAS SALUD Y VIDA");
            Console.SetCursorPosition(35, 7); Console.WriteLine("Andres Gonzalez y Juan Carmona");
        }
    }
}