using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
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
                // Validate that each master slide contains at least one layout slide
                foreach (IMasterSlide master in presentation.Masters)
                {
                    if (master.LayoutSlides.Count == 0)
                    {
                        Console.WriteLine("Master slide '{0}' has no layout slides.", master.Name);
                        // Add a default layout slide to satisfy the validation
                        master.LayoutSlides.Add(SlideLayoutType.Title, "Default Title");
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}