namespace Walker
{
  public class RobotWalkerViewModel
  {
    public RobotWalkerViewModel()
    {
      Initialize();
    }

    public Point StartPoint { get; set; }

    public Point EndPoint { get; set; }

    public WalkerLine BrownLine { get; set; }

    public WalkerLine GreenLine { get; set; }

    public void Initialize()
    {
      StartPoint = new Point
      {
        X = (27.43 + 16.8) * 25,
        Y = (27.43 + 16.8) * 25
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
