using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ListPresentationProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
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
                // Handle unsupported format or other loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                // Format not supported comment
                // The file format may not be supported by Aspose.Slides.
                return;
            }

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Display built‑in properties
            Console.WriteLine("=== Built‑in Properties ===");
            Console.WriteLine("Title            : " + docProps.Title);
            Console.WriteLine("Author           : " + docProps.Author);
            Console.WriteLine("Subject          : " + docProps.Subject);
            Console.WriteLine("Category         : " + docProps.Category);
            Console.WriteLine("Comments         : " + docProps.Comments);
            Console.WriteLine("Created Time     : " + docProps.CreatedTime);
            Console.WriteLine("Last Saved By    : " + docProps.LastSavedBy);
            Console.WriteLine("Last Saved Time  : " + docProps.LastSavedTime);
            Console.WriteLine("Manager          : " + docProps.Manager);
            Console.WriteLine("Company          : " + docProps.Company);
            Console.WriteLine();

            // Display custom properties in tabular format
            Console.WriteLine("=== Custom Properties ===");
            int customCount = docProps.CountOfCustomProperties;
            if (customCount == 0)
            {
                Console.WriteLine("No custom properties found.");
            }
            else
            {
                Console.WriteLine("{0,-30} {1}", "Name", "Value");
                Console.WriteLine(new string('-', 45));
                for (int i = 0; i < customCount; i++)
                {
                    string propName = docProps.GetCustomPropertyName(i);
                    object propValue = docProps[propName];
                    Console.WriteLine("{0,-30} {1}", propName, propValue);
                }
            }

            // Save the presentation before exit
            try
            {
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle any saving errors (e.g., unsupported format)
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported comment
            }
            finally
            {
                // Release resources
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}