using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Tag that must be present on a slide to keep it visible
        string requiredTag = "MyTag";

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
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Hide the slide if its Name does not contain the required tag
                    // (Tags property does not exist; using Name as a placeholder for tag data)
                    if (slide.Name == null || !slide.Name.Contains(requiredTag))
                    {
                        slide.Hidden = true;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}