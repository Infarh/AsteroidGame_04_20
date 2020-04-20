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

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        public string Surname { get; set; } = "qwe";

        public Player()
        {
            Surname = "123";
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
