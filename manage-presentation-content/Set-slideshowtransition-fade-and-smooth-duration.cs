using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file (if you want to load an existing file)
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                // Create a new presentation or load an existing one if the file exists
                Aspose.Slides.Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Set the slide transition to Fade and adjust its duration (smooth transition)
                presentation.Slides[0].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                presentation.Slides[0].SlideShowTransition.Duration = 2000; // duration in milliseconds

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file I/O errors, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}