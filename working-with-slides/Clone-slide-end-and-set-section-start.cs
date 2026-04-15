using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the slide to be cloned (first slide in this example)
            Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

            // Add a new section starting from the source slide
            Aspose.Slides.ISection newSection = presentation.Sections.AddSection("Cloned Section", sourceSlide);

            // Clone the source slide to the end of the newly created section
            presentation.Slides.AddClone(sourceSlide, newSection);

            // Set the start slide number for the presentation (e.g., start from slide number 5)
            presentation.FirstSlideNumber = 5;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}