using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export.Xaml;

namespace PresentationToXaml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output locations
            string inputPath = "input.pptx";
            string outputFolder = "output_xaml";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Ensure the output directory exists
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Configure XAML export options
                XamlOptions xamlOptions = new XamlOptions();
                xamlOptions.ExportHiddenSlides = true;

                // Change working directory to the output folder so XAML files are written there
                string originalDirectory = Directory.GetCurrentDirectory();
                Directory.SetCurrentDirectory(outputFolder);

                // Save the presentation as XAML
                presentation.Save(xamlOptions);

                // Restore original working directory
                Directory.SetCurrentDirectory(originalDirectory);

                // Dispose of the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully converted to XAML.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}