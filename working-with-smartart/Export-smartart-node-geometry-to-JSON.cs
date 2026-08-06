// -----------------------------------------------------------------------------
// Example: Export smartart node geometry to JSON using C#
//
// Description:
// Demonstrates how to export the geometry information of SmartArt nodes to a
// JSON file using C# and Aspose.Slides for .NET. The example loads a PPTX,
// iterates through all SmartArt shapes, extracts geometry path data for each
// node shape, and writes a concise JSON representation. It also saves the
// presentation after processing.
//
// Keywords:
// C#, Aspose.Slides for .NET, SmartArt, Geometry, JSON, Export, PowerPoint,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of SmartArt geometry for analysis or conversion.
// - Build tools that need to inspect or validate SmartArt layouts.
// - Integrate SmartArt geometry data into downstream .NET applications.
// - Generate JSON reports of PPTX content for documentation or testing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtGeometryExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputJsonPath = "smartart_geometry.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    List<object> geometryData = new List<object>();

                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is ISmartArt smartArt)
                            {
                                foreach (ISmartArtNode node in smartArt.AllNodes)
                                {
                                    foreach (ISmartArtShape smartShape in node.Shapes)
                                    {
                                        IGeometryShape geometryShape = smartShape.AsIGeometryShape;
                                        IGeometryPath[] paths = geometryShape.GetGeometryPaths();

                                        var shapeInfo = new
                                        {
                                            ShapeName = smartShape.Name,
                                            NodeLevel = node.Level,
                                            PathCount = paths.Length
                                        };

                                        geometryData.Add(shapeInfo);
                                    }
                                }
                            }
                        }
                    }

                    string json = JsonSerializer.Serialize(geometryData, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputJsonPath, json);

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
