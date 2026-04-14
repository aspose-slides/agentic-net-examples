using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through each slide
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a group shape
                            Aspose.Slides.IGroupShape groupShape = shape as Aspose.Slides.IGroupShape;
                            if (groupShape != null)
                            {
                                // Output the alternative text of the group shape
                                Console.WriteLine(
                                    "Slide {0}, Group Shape {1}: Alt Text = \"{2}\"",
                                    slideIndex + 1,
                                    shapeIndex,
                                    groupShape.AlternativeText);
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other processing errors
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}