﻿namespace Library.VSCANVAS.Models;

public class Student
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public string? Classification { get; set; }

    public string? Grade { get; set; }

    public Student()
    {
    }

    public override string ToString()
    {
        return $"{Name} - {Classification} - {Id}";
    }

    public void SearchStudentList(string searched)
    {
        if (Name.Equals(searched))
        {
            Console.WriteLine(this);
            Console.WriteLine("Year: " + Classification);
            Console.WriteLine("Grade: " + Grade);
            Console.WriteLine("");
        }
    }


}