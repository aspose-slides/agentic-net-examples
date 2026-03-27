using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        var inputPath = args.Length > 0 ? args[0] : "input.pptx";
        var outputJsonPath = args.Length > 1 ? args[1] : "nodes.json";
        var outputPptxPath = args.Length > 2 ? args[2] : "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file not found: {inputPath}");
            return;
        }

        var presentation = new Aspose.Slides.Presentation(inputPath);
        var geometries = new List<object>();

        for (int slideIdx = 0; slideIdx < presentation.Slides.Count; slideIdx++)
        {
            var slide = presentation.Slides[slideIdx];
            var smartArtIdx = 0;
            foreach (var shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                {
                    var nodeIdx = 0;
                    foreach (var node in smartArt.AllNodes)
                    {
                        var shapeIdx = 0;
                        foreach (var smartShape in node.Shapes)
                        {
                            geometries.Add(new
                            {
                                SlideIndex = slideIdx,
                                SmartArtIndex = smartArtIdx,
                                NodeIndex = nodeIdx,
                                ShapeIndex = shapeIdx,
                                X = smartShape.X,
                                Y = smartShape.Y,
                                Width = smartShape.Width,
                                Height = smartShape.Height
                            });
                            shapeIdx++;
                        }
                        nodeIdx++;
                    }
                    smartArtIdx++;
                }
            }
        }

        var json = JsonSerializer.Serialize(geometries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(outputJsonPath, json);

        // Save the (unchanged) presentation
        presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}