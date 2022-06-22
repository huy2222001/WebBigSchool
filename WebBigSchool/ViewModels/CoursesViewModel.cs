using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBigSchool.Models;

namespace WebBigSchool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}