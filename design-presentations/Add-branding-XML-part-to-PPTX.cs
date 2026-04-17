using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomXmlPartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_with_branding.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Branding metadata as XML string
                    string brandingXml = "<Branding><Company>MyCompany</Company><Logo>logo.png</Logo></Branding>";

                    // Add custom XML part to the presentation package
                    // Assuming the CustomData property provides access to the custom XML part collection
                    ICustomXmlPart customPart = presentation.CustomData.CustomXmlParts.Add(brandingXml);

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}