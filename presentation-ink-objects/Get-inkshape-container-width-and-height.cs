using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Ink;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
        string dataDir = "Data";
        string inputPath = Path.Combine(dataDir, "input.pptx");

        // Check if the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Find the first Ink shape on the first slide
                Aspose.Slides.Ink.Ink inkShape = null;
                foreach (IShape shape in pres.Slides[0].Shapes)
                {
                    inkShape = shape as Aspose.Slides.Ink.Ink;
                    if (inkShape != null)
                        break;
                }

                if (inkShape != null)
                {
                    // Retrieve width and height of the Ink shape container
                    float width = inkShape.Width;
                    float height = inkShape.Height;
                    Console.WriteLine($"Ink shape width: {width}, height: {height}");
                }
                else
                {
                    Console.WriteLine("No Ink shape found in the presentation.");
                }

                // Save the presentation before exiting
                string outputPath = Path.Combine(dataDir, "output.pptx");
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}