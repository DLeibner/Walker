using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Walker
{
  public class TubesheetViewModel : PropertyChangedNotifier
  {
    public TubesheetViewModel(RobotWalkerViewModel robot)
    {
      Tubes = new List<TubeModel>();
      CanvasTubes = new ObservableCollection<CanvasTubeModel>();
      Robot = robot;
    }

    public RobotWalkerViewModel Robot { get; set; }

    public double TubesheetDiameter { get; set; }

    public double TubesheetPitch { get; set; }

    public double PanelWidth { get; set; }

    public double PanelHeight { get; set; }

    public double MainWindowWidth
    {
      get
      {
        var screenWidth = System.Windows.SystemParameters.WorkArea.Width;
        var desiredWindowWidth = PanelWidth + 2 * TubesheetPitch;

        return desiredWindowWidth < screenWidth ? desiredWindowWidth : screenWidth;
      }
    }

    public double MainWindowHeight
    {
      get
      {
        var screenHeight = System.Windows.SystemParameters.WorkArea.Height - 30;
        var desiredWindowHeight = PanelHeight + 2 * TubesheetPitch;

        return desiredWindowHeight < screenHeight ? desiredWindowHeight : screenHeight;
      }
    }

    private List<TubeModel> Tubes { get; set; }

    public ObservableCollection<CanvasTubeModel> CanvasTubes { get; set; }

    private void ParseXmlFile()
    {
      var file = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()) + @"\Files\Tubesheet.xml";

      try
      {
        Tubes = Parser.GetTubesFromFile(file);
        TubesheetDiameter = Parser.Diameter;
        TubesheetPitch = Parser.Pitch;
      }
      catch(Exception e)
      {
        string message = e.Message;
        if (e is FileNotFoundException)
        {
          var fileName = (e as FileNotFoundException).FileName;
          message = String.Format(message, fileName);
        }

        IssueError?.Invoke(this, new NotificationEventArgs(message));
      }
    }

    public event EventHandler<NotificationEventArgs> IssueError;

    public void InitializeViewModel()
    {
      ParseXmlFile();

      var maxRow = Tubes.DefaultIfEmpty().Max(x => x?.Row ?? 0);
      var maxColumn = Tubes.DefaultIfEmpty().Max(x => x?.Column ?? 0);

      PanelWidth = maxRow * TubesheetPitch + TubesheetDiameter;
      PanelHeight = maxColumn * TubesheetPitch + TubesheetDiameter;

      foreach (var tube in Tubes)
      {
        CanvasTubes.Add(new CanvasTubeModel
        {
          Tube = tube,
          Left = tube.Row * TubesheetPitch - TubesheetDiameter/2,
          Top = tube.Column * TubesheetPitch - TubesheetDiameter/2,
          Size = TubesheetDiameter
        });
      }
    }
  }
}
