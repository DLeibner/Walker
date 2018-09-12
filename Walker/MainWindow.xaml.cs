using System;
using System.Timers;

namespace Walker
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    private static TubesheetViewModel _tubesheetViewModel;

    public MainWindow(RobotWalkerViewModel robot)
    {
      InitializeComponent();
      _tubesheetViewModel = new TubesheetViewModel(robot);
      DataContext = _tubesheetViewModel;

      _tubesheetViewModel.IssueError += OnIssueError;

      _tubesheetViewModel.InitializeViewModel();

      robot.Timer = new Timer(100);
      robot.Timer.Elapsed += OnTimedEvent;
      robot.Timer.AutoReset = true;
      robot.Timer.Enabled = true;
    }

    private void OnIssueError(object sender, NotificationEventArgs e)
    {
      System.Windows.MessageBox.Show(
        e.Message, "Error", System.Windows.MessageBoxButton.OK,
        System.Windows.MessageBoxImage.Error);
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      var robotMovement = new RobotMovement(_tubesheetViewModel.Robot);
      robotMovement.Move();
    }
  }
}
