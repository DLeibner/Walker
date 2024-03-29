﻿using System;
using System.Windows.Media;

namespace Walker
{
    public class CanvasTubeModel
    {
      public TubeModel Tube { get; set; }

      public double Left { get; set; }

      public double Top { get; set; }

      public string Message
      {
        get
        {
          var s = String.Format("Row = {0}, Column = {1}, Status = {2}",
            Tube.Row, Tube.Column, Tube.Status);
          return s;
        }
      }

      public double Size { get; set; }

      public Brush Color
      {
        get
        {
          Brush color;

          switch (Tube.Status)
          {
            case "Unknown":
              color = Brushes.Gray;
              break;
            case "Plugged":
              color = Brushes.Black;
              break;
            case "Critical":
              color = Brushes.Red;
              break;
            default:
              color = Brushes.White;
              break;
          }

          return color;
        }
      }
    }
}
