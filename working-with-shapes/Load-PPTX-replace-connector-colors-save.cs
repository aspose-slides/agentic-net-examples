using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceConnectorLineColors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get a theme line color (using the first line style from the master theme)
                    Color themeLineColor = pres.MasterTheme.FormatScheme.LineStyles[0].FillFormat.SolidFillColor.Color;

                    // Iterate through all slides and shapes
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Check if the shape is a connector
                            if (shape is Connector)
                            {
                                Connector connector = (Connector)shape;
                                // Set line fill to solid and apply the theme color
                                connector.LineFormat.FillFormat.FillType = FillType.Solid;
                                connector.LineFormat.FillFormat.SolidFillColor.Color = themeLineColor;
                            }
                        }
                    }

                    // Save the updated presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}