using System;
using System.IO;
using Aspose.Slides.Export;

namespace AddBrandingMetadata
{
    class Program
    {
        static void Main()
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Branding metadata as XML string
            string brandingXml = "<Branding><Company>MyCompany</Company><Product>MyProduct</Product></Branding>";

            try
            {
                // Load existing presentation if it exists; otherwise create a new one
                Aspose.Slides.Presentation presentation;
                if (File.Exists(inputPath))
                {
                    presentation = new Aspose.Slides.Presentation(inputPath);
                }
                else
                {
                    presentation = new Aspose.Slides.Presentation();
                }

                // Add custom XML part containing branding metadata
                Aspose.Slides.ICustomData customData = presentation.CustomData;
                Aspose.Slides.ICustomXmlPartCollection xmlParts = customData.CustomXmlParts;
                xmlParts.Add(brandingXml);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}