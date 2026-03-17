using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input presentation file
            string inputPath = "input.pptx";

            // Output directory for external resources
            string outputDir = "output";

            // Full path of the generated HTML file
            string outputHtml = Path.Combine(outputDir, "output.html");

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the presentation and save it as HTML5 with external media assets
            using (Presentation pres = new Presentation(inputPath))
            {
                Html5Options options = new Html5Options()
                {
                    EmbedImages = false,          // Do not embed images, keep them as external files
                    OutputPath = outputDir        // Directory where external resources will be stored
                };

                pres.Save(outputHtml, SaveFormat.Html5, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}