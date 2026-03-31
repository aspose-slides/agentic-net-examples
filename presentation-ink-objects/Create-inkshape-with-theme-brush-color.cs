using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace InkShapeFactoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string selectedTheme = "Dark";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation. Possible unsupported format. " + ex.Message);
                return;
            }

            ApplyThemeToInk(presentation, selectedTheme);

            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }

        // Factory method that sets the ink brush color based on a theme
        static void ApplyThemeToInk(Aspose.Slides.Presentation pres, string theme)
        {
            // Assume the first shape on the first slide is an Ink shape
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0] as Aspose.Slides.Ink.Ink;
            if (shape == null)
            {
                Console.WriteLine("No Ink shape found on the first slide.");
                return;
            }

            Aspose.Slides.Ink.IInk ink = shape as Aspose.Slides.Ink.IInk;
            if (ink == null || ink.Traces.Length == 0)
            {
                Console.WriteLine("Ink shape does not contain any traces.");
                return;
            }

            Aspose.Slides.Ink.IInkBrush brush = ink.Traces[0].Brush;
            if (brush == null)
            {
                Console.WriteLine("Ink trace does not have a brush.");
                return;
            }

            // Set brush color based on theme
            if (theme.Equals("Dark", StringComparison.OrdinalIgnoreCase))
            {
                brush.Color = System.Drawing.Color.Black;
            }
            else if (theme.Equals("Light", StringComparison.OrdinalIgnoreCase))
            {
                brush.Color = System.Drawing.Color.White;
            }
            else if (theme.Equals("Blue", StringComparison.OrdinalIgnoreCase))
            {
                brush.Color = System.Drawing.Color.Blue;
            }
            else
            {
                // Default color
                brush.Color = System.Drawing.Color.Gray;
            }
        }
    }
}