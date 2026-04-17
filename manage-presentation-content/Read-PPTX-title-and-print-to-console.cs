using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "sample.pptx";

            // Check if the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load only document properties
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.OnlyLoadDocumentProperties = true;

                // Open the presentation
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Access document properties
                IDocumentProperties docProps = presentation.DocumentProperties;

                // Read the Title property
                string title = docProps.Title;
                Console.WriteLine("Title: " + title);

                // Save the presentation before exit (no changes made)
                presentation.Save(inputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}