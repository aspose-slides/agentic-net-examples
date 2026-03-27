using System;
using System.IO;
using Aspose.Slides.Export;

namespace DocumentPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Modify existing custom properties
            for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
            {
                string propertyName = documentProperties.GetCustomPropertyName(i);
                object propertyValue = documentProperties[propertyName];
                string newValue = propertyValue.ToString() + "_Modified_" + (i + 1);
                documentProperties[propertyName] = newValue;
            }

            // Add new custom properties
            documentProperties["CustomInt"] = 123;
            documentProperties["CustomString"] = "Hello World";

            // Remove a custom property if it exists
            if (documentProperties.ContainsCustomProperty("ObsoleteProp"))
            {
                documentProperties.RemoveCustomProperty("ObsoleteProp");
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}