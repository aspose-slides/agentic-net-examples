using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (Aspose.Slides.IBaseSlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Get fill type
                            Aspose.Slides.IFillFormat fillFormat = shape.FillFormat;
                            string fillType = "None";
                            if (fillFormat != null)
                            {
                                fillType = fillFormat.FillType.ToString();
                            }

                            // Get line color
                            Aspose.Slides.ILineFormat lineFormat = shape.LineFormat;
                            string lineColorString = "None";
                            if (lineFormat != null && lineFormat.FillFormat != null && lineFormat.FillFormat.SolidFillColor != null)
                            {
                                Color lineColor = lineFormat.FillFormat.SolidFillColor.Color;
                                lineColorString = lineColor.ToString();
                            }

                            // Log shape information
                            Console.WriteLine($"Shape: {shape.Name}, Fill Type: {fillType}, Line Color: {lineColorString}");
                        }
                    }

                    // Save the presentation before exiting
                    try
                    {
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}