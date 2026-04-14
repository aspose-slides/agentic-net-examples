using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportShapeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output JSON file path
            string outputJson = "shapes.json";
            // Output presentation path (saved before exit)
            string outputPptx = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // List to hold shape information
                    List<object> shapeInfos = new List<object>();

                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Fill properties
                            string fillType = "None";
                            if (shape.FillFormat != null)
                            {
                                fillType = shape.FillFormat.FillType.ToString();
                            }

                            // Line properties
                            string lineStyle = "None";
                            double lineWidth = 0;
                            string lineFillType = "None";
                            if (shape.LineFormat != null)
                            {
                                lineStyle = shape.LineFormat.Style.ToString();
                                lineWidth = shape.LineFormat.Width;
                                if (shape.LineFormat.FillFormat != null)
                                {
                                    lineFillType = shape.LineFormat.FillFormat.FillType.ToString();
                                }
                            }

                            // Add shape info to the list
                            shapeInfos.Add(new
                            {
                                SlideIndex = slideIndex,
                                ShapeIndex = shapeIndex,
                                ShapeName = shape.Name,
                                ShapeType = shape.GetType().FullName,
                                FillType = fillType,
                                LineStyle = lineStyle,
                                LineWidth = lineWidth,
                                LineFillType = lineFillType
                            });
                        }
                    }

                    // Serialize shape information to JSON
                    string json = JsonSerializer.Serialize(shapeInfos, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(outputJson, json);

                    // Save the presentation before exiting
                    pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}