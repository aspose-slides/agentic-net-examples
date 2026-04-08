using System;
using System.Diagnostics;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DocumentPropertiesPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access document properties
                    Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                    // Start timing the enumeration of custom properties
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();

                    // Enumerate all custom properties
                    for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
                    {
                        string propertyName = documentProperties.GetCustomPropertyName(i);
                        object propertyValue = documentProperties[propertyName];
                        Console.WriteLine($"Property {i}: {propertyName} = {propertyValue}");
                    }

                    // Stop timing and log the elapsed time
                    stopwatch.Stop();
                    Console.WriteLine($"Enumeration took {stopwatch.ElapsedMilliseconds} ms.");

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}