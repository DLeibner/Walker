using System;

namespace Walker
{
  public class RobotMovement
  {
    public RobotMovement(TubesheetViewModel tubesheetViewModel)
    {
      _robot = tubesheetViewModel.Robot;

      CalculatePath();
    }

    private RobotWalkerViewModel _robot;

    private void CalculatePath()
    {
      bool endTopLeft = _robot.EndPoint.X < _robot.ToolHeadX && _robot.EndPoint.Y > _robot.ToolHeadY;
      bool endTopRight = _robot.EndPoint.X > _robot.ToolHeadX && _robot.EndPoint.Y > _robot.ToolHeadY;
      bool endBottomLeft = _robot.EndPoint.X < _robot.ToolHeadX && _robot.EndPoint.Y < _robot.ToolHeadY;
      bool endBottomRight = _robot.EndPoint.X > _robot.ToolHeadX && _robot.EndPoint.Y < _robot.ToolHeadY;
      bool endUp = _robot.EndPoint.X == _robot.ToolHeadX && _robot.EndPoint.Y > _robot.ToolHeadY;
      bool endDown = _robot.EndPoint.X == _robot.ToolHeadX && _robot.EndPoint.Y < _robot.ToolHeadY;
      bool endLeft = _robot.EndPoint.X < _robot.ToolHeadX && _robot.EndPoint.Y == _robot.ToolHeadY;
      bool endRight = _robot.EndPoint.X > _robot.ToolHeadX && _robot.EndPoint.Y == _robot.ToolHeadY;

      // rotate head in direction of end point
      if (endTopLeft || endLeft)
      {
        _robot.SelectedOrientation = _robot.Orientation[0]; // top left
      }
      else if (endTopRight || endRight)
      {
        _robot.SelectedOrientation = _robot.Orientation[1]; // top right
      }
      else if (endBottomLeft || endUp || endDown)
      {
        _robot.SelectedOrientation = _robot.Orientation[2]; // bottom left
      }
      else if (endBottomRight)
      {
        _robot.SelectedOrientation = _robot.Orientation[3]; // bottom right
      }

      while (Math.Abs(_robot.ToolHeadX - _robot.EndPoint.X) > 0 || Math.Abs(_robot.ToolHeadY - _robot.EndPoint.Y) > 0)
      {
        if (endLeft)
        {
          if (true) // TODO IF green didn't reach end point of brown
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
          if (true) // TODO IF greend didn't reach end point of brown
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
          if (true) // TODO green didn't reach end of brown
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
          if (true) // If green didn't reached end brown
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
          if (true) // green didn't reach end brown
          {
            TranslateGreenTopLeft();
          }
          else
          {
            TranslateBrownUp();
          }
        }
        else if (endTopRight)
        {
          if (true) // todo if green didn't reach end brown
          {
            TranslateGreenTopRight();
          }
          else
          {
            TranslateBrownUp();
          }
        }
        else if (endBottomLeft)
        {
          if (true) // todo if green didn't reach end brown
          {
            TranslateGreenBottomLeft();
          }
          else
          {
            TranslateBrownLeft();
          }
        }
        else if (endBottomRight)
        {
          if (true) // todo green didn't reach end brown
          {
            TranslateGreenBottomRight();
          }
          else
          {
            TranslateBrownRight();
          }
        }
      }
    }

    private void TranslateGreenLeft()
    {
      
    }

    private void TranslateGreenRight()
    {
    }

    private void TranslateGreenUp()
    {
      
    }

    private void TranslateGreenDown()
    {
      
    }

    private void TranslateGreenTopLeft()
    {
      
    }

    private void TranslateGreenTopRight()
    {
      
    }

    private void TranslateGreenBottomLeft()
    {
      
    }

    private void TranslateGreenBottomRight()
    {
      
    }

    private void TranslateBrownLeft()
    {
      
    }

    private void TranslateBrownRight()
    {
      
    }

    private void TranslateBrownUp()
    {
      
    }

    private void TranslateBrownDown()
    {
      
    }
  }
}
