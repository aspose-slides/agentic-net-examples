using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the collection of master slides
            IMasterSlideCollection masters = presentation.Masters;

            // Output the number of master slides
            Console.WriteLine("Number of master slides: " + masters.Count);

            // Enumerate each master slide
            for (int i = 0; i < masters.Count; i++)
            {
                IMasterSlide master = masters[i];
                Console.WriteLine("Master " + i + " Name: " + master.Name);
            }

            // Save the presentation (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
            // Format not supported
        }
    }
}