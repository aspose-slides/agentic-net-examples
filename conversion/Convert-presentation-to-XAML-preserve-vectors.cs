using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure XAML export options
                XamlOptions options = new XamlOptions();
                options.ExportHiddenSlides = true; // Preserve hidden slides if any

                // Save the presentation as XAML markup
                pres.Save(options);

                Console.WriteLine("Presentation successfully converted to XAML.");
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Handle unsupported format scenario
            Console.WriteLine("The presentation format is not supported for XAML conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}