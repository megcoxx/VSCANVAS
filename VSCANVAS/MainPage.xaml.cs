﻿namespace VSCANVAS;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void InstructorViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void StudentViewClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//CoursesEnrolled");
    }
}


