using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Walker
{
  public class TubesheetViewModel : PropertyChangedNotifier
  {
    public TubesheetViewModel()
    {
      Tubes = new List<TubeModel>();
      CanvasTubes = new ObservableCollection<CanvasTubeModel>();
      InitializeViewModel();
    }

    public double TubesheetDiameter { get; set; }

    public double TubesheetPitch { get; set; }

    public double RowColumnWidthHeight => TubesheetDiameter + TubesheetPitch;

    public double PanelWidth { get; set; }

    public double PanelHeight { get; set; }

    public double MainWindowWidth
    {
      get
      {
        var screenWidth = System.Windows.SystemParameters.WorkArea.Width;
        var desiredWindowWidth = PanelWidth + 2 * RowColumnWidthHeight;

        return desiredWindowWidth < screenWidth ? desiredWindowWidth : screenWidth;
      }
    }

    public double MainWindowHeight
    {
      get
      {
        var screenHeight = System.Windows.SystemParameters.WorkArea.Height - 30;
        var desiredWindowHeight = PanelHeight + 2 * RowColumnWidthHeight;

        return desiredWindowHeight < screenHeight ? desiredWindowHeight : screenHeight;
      }
    }

    public List<TubeModel> Tubes { get; set; }

    public ObservableCollection<CanvasTubeModel> CanvasTubes { get; set; }

    // Parse file
    void ParseXmlFile()
    {
      Tubes = Parser.GetTubesFromFile(@"D:\other\simple\Walker\Tubesheet.xml"); // TODO path
      TubesheetDiameter = Parser.Diameter;
      TubesheetPitch = Parser.Pitch;
    }

    void InitializeViewModel()
    {
      ParseXmlFile();

      var maxRow = Tubes.Max(x => x.Row);
      var maxColumn = Tubes.Max(x => x.Column);

      PanelWidth = maxRow * RowColumnWidthHeight;
      PanelHeight = maxColumn * RowColumnWidthHeight;

      foreach (var tube in Tubes)
      {
        CanvasTubes.Add(new CanvasTubeModel
        {
          Tube = tube,
          Left = tube.Row * RowColumnWidthHeight,
          Top = tube.Column * RowColumnWidthHeight,
          Size = TubesheetDiameter  // TODO bind to property here
        });
      }
    }
  }
}
