using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
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
                // Ensure there is a second slide
                if (presentation.Slides.Count < 2)
                {
                    Console.WriteLine("The presentation does not contain a second slide.");
                }
                else
                {
                    Aspose.Slides.ISlide secondSlide = presentation.Slides[1];

                    // Iterate through all shapes on the second slide
                    foreach (Aspose.Slides.IShape shape in secondSlide.Shapes)
                    {
                        Aspose.Slides.IFillFormat fill = shape.FillFormat;
                        // Apply only to shapes with a solid fill
                        if (fill != null && fill.FillType == Aspose.Slides.FillType.Solid)
                        {
                            // Retrieve the current fill color
                            Color originalColor = fill.SolidFillColor.Color;
                            // Set 40% transparency (alpha = 102 out of 255)
                            Color transparentColor = Color.FromArgb(102, originalColor);
                            fill.SolidFillColor.Color = transparentColor;
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions (e.g., web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}