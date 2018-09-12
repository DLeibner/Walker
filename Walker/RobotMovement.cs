using System;

namespace Walker
{
  public class RobotMovement
  {
    public RobotMovement(RobotWalkerViewModel robotWalkerViewModel)
    {
      _robot = robotWalkerViewModel;
      _step = _robot.Pitch / 20;

      Move();
    }

    private RobotWalkerViewModel _robot;

    private double _step;

    private Point _green1;
    private Point _green2;
    private Point _brown1;
    private Point _brown2;

    // Cyclically called function with timer
    public void Move()
    {
      // translation and rotation change only view so we need to calculate current position
      _green1 = new Point
      {
        X = _robot.GreenX1 + _robot.TranslationGreenX,
        Y = _robot.GreenY1 + _robot.TranslationGreenY
      };
      _green2 = new Point
      {
        X = _robot.GreenX2 + _robot.TranslationGreenX,
        Y = _robot.GreenY2 + _robot.TranslationGreenY
      };
      _brown1 = new Point
      {
        X = _robot.BrownX1 + _robot.TranslationBrownX,
        Y = _robot.BrownY1 + _robot.TranslationBrownY
      };
      _brown2 = new Point
      {
        X = _robot.BrownX2 + _robot.TranslationBrownX,
        Y = _robot.BrownY2 + _robot.TranslationBrownY
      };

      var previousOrientation = _robot.SelectedOrientation;

      AddDistanceFromOrientation(previousOrientation);

      bool endTopLeft = _robot.EndPoint.X < _green1.X && _robot.EndPoint.Y > _green1.Y;
      bool endTopRight = _robot.EndPoint.X > _green1.X && _robot.EndPoint.Y > _green1.Y;
      bool endBottomLeft = _robot.EndPoint.X < _green1.X && _robot.EndPoint.Y < _green1.Y;
      bool endBottomRight = _robot.EndPoint.X > _green1.X && _robot.EndPoint.Y < _green1.Y;
      bool endUp = Math.Abs(_robot.EndPoint.X - _green1.X) < 0.5 && _robot.EndPoint.Y > _green1.Y;
      bool endDown = Math.Abs(_robot.EndPoint.X - _green1.X) < 0.5 && _robot.EndPoint.Y < _green1.Y;
      bool endLeft = _robot.EndPoint.X < _green1.X && Math.Abs(_robot.EndPoint.Y - _green1.Y) < 0.5;
      bool endRight = _robot.EndPoint.X > _green1.X && Math.Abs(_robot.EndPoint.Y - _green1.Y) < 0.5;

      // rotate head in direction of end point
      if (endTopLeft || endLeft)
      {
        _robot.SelectedOrientation = _robot.Orientation[0]; // top left
      }
      else if (endTopRight || endRight)
      {
        _robot.SelectedOrientation = _robot.Orientation[1]; // top right
      }
      else if (endBottomLeft || endUp || endDown) // TODO for endUp and endDown keep head at current row
      {
        _robot.SelectedOrientation = _robot.Orientation[2]; // bottom left
      }
      else if (endBottomRight)
      {
        _robot.SelectedOrientation = _robot.Orientation[3]; // bottom right
      }

      _robot.TransformSelectedOrientationToRotation();

      if (previousOrientation != _robot.SelectedOrientation)
      {
        AddDistanceFromOrientation(_robot.SelectedOrientation);
      }

      if (Math.Abs(_green1.X - _robot.EndPoint.X) > 0.5
        || Math.Abs(_green1.Y - _robot.EndPoint.Y) > 0.5)
      {
        if (endLeft)
        {
          if (_robot.IntersectionPoint.X - _brown1.X > _robot.Pitch)
          {
            TranslateGreenLeft();
          }
          else
          {
            TranslateBrownLeft();
          }
        }
        else if (endRight)
        {
          if (_brown2.X - _robot.IntersectionPoint.X > _robot.Pitch)
          {
            TranslateGreenRight();
          }
          else
          {
            TranslateBrownRight();
          }
        }
        else if (endUp)
        {
          if (_brown2.Y - _robot.IntersectionPoint.Y > _robot.Pitch)
          {
            TranslateGreenUp();
          }
          else
          {
            TranslateBrownUp();
          }
        }
        else if (endDown)
        {
          if (_robot.IntersectionPoint.Y - _brown1.Y > _robot.Pitch)
          {
            TranslateGreenDown();
          }
          else
          {
            TranslateBrownDown();
          }
        }
        else if (endTopLeft)
        {
          if (_robot.IntersectionPoint.Y - _green2.Y > _robot.Pitch)
          {
            TranslateGreenTopLeft();
          }
          else
          {
            TranslateBrownTopLeft();
          }
        }
        else if (endTopRight)
        {
          if (_robot.IntersectionPoint.Y - _green2.Y > _robot.Pitch)
          {
            TranslateGreenTopRight();
          }
          else
          {
            TranslateBrownTopRight();
          }
        }
        else if (endBottomLeft)
        {
          if (_green2.X - _robot.IntersectionPoint.X > _robot.Pitch)
          {
            TranslateGreenBottomLeft();
          }
          else
          {
            TranslateBrownBottomLeft();
          }
        }
        else if (endBottomRight)
        {
          if (_robot.IntersectionPoint.X - _green2.X > _robot.Pitch)
          {
            TranslateGreenBottomRight();
          }
          else
          {
            TranslateBrownBottomRight();
          }
        }
      }
      else
      {
        _robot.Timer.Enabled = false;
      }
    }

    private void AddDistanceFromOrientation(string currentOrientation)
    {
      // add distance based on current rotation
      if (currentOrientation == _robot.Orientation[1]) // top right
      {
        _green1.X += 16 * _robot.Pitch;
        _green2.X -= 16 * _robot.Pitch;
      }
      else if (currentOrientation == _robot.Orientation[2]) // bottom Left
      {
        _green1.Y -= 16 * _robot.Pitch;
        _green2.Y += 16 * _robot.Pitch;
        _brown1.X += 12 * _robot.Pitch;
        _brown1.Y -= 12 * _robot.Pitch;
        _brown2.X += 12 * _robot.Pitch;
        _brown2.Y += 12 * _robot.Pitch;
      }
      else if (currentOrientation == _robot.Orientation[3]) // bottom right
      {
        _green1.X += 16 * _robot.Pitch;
        _green1.Y -= 16 * _robot.Pitch;
        _green2.X -= 16 * _robot.Pitch;
        _green2.Y += 16 * _robot.Pitch;
        _brown1.X += 12 * _robot.Pitch;
        _brown1.Y += 12 * _robot.Pitch;
        _brown2.X += 12 * _robot.Pitch;
        _brown2.Y -= 12 * _robot.Pitch;
      }
    }

    private void TranslateGreenLeft()
    {
      _robot.TranslationGreenX -= _step;
      _robot.IntersectionPoint.X -= _step;
    }

    private void TranslateGreenRight()
    {
      _robot.TranslationGreenX += _step;
      _robot.IntersectionPoint.X += _step;
    }

    private void TranslateGreenUp()
    {
      _robot.TranslationGreenY += _step;
      _robot.IntersectionPoint.Y += _step;
    }

    private void TranslateGreenDown()
    {
      _robot.TranslationGreenY -= _step;
      _robot.IntersectionPoint.Y -= _step;
    }

    private void TranslateGreenTopLeft()
    {
      _robot.TranslationGreenX -= _step;
      _robot.TranslationGreenY += _step;
    }

    private void TranslateGreenTopRight()
    {
      _robot.TranslationGreenX += _step;
      _robot.TranslationGreenY += _step;
    }

    private void TranslateGreenBottomLeft()
    {
      _robot.TranslationGreenX -= _step;
      _robot.TranslationGreenY -= _step;
    }

    private void TranslateGreenBottomRight()
    {
      _robot.TranslationGreenX += _step;
      _robot.TranslationGreenY -= _step;
    }

    private void TranslateBrownLeft()
    {
      _robot.TranslationBrownX -= _robot.Pitch; // Todo implement hysteresis for brown move
    }

    private void TranslateBrownRight()
    {
      _robot.TranslationBrownX += _robot.Pitch;
    }

    private void TranslateBrownUp()
    {
      _robot.TranslationBrownY += _robot.Pitch;
    }

    private void TranslateBrownDown()
    {
      _robot.TranslationBrownY -= _robot.Pitch;
    }

    private void TranslateBrownTopLeft()
    {
      _robot.TranslationBrownX -= _robot.Pitch;
      _robot.TranslationBrownY += _robot.Pitch;
      _robot.IntersectionPoint.X -= _robot.Pitch;
      _robot.IntersectionPoint.Y += _robot.Pitch;
    }

    private void TranslateBrownTopRight()
    {
      _robot.TranslationBrownX += _robot.Pitch;
      _robot.TranslationBrownY += _robot.Pitch;
      _robot.IntersectionPoint.X += _robot.Pitch;
      _robot.IntersectionPoint.Y += _robot.Pitch;
    }

    private void TranslateBrownBottomLeft()
    {
      _robot.TranslationBrownX -= _robot.Pitch;
      _robot.TranslationBrownY -= _robot.Pitch;
      _robot.IntersectionPoint.X -= _robot.Pitch;
      _robot.IntersectionPoint.Y -= _robot.Pitch;
    }

    private void TranslateBrownBottomRight()
    {
      _robot.TranslationBrownX += _robot.Pitch;
      _robot.TranslationBrownY -= _robot.Pitch;
      _robot.IntersectionPoint.X += _robot.Pitch;
      _robot.IntersectionPoint.Y -= _robot.Pitch;
    }
  }
}
