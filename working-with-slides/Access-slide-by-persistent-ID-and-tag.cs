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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            uint slideId = 256; // Persistent ID of the slide to modify

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Retrieve the slide by its persistent ID
                    IBaseSlide baseSlide = presentation.GetSlideById(slideId);
                    Aspose.Slides.Slide slide = baseSlide as Aspose.Slides.Slide;

                    if (slide != null)
                    {
                        // Add a new custom tag
                        slide.CustomData.Tags.Add("Author", "John Doe");
                        // Update an existing tag (or add if it does not exist)
                        slide.CustomData.Tags["Version"] = "2.0";
                    }
                    else
                    {
                        Console.WriteLine($"Slide with ID {slideId} not found or is not a regular slide.");
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested save format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}