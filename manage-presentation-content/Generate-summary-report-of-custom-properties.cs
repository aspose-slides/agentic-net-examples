using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GenerateSummaryReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string inputPath = "presentation.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The specified file does not exist: " + inputPath);
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
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load the presentation. Reason: " + ex.Message);
                // Format not supported comment
                // The file format may not be supported by Aspose.Slides.
                return;
            }

            // Access document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Get the number of custom properties
            int customCount = documentProperties.CountOfCustomProperties;

            // List each custom property name and its data type
            for (int i = 0; i < customCount; i++)
            {
                string propertyName = documentProperties.GetCustomPropertyName(i);
                object propertyValue = documentProperties[propertyName]; // Use indexer, not Item
                string typeName = propertyValue == null ? "null" : propertyValue.GetType().Name;
                Console.WriteLine(propertyName + " : " + typeName);
            }

            // Save the presentation before exiting (as required)
            try
            {
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save the presentation. Reason: " + ex.Message);
                // Format not supported comment
                // The target format may not be supported by Aspose.Slides.
            }

            // Clean up
            presentation.Dispose();
        }
    }
}