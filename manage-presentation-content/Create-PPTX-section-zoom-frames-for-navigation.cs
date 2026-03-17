using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SectionZoomExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation that contains at least two sections
                var presentationPath = "Presentation.pptx";
                using (var pres = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Ensure there are at least two sections
                    if (pres.Sections.Count < 2)
                    {
                        Console.WriteLine("The presentation must contain at least two sections.");
                        return;
                    }

                    // Add a Section Zoom frame on the first slide referencing the second section
                    var firstSlide = pres.Slides[0];
                    var targetSection = pres.Sections[1];
                    var zoomFrame = firstSlide.Shapes.AddSectionZoomFrame(150f, 20f, 50f, 50f, targetSection);

                    // Optionally, customize the zoom frame (e.g., set name)
                    zoomFrame.Name = "SectionZoom_1";

                    // Save the modified presentation
                    var outputPath = "SectionZoomOutput.pptx";
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved to {outputPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}