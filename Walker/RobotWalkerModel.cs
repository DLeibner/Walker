namespace Walker
{
  public class RobotWalkerModel
  {
    public RobotWalkerModel()
    {
      BrownLine = new WalkerPart();
      GreenLine = new WalkerPart();
      ToolHead = new Point();
      GreenPincer = new WalkerPart();
      BrownPincer = new WalkerPart();
    }

    public WalkerPart BrownLine { get; set; }

    public WalkerPart GreenLine { get; set; }

    public Point ToolHead { get; set; }

    public WalkerPart GreenPincer { get; set; }

    public WalkerPart BrownPincer { get; set; }
  }

  public class WalkerPart
  {
    public WalkerPart()
    {
      First = new Point();
      Second = new Point();
      RotationPoint = new Point();
      Translation = new Point();
    }

    public Point First { get; set; }

    public Point Second { get; set; }

    public Point RotationPoint { get; set; }

    public double Rotation { get; set; }

    public Point Translation { get; set; }
  }

  public class Point
  {
    public double X { get; set; }
    public double Y { get; set; }
  }
}
