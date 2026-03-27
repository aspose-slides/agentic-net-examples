using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Expect three arguments: input PPTX, output PPTX, config file
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <input.pptx> <output.pptx> <config.txt>");
            return;
        }

        var inputPath = args[0];
        var outputPath = args[1];
        var configPath = args[2];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!File.Exists(configPath))
        {
            Console.WriteLine("Config file does not exist.");
            return;
        }

        // Config file should contain ARGB values separated by commas, e.g., "255,0,128,255"
        var colorLine = File.ReadAllText(configPath).Trim();
        var parts = colorLine.Split(',');
        if (parts.Length != 4)
        {
            Console.WriteLine("Config file must contain ARGB values separated by commas.");
            return;
        }

        var a = byte.Parse(parts[0]);
        var r = byte.Parse(parts[1]);
        var g = byte.Parse(parts[2]);
        var b = byte.Parse(parts[3]);
        var uniformColor = Color.FromArgb(a, r, g, b);

        var presentation = new Presentation(inputPath);

        foreach (var shape in presentation.Slides[0].Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                foreach (var node in smartArt.AllNodes)
                {
                    foreach (var nodeShape in node.Shapes)
                    {
                        nodeShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        nodeShape.FillFormat.SolidFillColor.Color = uniformColor;
                    }
                }
            }
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}