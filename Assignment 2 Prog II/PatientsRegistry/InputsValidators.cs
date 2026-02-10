namespace ManusHospital
{
    public static class InputValidator
    {
        public static string VerifyLettersOnly(string input)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$");

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("This field requires letters only. Try again:");
                System.Console.ResetColor();
                input = System.Console.ReadLine() ?? "";
            }

            return input.Trim();
        }

        public static string VerifyCedula(string input)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^\d{3}-\d{7}-\d$");

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Invalid Dominican National ID (cedula). Format: ###-#######-#");
                System.Console.ResetColor();
                input = System.Console.ReadLine() ?? "";
            }

            return input.Trim();
        }

        public static string VerifyPhone(string input)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");

            while (string.IsNullOrWhiteSpace(input) || !regex.IsMatch(input))
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Phone must contain digits only (no spaces or letters).");
                System.Console.ResetColor();
                input = System.Console.ReadLine() ?? "";
            }

            return input.Trim();
        }

        public static int VerifyAge()
        {
            int age;

            while (!int.TryParse(System.Console.ReadLine(), out age) || age < 0 || age > 120)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Invalid age. Enter a number between 0 and 120:");
                System.Console.ResetColor();
            }

            return age;
        }
    }
}
