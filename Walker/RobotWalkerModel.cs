namespace Walker
{
  public class RobotWalkerModel
  {
    public RobotWalkerModel()
    {
      BrownLine = new WalkerLine();
      GreenLine = new WalkerLine();
    }

    public WalkerLine BrownLine { get; set; }

    public WalkerLine GreenLine { get; set; }
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
