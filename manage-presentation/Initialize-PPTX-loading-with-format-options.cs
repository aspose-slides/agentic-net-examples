using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadPresentationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation file
            string inputPath = "input.pptx";
            // Path to the output presentation file
            string outputPath = "output.pptx";

            // Initialize LoadOptions with desired settings
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            // Automatically detect the format of the source file
            loadOptions.LoadFormat = Aspose.Slides.LoadFormat.Auto;
            // Set a default regular font in case the source font is missing
            loadOptions.DefaultRegularFont = "Arial";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load the presentation using the specified options
                presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // Perform any processing here (e.g., access slides, modify content)

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Aspose.Slides.PptReadException ex)
            {
                Console.WriteLine("Error reading the presentation: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}