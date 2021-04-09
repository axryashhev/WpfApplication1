using System;
using System.Collections.Generic;
using WpfApplication1.Models;

namespace WpfApplication1.Controller
{
    public class MainController
    {
        private static MainController _instance;
        public List<Student> Students { get; set; }
        public List<ScientificAdvisor> ScientificAdvisors { get; set; }
        private MainController()
        {
            var students = new List<Student>();
            students.Add(new Student {Id = 0, Name = "Name0", Group = "Group0", Sex = 'Ж', Date = "01.02.2002", AveragePoint = 4.32, IdScientificAdvisor = 0});
            students.Add(new Student {Id = 1, Name = "Name1", Group = "Group1", Sex = 'M', Date = "03.01.2002", AveragePoint = 3.12, IdScientificAdvisor = 1});
            students.Add(new Student {Id = 2, Name = "Name2", Group = "Group2", Sex = 'Ж', Date = "02.04.2002", AveragePoint = 4.44, IdScientificAdvisor = 2});
            students.Add(new Student {Id = 3, Name = "Name3", Group = "Group3", Sex = 'M', Date = "01.03.2002", AveragePoint = 3.34, IdScientificAdvisor = 1});
            students.Add(new Student {Id = 4, Name = "Name4", Group = "Group4", Sex = 'Ж', Date = "04.02.2002", AveragePoint = 4.54, IdScientificAdvisor = 2});

            var scientificAdvisors = new List<ScientificAdvisor>();
            scientificAdvisors.Add(new ScientificAdvisor{Id = 1, Name = "Name0", Position = "Position0"});
            scientificAdvisors.Add(new ScientificAdvisor{Id = 2, Name = "Name1", Position = "Position1"});
            scientificAdvisors.Add(new ScientificAdvisor{Id = 3, Name = "Name2", Position = "Position0"});

            this.Students = students;
            this.ScientificAdvisors = scientificAdvisors;
        }

        public static MainController GetInstance()
        {
            if (_instance == null)
                _instance = new MainController();
            return _instance;
        }
        
        public string OutputListData<T>(List<T> listOutput)
        {
            string result = "";
            foreach (var item in listOutput)
            {
                var type = item.GetType();
                var properties = type.GetProperties();
                for(int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    result += property.Name + ": " + property.GetValue(item, null)  + '\n';
                }  
                result += '\n';
            }
            

            return result;
        }
    }
}