public static class Classmenu
{
    public static int pokazhimenu(string[] options)
    {
        int selectedOption = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт:");
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }

                Console.WriteLine(options[i]);
            }

            Console.WriteLine(new string('-', 40));

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedOption > 0)
                    {
                        selectedOption--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (selectedOption < options.Length - 1)
                    {
                        selectedOption++;
                    }
                    break;

                case ConsoleKey.Enter:
                    return selectedOption;
            }
        }
    }
}
