using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Alvin Cesar Sanchez Ochoa Alvarez
namespace PatronBuilder
{
    // Clase Producto: Representa el objeto complejo que queremos construir
    public class Computadora
    {
        public string Procesador { get; set; } // Procesador de la computadora
        public int RAM { get; set; } // Memoria RAM en GB
        public string Almacenamiento { get; set; } // Tipo y tamaño del almacenamiento

        // Método para mostrar las especificaciones de la computadora
        public void MostrarEspecificaciones()
        {
            Console.WriteLine($"Computadora con Procesador: {Procesador}, RAM: {RAM}GB, Almacenamiento: {Almacenamiento}");
        }
    }

    // Interfaz Builder: Define los métodos para construir cada parte del objeto
    public interface IComputadoraBuilder
    {
        void DefinirProcesador(string procesador);
        void DefinirRAM(int ram);
        void DefinirAlmacenamiento(string almacenamiento);
        Computadora ObtenerComputadora();
    }

    // Implementación concreta del Builder
    public class ComputadoraGamerBuilder : IComputadoraBuilder
    {
        private Computadora _computadora = new Computadora(); // Instancia del producto

        // Métodos para definir cada parte de la computadora
        public void DefinirProcesador(string procesador) => _computadora.Procesador = procesador;
        public void DefinirRAM(int ram) => _computadora.RAM = ram;
        public void DefinirAlmacenamiento(string almacenamiento) => _computadora.Almacenamiento = almacenamiento;

        // Devuelve la computadora ya construida
        public Computadora ObtenerComputadora() => _computadora;
    }

    // Clase Director: Se encarga de gestionar el proceso de construcción
    public class Director
    {
        private IComputadoraBuilder _builder;

        // Se recibe un Builder para poder construir el objeto
        public Director(IComputadoraBuilder builder)
        {
            _builder = builder;
        }

        // Método que define un proceso específico de construcción
        public void ConstruirComputadoraGamer()
        {
            _builder.DefinirProcesador("Intel Core i9");
            _builder.DefinirRAM(32);
            _builder.DefinirAlmacenamiento("1TB SSD");
        }
    }

    // Programa Principal
    class Program
    {
        static void Main()
        {
            // Crear un builder específico (para computadoras gamer en este caso)
            IComputadoraBuilder builder = new ComputadoraGamerBuilder();

            // Crear un director que controle el proceso de construcción
            Director director = new Director(builder);

            // Construir la computadora gamer
            director.ConstruirComputadoraGamer();

            // Obtener el producto final
            Computadora computadora = builder.ObtenerComputadora();

            // Mostrar las especificaciones de la computadora construida
            computadora.MostrarEspecificaciones();

            // Pausar la consola para ver el resultado
            Console.ReadLine();
        }
    }
}