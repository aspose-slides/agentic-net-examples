using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "sample.pptx";
            string outputPath = "sample.xps";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Preserve original author metadata
                string originalAuthor = presentation.DocumentProperties.Author;
                presentation.DocumentProperties.Author = originalAuthor;

                // Create XPS save options (default settings)
                Aspose.Slides.Export.XpsOptions xpsOptions = new Aspose.Slides.Export.XpsOptions();

                // Save the presentation as XPS, embedding metadata
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps, xpsOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
                Console.WriteLine("The file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}