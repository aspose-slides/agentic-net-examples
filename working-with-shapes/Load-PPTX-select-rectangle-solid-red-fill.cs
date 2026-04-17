using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Get the first shape (assumed to be a rectangle)
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Apply solid red fill
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Red;

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}