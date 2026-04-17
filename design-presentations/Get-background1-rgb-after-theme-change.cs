using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                using (var presentation = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    var slide = presentation.Slides[0];

                    // Modify the theme's background fill to use SchemeColor.Background1
                    slide.Background.Type = Aspose.Slides.BackgroundType.Themed;
                    slide.Background.StyleColor.SchemeColor = Aspose.Slides.SchemeColor.Background1;

                    // Set a custom color for the Background1 scheme color
                    slide.Background.StyleColor.Color = Color.FromArgb(255, 70, 130, 180); // SteelBlue

                    // Retrieve the effective RGB value of SchemeColor.Background1
                    var effectiveColor = slide.Background.StyleColor.Color;
                    Console.WriteLine($"Effective Background1 RGB: {effectiveColor.R}, {effectiveColor.G}, {effectiveColor.B}");

                    // Save the presentation
                    var outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, web service errors)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}