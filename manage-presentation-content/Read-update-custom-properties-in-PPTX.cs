using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace UpdateCustomProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Iterate through custom properties and modify their values
            for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
            {
                string propertyName = documentProperties.GetCustomPropertyName(i);
                object propertyValue = documentProperties[propertyName];
                // Example modification: append "_updated" to string representation
                documentProperties[propertyName] = propertyValue.ToString() + "_updated";
            }

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}