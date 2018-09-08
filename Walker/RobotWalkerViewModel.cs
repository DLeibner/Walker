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

    public RobotWalkerModel Walker { get; set; }

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
      get { return Walker.GreenPincer1.X; }
      set
      {
        Walker.GreenPincer1.X = value;
        RaisePropertyChanged("GreenPincer1X");
      }
    }

    public double GreenPincer1Y
    {
      get { return Walker.GreenPincer1.Y; }
      set
      {
        Walker.GreenPincer1.X = value;
        RaisePropertyChanged("GreenPincer1Y");
      }
    }

    public double GreenPincer2X
    {
      get { return Walker.GreenPincer2.X; }
      set
      {
        Walker.GreenPincer2.X = value;
        RaisePropertyChanged("GreenPincer2X");
      }
    }

    public double GreenPincer2Y
    {
      get { return Walker.GreenPincer2.Y; }
      set
      {
        Walker.GreenPincer2.X = value;
        RaisePropertyChanged("GreenPincer2Y");
      }
    }

    public double BrownPincer1X
    {
      get { return Walker.BrownPincer1.X; }
      set
      {
        Walker.BrownPincer1.X = value;
        RaisePropertyChanged("BrownPincer1X");
      }
    }

    public double BrownPincer1Y
    {
      get { return Walker.BrownPincer1.Y; }
      set
      {
        Walker.BrownPincer1.X = value;
        RaisePropertyChanged("BrownPincer1Y");
      }
    }

    public double BrownPincer2X
    {
      get { return Walker.BrownPincer2.X; }
      set
      {
        Walker.BrownPincer2.X = value;
        RaisePropertyChanged("BrownPincer2X");
      }
    }

    public double BrownPincer2Y
    {
      get { return Walker.BrownPincer2.Y; }
      set
      {
        Walker.BrownPincer2.X = value;
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
      Walker.GreenPincer1.X = _startPoint.X + 27.42160097 - _diameter / 2;
      Walker.GreenPincer1.Y = _startPoint.Y - 27.42160097 - _diameter / 2;
      Walker.GreenPincer2.X = Walker.GreenLine.Second.X - _diameter / 2;
      Walker.GreenPincer2.Y = Walker.GreenLine.Second.Y - _diameter / 2;
      Walker.BrownPincer1.X = Walker.BrownLine.First.X - _diameter / 2;
      Walker.BrownPincer1.Y = Walker.BrownLine.First.Y - _diameter / 2;
      Walker.BrownPincer2.X = Walker.BrownLine.Second.X - _diameter / 2;
      Walker.BrownPincer2.Y = Walker.BrownLine.Second.Y - _diameter / 2;
    }

    private Point _endRowColumn;

    public double Orientation
    {
      get { return Walker.Orientation; }
      set
      {
        Walker.Orientation = value;
        RaisePropertyChanged("Orientation");
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
    }

    public string this[string property]
    {
      get
      {
        string result = Validation.Validate(
          property, _startRowColumn, _endRowColumn, Orientation);
        return result;
      }
    }

    public string Error => string.Empty;
  }
}
