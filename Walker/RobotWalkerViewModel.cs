namespace Walker
{
  public class RobotWalkerViewModel : PropertyChangedNotifier
  {
    public RobotWalkerViewModel()
    {
      Initialize();
    }

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
    public Point StartRowColumn
    {
      get
      {
        _startPoint.X = _startRowColumn.X * (27.43 + 16.8);
        _startPoint.Y = _startRowColumn.Y * (27.43 + 16.8);
        UpdateWalkerStartPosition();

        return _startRowColumn;
      }
      set
      {
        _startRowColumn = value;
        //_startPoint.X = value.X * (27.43 + 16.8);
        //_startPoint.Y = value.Y * (27.43 + 16.8);
      }
    }

    private void UpdateWalkerStartPosition()
    {
      Walker.GreenLine.First = _startPoint;
      Walker.GreenLine.Second.X = _startPoint.X + 384.050906;
      Walker.GreenLine.Second.Y = _startPoint.Y - 384.050906;
      Walker.BrownLine.First.X = _startPoint.X - 79.5395;
      Walker.BrownLine.First.Y = _startPoint.Y - 192.025453;
      Walker.BrownLine.Second.X = _startPoint.X + 543.13 - 79.5395;
      Walker.BrownLine.Second.Y = _startPoint.Y - 192.025453;
    }

    private Point _endRowColumn;
    public Point EndRowColumn
    {
      get
      {
        _endPoint.X = _endRowColumn.X * (27.43 + 16.8);
        _endPoint.Y = _endRowColumn.Y * (27.43 + 16.8);
        return _endRowColumn;
      }
      set
      {
        _endRowColumn = value;
        _endPoint.X = value.X * (27.43 + 16.8);
        _endPoint.Y = value.Y * (27.43 + 16.8);
      }
    }

    public double Orientation { get; set; }

    public void Initialize()
    {
      _startPoint = new Point
      {
        X = (27.43 + 16.8) * 5,
        Y = (27.43 + 16.8) * 40
      };
      _endPoint = new Point
      {
        X = (27.43 + 16.8) * 40,
        Y = (27.43 + 16.8) * 10
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
  }
}
