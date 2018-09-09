namespace Walker
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow(RobotWalkerViewModel robot)
    {
      InitializeComponent();
      var tubesheetViewModel = new TubesheetViewModel(robot);
      DataContext = tubesheetViewModel;

      tubesheetViewModel.IssueError += OnIssueError;

      tubesheetViewModel.InitializeViewModel();
    }

    private void OnIssueError(object sender, NotificationEventArgs e)
    {
      System.Windows.MessageBox.Show(
        e.Message, "Error", System.Windows.MessageBoxButton.OK,
        System.Windows.MessageBoxImage.Error);
    }
  }
}
