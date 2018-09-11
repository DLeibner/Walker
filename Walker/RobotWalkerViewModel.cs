using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Walker
{
  public class RobotWalkerViewModel : PropertyChangedNotifier, IDataErrorInfo
  {
    public RobotWalkerViewModel()
    {
      Initialize();
    }

    private double _diameter = 16.8;

    private double _pitch = 27.43;

    public double Size => _diameter;

    private RobotWalkerModel Walker { get; set; }

    public double GreenX1
    {
      get { return Walker.GreenLine.First.X; }
      set
      {
        Walker.GreenLine.First.X = value;
        RaisePropertyChanged("GreenX1");
      }
    }

    public double GreenX2
    {
      get { return Walker.GreenLine.Second.X; }
      set
      {
        Walker.GreenLine.Second.X = value;
        RaisePropertyChanged("GreenX2");
      }
    }

    public double GreenY1
    {
      get { return Walker.GreenLine.First.Y; }
      set
      {
        Walker.GreenLine.First.Y = value;
        RaisePropertyChanged("GreenY1");
      }
    }

    public double GreenY2
    {
      get { return Walker.GreenLine.Second.Y; }
      set
      {
        Walker.GreenLine.Second.Y = value;
        RaisePropertyChanged("GreenY2");
      }
    }

    public double GreenRotationPointX
    {
      get { return Walker.GreenLine.RotationPoint.X; }
      set
      {
        Walker.GreenLine.RotationPoint.X = value;
        RaisePropertyChanged("GreenRotationPointX");
      }
    }

    public double GreenRotationPointY
    {
      get { return Walker.GreenLine.RotationPoint.Y; }
      set
      {
        Walker.GreenLine.RotationPoint.Y = value;
        RaisePropertyChanged("GreenRotationPointY");
      }
    }

    public double BrownX1
    {
      get { return Walker.BrownLine.First.X; }
      set
      {
        Walker.BrownLine.First.X = value;
        RaisePropertyChanged("BrownX1");
      }
    }

    public double BrownX2
    {
      get { return Walker.BrownLine.Second.X; }
      set
      {
        Walker.BrownLine.Second.X = value;
        RaisePropertyChanged("BrownX2");
      }
    }

    public double BrownY1
    {
      get { return Walker.BrownLine.First.Y; }
      set
      {
        Walker.BrownLine.First.Y = value;
        RaisePropertyChanged("BrownY1");
      }
    }

    public double BrownY2
    {
      get { return Walker.BrownLine.Second.Y; }
      set
      {
        Walker.BrownLine.Second.Y = value;
        RaisePropertyChanged("BrownY");
      }
    }

    public double BrownRotationPointX
    {
      get { return Walker.BrownLine.RotationPoint.X; }
      set
      {
        Walker.BrownLine.RotationPoint.X = value;
        RaisePropertyChanged("BrownRotationPointX");
      }
    }

    public double BrownRotationPointY
    {
      get { return Walker.BrownLine.RotationPoint.Y; }
      set
      {
        Walker.BrownLine.RotationPoint.Y = value;
        RaisePropertyChanged("BrownRotationPointY");
      }
    }

    public double ToolHeadX
    {
      get { return Walker.ToolHead.X; }
      set
      {
        Walker.ToolHead.X = value;
        RaisePropertyChanged("ToolHeadX");
      }
    }

    public double ToolHeadY
    {
      get { return Walker.ToolHead.Y; }
      set
      {
        Walker.ToolHead.Y = value;
        RaisePropertyChanged("ToolHeadY");
      }
    }

    public double GreenPincer1X
    {
      get { return Walker.GreenPincer.First.X; }
      set
      {
        Walker.GreenPincer.First.X = value;
        RaisePropertyChanged("GreenPincer1X");
      }
    }

    public double GreenPincer1Y
    {
      get { return Walker.GreenPincer.First.Y; }
      set
      {
        Walker.GreenPincer.First.Y = value;
        RaisePropertyChanged("GreenPincer1Y");
      }
    }

    public double GreenPincer2X
    {
      get { return Walker.GreenPincer.Second.X; }
      set
      {
        Walker.GreenPincer.Second.X = value;
        RaisePropertyChanged("GreenPincer2X");
      }
    }

    public double GreenPincer2Y
    {
      get { return Walker.GreenPincer.Second.Y; }
      set
      {
        Walker.GreenPincer.Second.Y = value;
        RaisePropertyChanged("GreenPincer2Y");
      }
    }

    public double BrownPincer1X
    {
      get { return Walker.BrownPincer.First.X; }
      set
      {
        Walker.BrownPincer.First.X = value;
        RaisePropertyChanged("BrownPincer1X");
      }
    }

    public double BrownPincer1Y
    {
      get { return Walker.BrownPincer.First.Y; }
      set
      {
        Walker.BrownPincer.First.Y = value;
        RaisePropertyChanged("BrownPincer1Y");
      }
    }

    public double BrownPincer2X
    {
      get { return Walker.BrownPincer.Second.X; }
      set
      {
        Walker.BrownPincer.Second.X = value;
        RaisePropertyChanged("BrownPincer2X");
      }
    }

    public double BrownPincer2Y
    {
      get { return Walker.BrownPincer.Second.Y; }
      set
      {
        Walker.BrownPincer.Second.Y = value;
        RaisePropertyChanged("BrownPincer2Y");
      }
    }

    public double StartRow
    {
      get
      {
        _startPoint.X = _startRowColumn.X * _pitch;
        UpdateWalkerStartPosition();
        return _startRowColumn.X;
      }
      set => _startRowColumn.X = value;
    }

    public double StartColumn
    {
      get
      {
        _startPoint.Y = _startRowColumn.Y * _pitch;
        UpdateWalkerStartPosition();
        return _startRowColumn.Y;
      }
      set => _startRowColumn.Y = value;
    }

    public double EndRow
    {
      get
      {
        _endPoint.X = _endRowColumn.X * _pitch;
        return _endRowColumn.X;
      }
      set => _endRowColumn.X = value;
    }

    public double EndColumn
    {
      get
      {
        _endPoint.Y = _endRowColumn.Y * _pitch;
        return _endRowColumn.Y;
      }
      set => _endRowColumn.Y = value;
    }

    private Point _startPoint;
    public Point StartPoint
    {
      get { return _startPoint; }
      //set { _startPoint = value; }
    }

    private Point _endPoint;
    public Point EndPoint
    {
      get { return _endPoint; }
      //set { _endPoint = value; }
    }

    private Point _startRowColumn;

    private void UpdateWalkerStartPosition()
    {
      Walker.GreenLine.First = _startPoint;
      Walker.GreenLine.Second.X = _startPoint.X + 411.472507;
      Walker.GreenLine.Second.Y = _startPoint.Y - 411.472507;
      Walker.BrownLine.First.X = _startPoint.X - 109.712946;
      Walker.BrownLine.First.Y = _startPoint.Y - 219.447054;
      Walker.BrownLine.Second.X = _startPoint.X + 548.607054;
      Walker.BrownLine.Second.Y = _startPoint.Y - 219.447054;
      Walker.ToolHead.X = _startPoint.X - _diameter / 2;
      Walker.ToolHead.Y = _startPoint.Y - _diameter / 2;
      Walker.GreenPincer.First.X = _startPoint.X + 27.42160097 - _diameter / 2;
      Walker.GreenPincer.First.Y = _startPoint.Y - 27.42160097 - _diameter / 2;
      Walker.GreenPincer.Second.X = Walker.GreenLine.Second.X - _diameter / 2;
      Walker.GreenPincer.Second.Y = Walker.GreenLine.Second.Y - _diameter / 2;
      Walker.BrownPincer.First.X = Walker.BrownLine.First.X - _diameter / 2;
      Walker.BrownPincer.First.Y = Walker.BrownLine.First.Y - _diameter / 2;
      Walker.BrownPincer.Second.X = Walker.BrownLine.Second.X - _diameter / 2;
      Walker.BrownPincer.Second.Y = Walker.BrownLine.Second.Y - _diameter / 2;
      GreenRotationPointX = Walker.GreenLine.First.X + (Walker.GreenLine.Second.X - Walker.GreenLine.First.X) / 2 + 27.42160097;
      GreenRotationPointY = Walker.GreenLine.First.Y + (Walker.GreenLine.Second.Y - Walker.GreenLine.First.Y) / 2 - 27.42160097;
      BrownRotationPointX = Walker.BrownLine.First.X + (Walker.BrownLine.Second.X - Walker.BrownLine.First.X) / 2;
      BrownRotationPointY = Walker.BrownLine.First.Y + (Walker.BrownLine.Second.Y - Walker.BrownLine.First.Y) / 2;
    }

    private Point _endRowColumn;

    private ObservableCollection<string> _orientation;
    public ObservableCollection<string> Orientation
    {
      get { return _orientation; }
      set
      {
        _orientation = value;
        RaisePropertyChanged("Orientation");
      }
    }

    public string SelectedOrientation { get; set; }

    private bool _rotationSet;
    public double RotationGreen
    {
      get
      {
        if (!_rotationSet)
        {
          TransformSelectedOrientationToRotation();
          _rotationSet = true;
        }
        return Walker.GreenLine.Rotation - 45;
      }
      set
      {
        Walker.GreenLine.Rotation = value;
        RaisePropertyChanged("RotationGreen");
      }
    }

    public double RotationBrown
    {
      get { return Walker.BrownLine.Rotation; }
      set
      {
        Walker.BrownLine.Rotation = value;
        RaisePropertyChanged("RotationBrown");
      }
    }

    public double TranslationGreenX
    {
      get { return Walker.GreenLine.Translation.X; }
      set
      {
        Walker.GreenLine.Translation.X = value;
        RaisePropertyChanged("TranslationGreenX");
      }
    }

    public double TranslationGreenY
    {
      get { return Walker.GreenLine.Translation.Y; }
      set
      {
        Walker.GreenLine.Translation.Y = value;
        RaisePropertyChanged("TranslationGreenY");
      }
    }

    public double TranslationBrownX
    {
      get { return Walker.BrownLine.Translation.X; }
      set
      {
        Walker.BrownLine.Translation.X = value;
        RaisePropertyChanged("TranslationBrownX");
      }
    }

    public double TranslationBrownY
    {
      get { return Walker.BrownLine.Translation.Y; }
      set
      {
        Walker.BrownLine.Translation.Y = value;
        RaisePropertyChanged("TranslationBrownY");
      }
    }

    private void TransformSelectedOrientationToRotation()
    {
      if (SelectedOrientation == _orientation[0])
      {
        Walker.GreenLine.Rotation = 45;
      }
      else if (SelectedOrientation == _orientation[1])
      {
        Walker.GreenLine.Rotation = -45;
      }
      else if (SelectedOrientation == _orientation[2])
      {
        Walker.GreenLine.Rotation = 135;
        RotationBrown = 90;
      }
      else if (SelectedOrientation == _orientation[3])
      {
        Walker.GreenLine.Rotation = -135;
        RotationBrown = -90;
      }
    }

    public void Initialize()
    {
      _startPoint = new Point
      {
        X = _pitch * 5,
        Y = _pitch * 40
      };
      _endPoint = new Point
      {
        X = _pitch * 40,
        Y = _pitch * 10
      };

      _startRowColumn = new Point
      {
        X = 5,
        Y = 40
      };
      _endRowColumn = new Point
      {
        X = 40,
        Y = 10
      };

      Walker = new RobotWalkerModel();

      _orientation = new ObservableCollection<string>
      { "Top left", "Top right", "Bottom left", "Bottom right" };
      SelectedOrientation = _orientation[0];
      _rotationSet = false;
    }

    public string this[string property]
    {
      get
      {
        string result = Validation.Validate(
          property, _startRowColumn, _endRowColumn);
        return result;
      }
    }

    public string Error => string.Empty;
  }
}
