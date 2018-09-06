namespace Walker
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class Window1
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      MainWindow mainWindow = new MainWindow(DataContext as RobotWalkerViewModel);
      mainWindow.Show();
      Close();
    }
  }
}
