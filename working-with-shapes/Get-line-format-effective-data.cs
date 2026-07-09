using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Ensure the slide has at least one shape
                    if (slide.Shapes.Count == 0)
                    {
                        Console.WriteLine("No shapes found on the first slide.");
                    }
                    else
                    {
                        // Get the first shape
                        IShape shape = slide.Shapes[0];

                        // Retrieve effective line formatting data
                        ILineFormatEffectiveData effectiveLineFormat = shape.LineFormat.GetEffective();

                        // Output some effective line format properties
                        Console.WriteLine("Effective line style: " + effectiveLineFormat.Style);
                        Console.WriteLine("Effective line width: " + effectiveLineFormat.Width);
                        Console.WriteLine("Effective fill type: " + effectiveLineFormat.FillFormat.FillType);
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, an exception will be thrown here.
            }
        }
    }
}