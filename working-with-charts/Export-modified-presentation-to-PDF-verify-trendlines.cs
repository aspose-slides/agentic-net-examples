using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pdf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Export the presentation to PDF format
                // This will retain any existing trend lines in the slides
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Net.WebException)
        {
            // Handle external URL or web service exceptions
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}