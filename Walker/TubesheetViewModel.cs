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

    public double MainWindowWidth => PanelWidth + 2 * RowColumnWidthHeight;

    public double MainWindowHeight => PanelHeight + 2 * RowColumnWidthHeight;

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
