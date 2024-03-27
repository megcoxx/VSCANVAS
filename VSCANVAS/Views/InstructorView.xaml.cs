namespace VSCANVAS.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
	}

	private void ViewAllCoursesClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//Course");
	}

	private void ViewAllStudentsClicked(object sender, EventArgs e){
		Shell.Current.GoToAsync("//StudentInstructor");
	}

	private void BackToHomeClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}