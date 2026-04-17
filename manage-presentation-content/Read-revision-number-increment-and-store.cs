using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RevisionNumberUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading errors (e.g., unsupported format)
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            try
            {
                // Access document properties
                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Read the current revision number, increment it, and store back
                int currentRevision = documentProperties.RevisionNumber;
                documentProperties.RevisionNumber = currentRevision + 1;

                // Save the updated presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors during property modification or saving
                Console.WriteLine("An error occurred: " + ex.Message);
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