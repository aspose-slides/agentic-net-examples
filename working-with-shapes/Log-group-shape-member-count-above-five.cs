using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideGroupAnalyzer
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

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate over each slide
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate over each shape on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a group shape
                        if (shape is IGroupShape groupShape)
                        {
                            // Get the number of shapes inside the group
                            int memberCount = groupShape.Shapes.Count;

                            // Log if the group has more than five members
                            if (memberCount > 5)
                            {
                                Console.WriteLine($"Slide {slide.SlideNumber}: Group shape with {memberCount} members.");
                            }
                        }
                    }
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Format not supported or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}