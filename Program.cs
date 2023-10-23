public class Zakaz
{
    private decimal itogovayacena = 0;
    private string userVibor = "";

    private decimal[][] tortcena = {
        new decimal[] { 350, 450, 200, 700 },
        new decimal[] { 100, 200, 300, 400 },
        new decimal[] { 150, 150, 300, 500 },
        new decimal[] { 200, 300, 400, 500 }
    };

    private string[][] Variantitorti = {
        new string[] { "Круг - 350 рублей", "Квадрат - 450 рублей", "Треугольник - 200 рублей", "Сердце - 700 рублей" },
        new string[] { "Маленький (4 порции) - 100 рублей", "Средний (6 порций) - 200 рублей", "Большой (8 порций) - 300 рублей", "Именинный (10 порций) - 400 рублей" },
        new string[] { "Шоколадный - 150 рублей", "Ванильный - 150 рублей", "Ягодный - 300 рублей", "Смешанный (Шоколадный, Ванильный, Ягодный) - 500 рублей" },
        new string[] { "4 коржа - 200 рублей", "6 коржей - 300 рублей", "8 коржей - 400 рублей", "10 коржей - 500 рублей" }
    };

    private string[] haracteristiki = { "Форма торта", "Размер торта", "Вкус коржей", "Количество коржей", "Сделать новый заказ" };

    public void SozdanieZakaza()
    {
        int ViborPosicii = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в кондитерскую!");
            Console.WriteLine("Выберите пункт меню:");
            Console.WriteLine(new string('-', 40));

            for (int i = 0; i < haracteristiki.Length; i++)
            {
                if (i == ViborPosicii)
                {
                    Console.Write("-> ");
                }
                else
                {
                    Console.Write("   ");
                }

                Console.WriteLine(haracteristiki[i]);
            }

            Console.WriteLine(new string('-', 40));
            Console.WriteLine($"Стоимость торта: {itogovayacena} руб.");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Ваш торт: " + userVibor);

            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (ViborPosicii > 0)
                    {
                        ViborPosicii--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (ViborPosicii < haracteristiki.Length - 1)
                    {
                        ViborPosicii++;
                    }
                    break;

                case ConsoleKey.Enter:
                    if (ViborPosicii == haracteristiki.Length - 1)
                    {
                        sohranenievfaile();
                        itogovayacena = 0;
                        userVibor = "";
                    }
                    else
                    {
                        int usermenuvibor = Classmenu.pokazhimenu(Variantitorti[ViborPosicii]);
                        decimal price = tortcena[ViborPosicii][usermenuvibor];
                        itogovayacena += price;
                        if (!string.IsNullOrEmpty(userVibor))
                        {
                            userVibor += ", ";
                        }
                        userVibor += $"{haracteristiki[ViborPosicii]} - {Variantitorti[ViborPosicii][usermenuvibor]}";
                    }
                    break;

                case ConsoleKey.Escape:
                    userVibor = "";
                    break;
            }
        }
    }

    public void sohranenievfaile()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = Path.Combine(desktopPath, "Заказ.txt");
        string orderDetails = $"{DateTime.Now}: Ваш торт: {userVibor}, Суммарная цена: {itogovayacena} руб.";
        File.AppendAllText(fileName, orderDetails + Environment.NewLine);
        Console.WriteLine($"Заказ сохранен на рабочем столе в файл 'Заказ.txt'");
    }
}



