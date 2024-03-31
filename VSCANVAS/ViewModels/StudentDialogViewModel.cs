﻿using Library.VSCANVAS.Models;
using Library.VSCANVAS.Services;

namespace VSCANVAS.ViewModels
{
    public class StudentDialogViewModel
    {
        private Student? student;

        public string Name
        {
            get
            {
                return student?.Name ?? string.Empty;
            }
            set
            {
                if (student == null)
                {
                    student = new Student();
                }
                student.Name = value;
            }
        }

        public string Classification
        {
            get
            {
                return student?.Classification ?? string.Empty;
            }
            set
            {
                if (student == null)
                {
                    student = new Student();
                }
                student.Classification = value;
            }
        }

        public StudentDialogViewModel(int cId)
        {
            if (cId == 0)
            {
                student = new Student();
            }
            else
            {
                student = StudentService.Current.Get(cId) ?? new Student();
            }
        }

        public void AddStudent()
        {
            if (student != null)
            {
                StudentService.Current.AddOrUpdate(student);
            }
        }
    }
}
