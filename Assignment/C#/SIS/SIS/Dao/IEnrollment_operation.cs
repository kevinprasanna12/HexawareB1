using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Dao
{
    public interface IEnrollment_operation
    {
        void GetStudent(string studentname, string lastname);
        void GetCourse(int enrollid);
        void ReportGeneration(string coursename);
    }
}
