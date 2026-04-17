using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveCustomDataFromCharts
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

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Remove all custom XML parts (custom data) from the presentation
                    foreach (ICustomXmlPart part in pres.AllCustomXmlParts)
                    {
                        part.Remove();
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}