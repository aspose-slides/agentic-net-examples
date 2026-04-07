using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomXmlPartsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path (use first argument if provided)
            string inputPath;
            if (args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("The specified presentation file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Retrieve all custom XML parts
                    Aspose.Slides.ICustomXmlPart[] customParts = presentation.AllCustomXmlParts;

                    Console.WriteLine("Number of custom XML parts: " + customParts.Length);

                    // List each custom XML part's ID and XML content
                    foreach (Aspose.Slides.ICustomXmlPart part in customParts)
                    {
                        Console.WriteLine("Part ID: " + part.ItemId);
                        Console.WriteLine("XML Content:");
                        Console.WriteLine(part.XmlAsString);
                        Console.WriteLine(new string('-', 40));
                    }

                    // Save the presentation (no modifications made)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, the exception message will indicate it.
            }
        }
    }
}