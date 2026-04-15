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
            // Determine input file path
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate over all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate over all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a group shape
                            Aspose.Slides.IGroupShape groupShape = shape as Aspose.Slides.IGroupShape;
                            if (groupShape != null)
                            {
                                // Get the number of member shapes in the group
                                int memberCount = groupShape.Shapes.Count;

                                // Log if the group contains more than five members
                                if (memberCount > 5)
                                {
                                    Console.WriteLine("Slide " + slide.SlideNumber + " contains a group shape with " + memberCount + " members.");
                                }
                            }
                        }
                    }

                    // Save the presentation (could be the same file or a new one)
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported file format
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment: // format not supported
            }
        }
    }
}