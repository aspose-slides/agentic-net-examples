using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the shape collection of the first slide
                Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

                // Assume the first shape is a group shape to be cloned
                Aspose.Slides.IShape sourceGroup = shapes[0];

                // Clone the group shape and add it to the end of the collection
                Aspose.Slides.IShape clonedGroup = shapes.AddClone(sourceGroup);

                // Modify the position of the cloned group shape
                clonedGroup.X = sourceGroup.X + 100f; // shift right by 100 points
                clonedGroup.Y = sourceGroup.Y + 50f;  // shift down by 50 points

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}