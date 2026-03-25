using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideAnimationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Set precise transition durations (in milliseconds) for each slide
                // Example: first slide 2000 ms, second slide 3000 ms, third slide 4000 ms, others default 1500 ms
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    if (i == 0)
                    {
                        slide.SlideShowTransition.Duration = 2000;
                    }
                    else if (i == 1)
                    {
                        slide.SlideShowTransition.Duration = 3000;
                    }
                    else if (i == 2)
                    {
                        slide.SlideShowTransition.Duration = 4000;
                    }
                    else
                    {
                        slide.SlideShowTransition.Duration = 1500;
                    }

                    // Ensure the slide advances on click and after the specified time
                    slide.SlideShowTransition.AdvanceOnClick = true;
                    slide.SlideShowTransition.AdvanceAfterTime = (uint)slide.SlideShowTransition.Duration;
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}