using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConfigureExternalResources
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output.pptx";

            try
            {
                // Create load options and configure external resource handling
                LoadOptions loadOptions = new LoadOptions();
                // Delete all embedded binary objects (OLE, VBA, ActiveX) during loading for security
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                // Load the presentation with the specified options
                using (Presentation presentation = new Presentation(sourcePath, loadOptions))
                {
                    // Save the presentation in PPTX format
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during loading or saving
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}