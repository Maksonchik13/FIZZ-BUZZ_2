try
{
    Console.Write("Введите колличество игроков  ");
    int n = int.Parse(Console.ReadLine());
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("----------------------------------------------------------------");
    long spisok = n;
    int count = 0;
    bool error = false;

    for (int i = n - 1; i >= 1; i--)
    {
        spisok = spisok * 10 + i;
    }


    while (n > 1 && count <= 100)
    {
        long spisok_izm = spisok;
        //Console.WriteLine(spisok);
        while (spisok_izm > 0)
        {
            if (n == 1 || count > 100) break;
            int hod;
            long a = spisok_izm % 10;
            spisok_izm /= 10;
            do
            {
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("ход игрока  " + a);
                Console.Write("cейчас число  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(count);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Введите ответ: 1: '{count + 1}', 2: 'FIZZ', 3: 'BUZZ', 4: 'FIZZ-BUZZ' ");
                hod = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine();
                switch (hod)
                {
                    case 1:
                        if ((count + 1) % 3 != 0 && (count + 1) % 5 != 0) count += 1;
                        else error = true;
                        break;
                    case 2:
                        if ((count + 1) % 3 == 0 && (count + 1) % 5 != 0) count += 1;
                        else error = true; break;
                    case 3:
                        if ((count + 1) % 5 == 0 && (count + 1) % 3 != 0) count += 1;
                        else error = true; break;
                    case 4:
                        if ((count + 1) % 3 == 0 && (count + 1) % 5 == 0) count += 1;
                        else error = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Вы НЕВЕРНО ввели ответ!!! Введите ответ снова.");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }
                if (error)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("-------------------------");
                    Console.WriteLine($"Игрок {a} выбыл");
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    long index = a;
                    n--;
                    long perepis = spisok;
                    spisok = 0;
                    while (perepis > 0)
                    {
                        long b = perepis % 10;
                        perepis /= 10;
                        if (index == b) continue;
                        else spisok = spisok * 10 + b;
                    }
                    while (spisok > 0)
                    {
                        long c = spisok % 10;
                        spisok /= 10;
                        perepis = perepis * 10 + c;
                    }
                    spisok = perepis;
                }
                error = false;
            }
            while (hod <= 0 || hod > 4);
        }
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("--------------------------------------------------------------------------------------");
    if (n == 1)
    {
        Console.WriteLine("Игра окончена!");
        Console.WriteLine();
        Console.WriteLine($"Победил игрок номер '{spisok}'");
    }
    else
    {
        Console.WriteLine("Похоже у нас ничья!");
        Console.WriteLine();
        Console.Write("Победили игроки под номерами: ");
        while (spisok > 0)
        {
            long c = spisok % 10;
            spisok /= 10;
            Console.Write($"'{c}' ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("--------------------------------------------------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
}
catch
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("----------------------");
    Console.WriteLine("ПРОИЗОШЛА ОШИБКА");
    Console.WriteLine("----------------------");
    Console.ForegroundColor = ConsoleColor.White;
}