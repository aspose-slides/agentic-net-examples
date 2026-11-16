// -----------------------------------------------------------------------------
// Example: Remove Slides by Title Using Predicate in C#
// 
// Description:
// Demonstrates how to load a PowerPoint PPTX file, identify slides whose
// title (slide name) contains a specific keyword, remove those slides using a
// predicate, and save the resulting presentation. The program also creates a
// sample presentation if the input file is missing.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove Slides, Title Predicate
// 
// Use Cases:
// - Automate cleanup of presentations by removing unwanted slides.
// - Build utilities that filter slides based on naming conventions.
// - Preprocess PPTX files before distribution or further processing.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace RemoveSlidesByTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string keyword = "Keyword";

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ILayoutSlide layout = samplePres.Slides[0].LayoutSlide;

                    // Slide 1 - contains keyword
                    Aspose.Slides.ISlide slide1 = samplePres.Slides.AddEmptySlide(layout);
                    slide1.Name = "Keyword Slide 1";

                    // Slide 2 - does not contain keyword
                    Aspose.Slides.ISlide slide2 = samplePres.Slides.AddEmptySlide(layout);
                    slide2.Name = "Regular Slide";

                    // Slide 3 - contains keyword
                    Aspose.Slides.ISlide slide3 = samplePres.Slides.AddEmptySlide(layout);
                    slide3.Name = "Another Keyword Slide";

                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Predicate to match slide names containing the keyword
                Func<Aspose.Slides.ISlide, bool> titleMatches = delegate (Aspose.Slides.ISlide slide)
                {
                    return slide.Name != null && slide.Name.Contains(keyword);
                };

                // Collect indices of slides to remove
                List<int> indicesToRemove = new List<int>();
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    if (titleMatches(slide))
                    {
                        indicesToRemove.Add(i);
                    }
                }

                // Remove slides in reverse order to keep indices valid
                for (int i = indicesToRemove.Count - 1; i >= 0; i--)
                {
                    pres.Slides.RemoveAt(indicesToRemove[i]);
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Slides removed successfully. Output saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // The provided file format may not be supported by Aspose.Slides.
                Environment.Exit(1);
            }
        }
    }
}
