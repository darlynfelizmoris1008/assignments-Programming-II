namespace ManusHospital
{
    public static class PatientsApp
    {
        public static void Run()
        {
            var manager = new PatientManager();
            bool running = true;

            while (running)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to: Manus Hospital Patient Registry!!");
                System.Console.WriteLine("1. Register Patient");
                System.Console.WriteLine("2. List Patients");
                System.Console.WriteLine("3. Edit Patient");
                System.Console.WriteLine("4. Delete Patient");
                System.Console.WriteLine("5. Exit");
                System.Console.WriteLine();
                System.Console.Write("Enter the desired option number: ");

                int option;

                while (!int.TryParse(System.Console.ReadLine(), out option))
                {
                    System.Console.Write("Invalid option. Please enter a number: ");
                }

                switch (option)
                {
                    case 1:
                        manager.AddPatient();
                        break;

                    case 2:
                        manager.ListPatients();
                        break;

                    case 3:
                        manager.EditPatient();
                        break;

                    case 4:
                        manager.DeletePatient();
                        break;
                    case 5:
                        running = false;
                        break;

                    default:
                        System.Console.ForegroundColor = System.ConsoleColor.Red;
                        System.Console.WriteLine("Invalid option. Please choose a valid menu number.");
                        System.Console.ResetColor();
                        System.Console.WriteLine("\nPress any key to continue...");
                        System.Console.ReadKey(true);
                        break;
                }

                System.Console.WriteLine();
            }
        }
    }
}

