using System.Collections.Generic;

namespace ClassesMap
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<MiembroDeLaComunidad> comunidad = new List<MiembroDeLaComunidad>();

                comunidad.Add(new Estudiante
                {
                    Nombre = "Darlyn Feliz",
                    Matricula = "2025-1008"
                });

                comunidad.Add(new Maestro
                {
                    Nombre = "Starling Germosen",
                    Materia = "Programacion"
                });

                comunidad.Add(new Administrativo
                {
                    Nombre = "Juan Caballo",
                    Departamento = "Finanzas"
                });

                comunidad.Add(new ExAlumno
                {
                    Nombre = "Luis Rodriguez",
                    AnoGraduacion = 2027
                });

                foreach (var miembro in comunidad)
                {
                    Console.WriteLine(
                        $"Nombre: {miembro.Nombre} | Tipo: {miembro.GetType().Name}"
                    );
                }

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error durante la ejecución del programa.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
