using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//사용 안하는데 테스트해보려고 만들어놓음!!!!
namespace Project_Manage.Model
{
    public class User
    {
        public User(string name, string job, string department, string team)
        {
            _Name = name;
            _Job = job;
            _Department = department;
            _Team = team;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value.Length > 50)
                    Console.WriteLine("이름은 50자를 넘을 수 없습니다.");
                else
                    _Name = value;
            }
        }

        private string _Job;
        public string Job
        {
            get { return _Job; }
            set { _Job = value; }
        }

        private string _Department;
        public string Department

        {
            get { return _Department; }
            set { _Department = value; }
        }

        private string _Team;
        public string Team

        {
            get { return _Team; }
            set { _Team = value; }
        }
    }
}
