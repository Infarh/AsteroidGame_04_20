using System;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args) // Ctrl+K,D
        {
            //Player player1 = new Player();
            //player1.Name = "Иванов";
            //player1.Birthday = new DateTime(1974, 12, 21, 0, 0, 0);

            Player player1 = new Player("Empty", new DateTime(1987, 12, 12));

            Console.Write("Введите фамилию >");
            player1.Name = Console.ReadLine();

            Console.WriteLine(player1.Name);

            Console.ReadLine();
        }
    }
}
