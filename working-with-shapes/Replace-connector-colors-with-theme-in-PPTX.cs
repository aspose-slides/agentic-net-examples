using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ReplaceConnectorColors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Get a theme color to apply (using Accent1 from the master theme)
            Color themeColor = pres.MasterTheme.ColorScheme.Accent1.Color;

            // Iterate through all slides and shapes
            foreach (ISlide slide in pres.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape has a line format (connectors have line formats)
                    if (shape.LineFormat != null)
                    {
                        // Set line fill to solid and apply the theme color
                        shape.LineFormat.FillFormat.FillType = FillType.Solid;
                        shape.LineFormat.FillFormat.SolidFillColor.Color = themeColor;
                    }
                }
            }

            // Save the updated presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}