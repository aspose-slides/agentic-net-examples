using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle loading errors (e.g., unsupported format)
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate over all slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Get the shape collection of the current slide
                IShapeCollection shapes = slide.Shapes;

                // Iterate over each shape in the slide
                foreach (IShape shape in shapes)
                {
                    // Check if the shape is a group shape
                    IGroupShape groupShape = shape as IGroupShape;
                    if (groupShape != null)
                    {
                        // Get the number of member shapes inside the group
                        int memberCount = groupShape.Shapes.Count;

                        // Log if the group contains more than five members
                        if (memberCount > 5)
                        {
                            Console.WriteLine("Group shape with {0} members found on a slide.", memberCount);
                        }
                    }
                }
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}