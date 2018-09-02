using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Walker
{
  internal static class Parser
  {
    public static double Diameter { get; set; }

    public static double Pitch { get; set; }

    public static List<TubeModel> GetTubesFromFile(string fileName)
    {
      if (!File.Exists(fileName))
        throw new FileNotFoundException("File '{0}' not found!", fileName);

      XDocument file = XDocument.Load(fileName);

      List<TubeModel> listTubes;

      try
      {
        Diameter = Double.Parse(file.Descendants("TubesheetDiameter").First().Value);
        Pitch = Double.Parse(file.Descendants("TubesheetPitch").First().Value);

        var tubes = from item in file.Descendants("Tube")
          select new TubeModel
          {
            Row = Int32.Parse(item.Element("Row").Value),
            Column = Int32.Parse(item.Element("Column").Value),
            Status = item.Element("Status").Value
          };

        listTubes = tubes.ToList();
      }
      catch (Exception e)
      {
        throw new FileLoadException("Tube is missing data!");
      }

      return listTubes;
    }
  }
}
