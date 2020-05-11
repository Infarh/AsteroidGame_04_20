using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StudentsManager.ViewModels.Base;

namespace StudentsManager.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _Title = "Редактор студентов";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов к труду и обороне!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }


        public ObservableCollection<Group> StudentGroups { get; } = new ObservableCollection<Group>();


        public StudentGroupsViewModel StudenGroupsModel { get; } = new StudentGroupsViewModel();

        public StudentsViewModel StudentsModel { get; } = new StudentsViewModel(); 
    }
}
