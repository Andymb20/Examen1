using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAPP
{
    public class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }

        public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }

    public class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenu()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Agregar Empleado");
                Console.WriteLine("2. Consultar Empleado");
                Console.WriteLine("3. Modificar Empleado");
                Console.WriteLine("4. Borrar Empleado");
                Console.WriteLine("5. Inicializar Arreglos");
                Console.WriteLine("6. Reportes");
                Console.WriteLine("0. Salir");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarEmpleado();
                            break;
                        case 2:
                            ConsultarEmpleado();
                            break;
                        case 3:
                            ModificarEmpleado();
                            break;
                        case 4:
                            BorrarEmpleado();
                            break;
                        case 5:
                            InicializarArreglos();
                            break;
                        case 6:
                            MostrarMenuReportes();
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una opción válida.");
                }
            } while (opcion != 0);
        }

        public void AgregarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado:");
            string cedula = Console.ReadLine();

            // Comprobar si el empleado ya existe
            if (empleados.Exists(e => e.Cedula == cedula))
            {
                Console.WriteLine("El empleado con esta cédula ya existe.");
                return;
            }

            Console.WriteLine("Ingrese el nombre del empleado:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese la dirección del empleado:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese el teléfono del empleado:");
            string telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el salario del empleado:");
            if (decimal.TryParse(Console.ReadLine(), out decimal salario))
            {
                empleados.Add(new Empleado(cedula, nombre, direccion, telefono, salario));
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("Ingrese un salario válido.");
            }
        }

        public void ConsultarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a consultar:");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Empleado encontrado:");
                Console.WriteLine("Cédula: {empleado.Cedula}");
                Console.WriteLine("Nombre: {empleado.Nombre}");
                Console.WriteLine("Dirección: {empleado.Direccion}");
                Console.WriteLine("Teléfono: {empleado.Telefono}");
                Console.WriteLine("Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ModificarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a modificar:");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre del empleado:");
                string nombre = Console.ReadLine();
                empleado.Nombre = nombre;

                Console.WriteLine("Ingrese la nueva dirección del empleado:");
                string direccion = Console.ReadLine();
                empleado.Direccion = direccion;

                Console.WriteLine("Ingrese el nuevo teléfono del empleado:");
                string telefono = Console.ReadLine();
                empleado.Telefono = telefono;

                Console.WriteLine("Ingrese el nuevo salario del empleado:");
                if (decimal.TryParse(Console.ReadLine(), out decimal salario))
                {
                    empleado.Salario = salario;
                    Console.WriteLine("Empleado modificado con éxito.");
                }
                else
                {
                    Console.WriteLine("Ingrese un salario válido.");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a borrar:");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado eliminado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void InicializarArreglos()
        {
            // Lógica para inicializar arreglos si es necesario
        }

        public void MostrarMenuReportes()
        {
            int opcion;
            do
            {
                Console.WriteLine("Menú de Reportes:");
                Console.WriteLine("1. Consultar empleados por número de cédula");
                Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
                Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
                Console.WriteLine("4. Calcular y mostrar el salario más alto y más bajo");
                Console.WriteLine("0. Volver al Menú Principal");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Ingrese la cédula del empleado a consultar:");
                            string cedula = Console.ReadLine();
                            ConsultarEmpleadoPorCedula(cedula);
                            break;
                        case 2:
                            ListarEmpleadosOrdenadosPorNombre();
                            break;
                        case 3:
                            CalcularPromedioSalarios();
                            break;
                        case 4:
                            CalcularSalarioMaximoYMinimo();
                            break;
                        case 0:
                            Console.WriteLine("Volviendo al Menú Principal.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingrese una opción válida.");
                }
            } while (opcion != 0);
        }

        public void ConsultarEmpleadoPorCedula(string cedula)
        {
            Empleado empleado = empleados.Find(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Empleado encontrado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ListarEmpleadosOrdenadosPorNombre()
        {
            empleados.Sort((e1, e2) => e1.Nombre.CompareTo(e2.Nombre));
            Console.WriteLine("Empleados ordenados por nombre:");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
            }
        }

        public void CalcularPromedioSalarios()
        {
            if (empleados.Count > 0)
            {
                decimal totalSalarios = empleados.Sum(e => e.Salario);
                decimal promedioSalarios = totalSalarios / empleados.Count;
                Console.WriteLine($"El promedio de los salarios es: {promedioSalarios}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
            }
        }

        public void CalcularSalarioMaximoYMinimo()
        {
            if (empleados.Count > 0)
            {
                decimal salarioMaximo = empleados.Max(e => e.Salario);
                decimal salarioMinimo = empleados.Min(e => e.Salario);
                Console.WriteLine($"Salario más alto: {salarioMaximo}");
                Console.WriteLine($"Salario más bajo: {salarioMinimo}");
            }
            else
            {
                Console.WriteLine("No hay empleados para calcular salarios máximos y mínimos.");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            Menu menu = new Menu();
            menu.MostrarMenu();
        }
    }
}
