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

            Console.Write("Введите фамилию >");
            var surname = Console.ReadLine();

            Player player1 = new Player(surname, new DateTime(1987, 12, 12));


            Console.WriteLine(player1.GetName());

            Console.ReadLine();
        }
    }

    internal class Player
    {
        private string _Name;
        private DateTime _Birthday;

        public string GetName()
        {
            return _Name;
        }

        public void SetName(string Name)
        {
            _Name = Name;
        }

        public Player()
        {

        }

        public Player(string Name)
        {
            //Name = Name;
            this._Name = Name;
            _Birthday = DateTime.Now;
        }

        public Player(string Name, DateTime Birthday)
            : this(Name)
        {
            //this.Name = Name;
            this._Birthday = Birthday;
        }
    }
}
