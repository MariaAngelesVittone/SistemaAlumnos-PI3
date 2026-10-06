using SistemaAlumnos;

List<Alumno> alumnos = new List<Alumno>();

List<Materia> materias = new List<Materia>();
materias.Add(new Materia("PROG1", "Programación I", 128));
materias.Add(new Materia("BD1", "Base de Datos I", 96));

int opcion = 0;

while (opcion != 6)
{
    Console.WriteLine();
    Console.WriteLine("1. Agregar alumno");
    Console.WriteLine("2. Listar alumnos");
    Console.WriteLine("3. Buscar alumno por legajo");
    Console.WriteLine("4. Promedio general del curso");
    Console.WriteLine("5. Cantidad de aprobados");
    Console.WriteLine("6. Salir");
    Console.Write("Elija una opción: ");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        opcion = 0;
    }

    switch (opcion)
    {
        case 1:
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Legajo: ");
            int legajo = int.Parse(Console.ReadLine());
            Console.Write("Nota 1: ");
            decimal nota1 = decimal.Parse(Console.ReadLine());
            Console.Write("Nota 2: ");
            decimal nota2 = decimal.Parse(Console.ReadLine());

            Alumno nuevo = new Alumno(nombre, legajo);
            if (nuevo.CargarNotas(nota1, nota2))
            {
                alumnos.Add(nuevo);
                Console.WriteLine("Alumno agregado.");
            }
            else
            {
                Console.WriteLine("Las notas deben estar entre 0 y 10. No se agregó el alumno.");
            }
            break;

        case 2:
            if (alumnos.Count == 0)
            {
                Console.WriteLine("No hay alumnos cargados.");
            }
            foreach (Alumno a in alumnos)
            {
                Console.WriteLine(a);
            }
            break;

        case 3:
            Console.Write("Legajo a buscar: ");
            int buscado = int.Parse(Console.ReadLine());
            Alumno encontrado = null;
            foreach (Alumno a in alumnos)
            {
                if (a.Legajo == buscado)
                {
                    encontrado = a;
                }
            }
            if (encontrado == null)
            {
                Console.WriteLine("No existe un alumno con ese legajo.");
            }
            else
            {
                Console.WriteLine(encontrado);
            }
            break;

        case 4:
            if (alumnos.Count == 0)
            {
                Console.WriteLine("Todavía no hay alumnos.");
            }
            else
            {
                decimal suma = 0;
                foreach (Alumno a in alumnos)
                {
                    suma += a.Promedio();
                }
                Console.WriteLine("Promedio general: " + suma / alumnos.Count);
            }
            break;

        case 5:
            int aprobados = 0;
            foreach (Alumno a in alumnos)
            {
                if (a.EstaAprobado())
                {
                    aprobados++;
                }
            }
            Console.WriteLine("Aprobados: " + aprobados);
            break;

        case 6:
            Console.WriteLine("Hasta luego.");
            break;

        default:
            Console.WriteLine("Opción inexistente.");
            break;
    }
}

Alumno ana = new Alumno("Ana Pérez", 30111222, 1234);
ana.CargarNotas(7, 7);
Profesor marta = new Profesor("Marta Díaz", 25333444, "Programación");
Preceptor luis = new Preceptor("Luis Gómez", 28555666, "2°A");

List<Persona> personas = new List<Persona>();
personas.Add(ana);
personas.Add(marta);
personas.Add(luis);

foreach (Persona p in personas)
{
    Console.WriteLine(p.Presentarse());
}

List<IExportable> exportables = new List<IExportable>();
exportables.Add(ana);
exportables.Add(marta);
foreach (Materia m in materias)
{
    exportables.Add(m);
}

foreach (IExportable e in exportables)
{
    Console.WriteLine(e.ExportarLinea());
}
