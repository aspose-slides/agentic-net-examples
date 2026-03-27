using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationMetadata
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

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Access document properties
                IDocumentProperties docProps = pres.DocumentProperties;

                // Built‑in properties
                int slideCount = docProps.Slides;
                string author = docProps.Author;
                DateTime createdTime = docProps.CreatedTime;

                Console.WriteLine("Slide count: " + slideCount);
                Console.WriteLine("Author: " + author);
                Console.WriteLine("Created (UTC): " + createdTime.ToString("u"));

                // Custom properties
                int customCount = docProps.CountOfCustomProperties;
                Console.WriteLine("Custom properties count: " + customCount);
                for (int i = 0; i < customCount; i++)
                {
                    string propName = docProps.GetCustomPropertyName(i);
                    object propValue = docProps[propName];
                    Console.WriteLine("Custom Property - Name: " + propName + ", Value: " + (propValue ?? "null"));
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}