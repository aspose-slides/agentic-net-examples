using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveSlideByIdExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file, slide identifier, and output file can be passed as arguments
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 2 ? args[2] : "output.pptx";
            uint slideId = 0;

            if (args.Length > 1 && UInt32.TryParse(args[1], out uint parsedId))
            {
                slideId = parsedId;
            }
            else
            {
                Console.WriteLine("Please provide a valid slide identifier as the second argument.");
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve the slide (or master/layout) by its identifier
                    Aspose.Slides.IBaseSlide baseSlide = presentation.GetSlideById(slideId);

                    // Ensure the retrieved object is a regular slide before removal
                    Aspose.Slides.ISlide slide = baseSlide as Aspose.Slides.ISlide;
                    if (slide != null)
                    {
                        // Remove the slide from the presentation
                        slide.Remove();
                        // Save the modified presentation
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                        Console.WriteLine($"Slide with ID {slideId} removed and saved to '{outputPath}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Slide with ID {slideId} is not a regular slide or does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}