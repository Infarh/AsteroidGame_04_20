using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Models
{
    internal class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }


        private string _Name;

        public string Name
        {
            get => _Name;
            set
            {
                if(_Name == value) return;
                _Name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public StudentsGroup Group { get; set; }
    }
}
