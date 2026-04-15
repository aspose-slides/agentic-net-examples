using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Presentation pres = null;
        try
        {
            // Load the presentation
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        try
        {
            // Access the sections collection
            ISectionCollection sections = pres.Sections;

            if (sections.Count > 0)
            {
                // Get the last section
                ISection lastSection = sections[sections.Count - 1];

                // Remove the last section (slides will be merged into the previous section)
                sections.RemoveSection(lastSection);

                // Confirm removal
                Console.WriteLine("Removed last section. Remaining sections: " + sections.Count);
            }
            else
            {
                Console.WriteLine("No sections to remove.");
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error processing presentation: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}