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
      DataContext = new TubesheetViewModel(robot);
    }
  }
}
