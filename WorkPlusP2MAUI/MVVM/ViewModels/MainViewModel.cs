using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkPlusP2MAUI.MVVM.Models;


namespace WorkPlusP2MAUI.MVVM.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        public MainViewModel() 
        {
            FillData();
        }

        private void FillData()
        {
            Categories = new ObservableCollection<Category>
               {
                    new Category
                    {
                         Id = 1,
                         CategoryName = "UDLA",
                         Color = "#CF14DF"
                    },
                    new Category
                    {
                         Id = 2,
                         CategoryName = "Programación",
                         Color = "#df6f14"
                    },
                    new Category
                    {
                         Id = 3,
                         CategoryName = "To Do",
                         Color = "#14df80"
                    }
            };

            Tasks = new ObservableCollection<MyTask>
               {
                    new MyTask
                    {
                         TaskName = "Curso Microsoft Learn",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Proyecto Progreso 2",
                         Completed = false,
                         CategoryId = 1
                    },
                    new MyTask
                    {
                         TaskName = "Base de Datos",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Computación Ubicua",
                         Completed = false,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Nadar",
                         Completed = true,
                         CategoryId = 2
                    },
                    new MyTask
                    {
                         TaskName = "Estudiar",
                         Completed = false,
                         CategoryId = 3
                    },
                    new MyTask
                    {
                         TaskName = "Aprender a volar",
                         Completed = false,
                         CategoryId = 3
                    },
            };

            ActualizarInformacion();
        }

        public void ActualizarInformacion()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;

                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
