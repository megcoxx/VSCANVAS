﻿using Library.VSCANVAS.Models;

namespace Library.VSCANVAS.Services;
public class StudentService
{
    private IList<Student> students;
    private string? query;
    private static object _lock = new();
    private static StudentService? instance;
    public static StudentService Current
    {
        get
        {
            lock (_lock)
            {
                instance ??= new StudentService();
            }
            return instance;
        }
    }

    public IEnumerable<Student> Students
    {
        get
        {
            return students.Where(
                c =>
                    c.Name.ToUpper().Contains(query ?? string.Empty));
        }
    }

    private StudentService()
    {
        students = new List<Student>{
            new Student{Name = "TestStudent1", Id =1},
            new Student{Name = "TestStudent2", Id =2}
        };
    }

    public IEnumerable<Student> Search(string query)
    {
        this.query = query;
        return Students;
    }

    public void AddOrUpdate(Student student)
    {
        if(student.Id <= 0)
        {
            student.Id = (this.Count()) + 1;
        }
        students.Add(student);
    }

    public int Count()
    {
        return students.Count;
    }

    public void Remove(Student student)
    {
        students.Remove(student);
    }

    public void Delete(Student studentToDelete)
    {
        students.Remove(studentToDelete);
    }
}