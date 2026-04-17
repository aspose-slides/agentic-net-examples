using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace DetectAndReplaceLineColor
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
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape has a line format
                        if (shape.LineFormat != null)
                        {
                            // Get effective line formatting (includes inheritance)
                            ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

                            // If effective line format exists, replace its line color
                            if (effectiveLine != null)
                            {
                                // Set a custom palette color (e.g., Accent2 from the theme)
                                // Fallback to a specific ARGB color if theme is unavailable
                                Color customColor = Color.FromArgb(0, 120, 215); // Custom blue

                                // Apply the custom color to the shape's line fill
                                shape.LineFormat.FillFormat.SolidFillColor.Color = customColor;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}