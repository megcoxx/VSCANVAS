using VSCANVAS.ViewModels;

namespace VSCANVAS.Views;

public partial class CoursesEnrolled : ContentPage
{
	public CoursesEnrolled()
	{
		InitializeComponent();
		BindingContext = new CourseViewModel();
	}

	private void BackToHomeClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void AddClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//CourseDetail");
	}

	private void PreviousPageClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//CoursesEnrolled");
	}

	private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as CourseViewModel)?.Refresh();

	}

	private void RemoveClicked(object sender, EventArgs e){
		(BindingContext as CourseViewModel)?.Remove();
	}

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseViewModel)?.Refresh();
    }
}