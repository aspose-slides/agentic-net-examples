using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through slides and shapes to find 3D models
            int slideIdx = 0;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                int shapeIdx = 0;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape has a 3D format (indicates a 3D model)
                    if (shape.ThreeDFormat != null)
                    {
                        // Construct output OBJ file name
                        string objPath = $"slide_{slideIdx}_shape_{shapeIdx}.obj";

                        // TODO: Extract vertex coordinates from the 3D shape and write them to the OBJ file.
                        // Aspose.Slides does not provide a direct OBJ export API, so custom extraction logic is required here.
                        // Example placeholder:
                        // using (StreamWriter writer = new StreamWriter(objPath))
                        // {
                        //     writer.WriteLine("# OBJ file for 3D shape");
                        //     // Write vertex data...
                        // }

                        Console.WriteLine($"3D shape found on slide {slideIdx}, shape {shapeIdx}. Export to {objPath} (implementation pending).");
                    }
                    shapeIdx++;
                }
                slideIdx++;
            }

            // Save the presentation before exiting (as required)
            string outputPath = "output.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported for this operation.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}