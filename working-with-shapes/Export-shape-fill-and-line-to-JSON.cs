// -----------------------------------------------------------------------------
// Example: Export shape fill and line to JSON using C#
//
// Description:
// Demonstrates how to export shape fill and line properties of each shape in a
// PowerPoint presentation to a JSON file using C# and Aspose.Slides for .NET.
// The example loads a PPTX, iterates through slides and shapes, captures fill
// type, line fill type, and line width, writes the data to JSON, and saves the
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Shape, Fill, Line,
// JSON, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of shape fill and line information to JSON.
// - Build .NET tools for analyzing or reporting on PPTX shape properties.
// - Integrate shape property data into downstream processing pipelines.
// - Validate presentation content before publishing or further manipulation.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportShapeProperties
{
    class ShapeInfo
    {
        public int SlideIndex { get; set; }
        public int ShapeIndex { get; set; }
        public string ShapeType { get; set; }
        public string FillType { get; set; }
        public string LineFillType { get; set; }
        public double? LineWidth { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputJsonPath = "shapes.json";
            string outputPptxPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    List<ShapeInfo> shapeInfos = new List<ShapeInfo>();

                    for (int slideIdx = 0; slideIdx < pres.Slides.Count; slideIdx++)
                    {
                        ISlide slide = pres.Slides[slideIdx];
                        for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                        {
                            IShape shape = slide.Shapes[shapeIdx];
                            ShapeInfo info = new ShapeInfo
                            {
                                SlideIndex = slideIdx,
                                ShapeIndex = shapeIdx,
                                ShapeType = shape.GetType().Name,
                                FillType = shape.FillFormat != null ? shape.FillFormat.FillType.ToString() : "None",
                                LineFillType = shape.LineFormat != null && shape.LineFormat.FillFormat != null
                                    ? shape.LineFormat.FillFormat.FillType.ToString()
                                    : "None",
                                // LineFormat.Width is a float; store as double to avoid double‑to‑float conversion issues
                                LineWidth = shape.LineFormat != null ? (double?)shape.LineFormat.Width : null
                            };
                            shapeInfos.Add(info);
                        }
                    }

                    string json = JsonSerializer.Serialize(shapeInfos, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputJsonPath, json);
                    Console.WriteLine("Shape properties exported to " + outputJsonPath);

                    // Save the presentation before exiting
                    pres.Save(outputPptxPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for loading or saving.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
