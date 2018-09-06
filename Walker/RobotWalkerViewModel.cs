namespace Walker
{
  public class RobotWalkerViewModel : PropertyChangedNotifier
  {
    public RobotWalkerViewModel()
    {
      Initialize();
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
        return _startRowColumn;
      }
      set
      {
        _startRowColumn = value;
        //_startPoint.X = value.X * (27.43 + 16.8);
        //_startPoint.Y = value.Y * (27.43 + 16.8);
      }
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

    public WalkerLine BrownLine { get; set; }

    public WalkerLine GreenLine { get; set; }

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

      GreenLine = new WalkerLine
      {
        First = new Point
        {
          X = StartPoint.X,
          Y = StartPoint.Y
        },
        Second = new Point
        {
          X = StartPoint.X + 384.050906,
          Y = StartPoint.Y - 384.050906
        }
      };

      BrownLine = new WalkerLine
      {
        First = new Point
        {
          X = StartPoint.X - 79.5395,
          Y = StartPoint.Y - 192.025453
        },
        Second = new Point
        {
          X = StartPoint.X + 543.13 - 79.5395,
          Y = StartPoint.Y - 192.025453
        }
      };
    }
  }





  // model in a separate file
  public class WalkerLine
  {
    public Point First { get; set; }

    public Point Second { get; set; }
  }

  public class Point
  {
    public double X { get; set; }
    public double Y { get; set; }
  }
}
