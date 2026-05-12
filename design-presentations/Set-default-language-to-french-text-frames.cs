using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetDefaultLanguage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_french.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Configure load options to set the default text language to French
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.DefaultTextLanguage = "fr-FR";

            // Load the presentation with the specified load options
            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Save the presentation; handle unsupported format exceptions
                try
                {
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported – handle accordingly
                    Console.WriteLine("The requested save format is not supported.");
                }
            }

            // Ensure the presentation is saved before exiting
            Console.WriteLine("Processing completed.");
        }
    }
}