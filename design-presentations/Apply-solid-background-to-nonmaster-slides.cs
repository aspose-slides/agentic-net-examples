using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplySolidBackground
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // If the slide does not have its own background (inherits from master)
                    if (slide.Background.Type != BackgroundType.OwnBackground)
                    {
                        // Set the slide to use its own background
                        slide.Background.Type = BackgroundType.OwnBackground;

                        // Set fill type to solid
                        slide.Background.FillFormat.FillType = FillType.Solid;

                        // Apply a solid color (e.g., LightGray)
                        slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;
                    }
                }

                // Save the presentation
                try
                {
                    presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException ex)
                {
                    // Handle unsupported PPTX format
                    Console.WriteLine("Unsupported PPTX format: " + ex.Message);
                }
                catch (Aspose.Slides.PptUnsupportedFormatException ex)
                {
                    // Handle unsupported PPT format
                    Console.WriteLine("Unsupported PPT format: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}