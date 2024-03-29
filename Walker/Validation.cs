﻿namespace Walker
{
  public static class Validation
  {
    public static string Validate(string property, Point start, Point end)
    {
      string result = string.Empty;

      if (property == "StartRow")
      {
        result = ValidateRow(start.X);
      }
      else if (property == "StartColumn")
      {
        result = ValidateColumn(start.Y);
      }
      if (property == "EndRow")
      {
        result = ValidateRow(end.X);
      }
      else if (property == "EndColumn")
      {
        result = ValidateColumn(end.Y);
      }

      return result;
    }

    private static string ValidateColumn(double column)
    {
      string result = string.Empty;

      if (column > 56 || column < 1)
      {
        result = "Selected Column is outside of working area which is from 1 to 56";
      }

      return result;
    }

    private static string ValidateRow(double row)
    {
      string result = string.Empty;

      if (row > 56 || row < 1)
      {
        result = "Selected Row is outside of working area which is from 1 to 56";
      }

      return result;
    }
  }
}
