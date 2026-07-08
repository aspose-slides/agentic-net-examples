using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapePropertiesExport
{
    public class ShapeInfo
    {
        public int SlideIndex { get; set; }
        public int ShapeIndex { get; set; }
        public string FillType { get; set; }
        public string LineFillType { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputJsonPath = "shapes.json";
            string outputPptxPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation (creation rule)
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // List to hold shape information
                List<ShapeInfo> shapeInfos = new List<ShapeInfo>();

                // Iterate through slides
                int slideIdx = 0;
                foreach (Aspose.Slides.ISlide slide in pres.Slides)
                {
                    int shapeIdx = 0;
                    // Iterate through shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Get fill type (if available)
                        string fillType = "None";
                        if (shape.FillFormat != null)
                        {
                            fillType = shape.FillFormat.FillType.ToString();
                        }

                        // Get line fill type (if available)
                        string lineFillType = "None";
                        if (shape.LineFormat != null && shape.LineFormat.FillFormat != null)
                        {
                            lineFillType = shape.LineFormat.FillFormat.FillType.ToString();
                        }

                        // Create shape info object
                        ShapeInfo info = new ShapeInfo();
                        info.SlideIndex = slideIdx;
                        info.ShapeIndex = shapeIdx;
                        info.FillType = fillType;
                        info.LineFillType = lineFillType;

                        shapeInfos.Add(info);
                        shapeIdx++;
                    }
                    slideIdx++;
                }

                // Serialize to JSON
                JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
                jsonOptions.WriteIndented = true;
                string json = JsonSerializer.Serialize(shapeInfos, jsonOptions);
                File.WriteAllText(outputJsonPath, json);

                // Save presentation before exit (save rule)
                pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}