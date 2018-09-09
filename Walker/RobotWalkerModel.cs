namespace Walker
{
  public class RobotWalkerModel
  {
    public RobotWalkerModel()
    {
      BrownLine = new WalkerLine();
      GreenLine = new WalkerLine();
      ToolHead = new Point();
      GreenPincer1 = new Point();
      GreenPincer2 = new Point();
      BrownPincer1 = new Point();
      BrownPincer2 = new Point();
      BrownCenter = new Point();
      GreenCenter = new Point();
    }

    public WalkerLine BrownLine { get; set; }

    public WalkerLine GreenLine { get; set; }

    public Point ToolHead { get; set; }

    public Point GreenPincer1 { get; set; }

    public Point GreenPincer2 { get; set; }

    public Point BrownPincer1 { get; set; }

    public Point BrownPincer2 { get; set; }

    public double RotationGreen { get; set; }

    public double RotationBrown { get; set; }

    public Point BrownCenter { get; set; }

    public Point GreenCenter { get; set; }
  }

  public class WalkerLine
  {
    public WalkerLine()
    {
      First = new Point();
      Second = new Point();
    }

    public Point First { get; set; }

    public Point Second { get; set; }
  }

  public class Point
  {
    public double X { get; set; }
    public double Y { get; set; }
  }
}
