using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetGroupShapeHeaderFillGray
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate over all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate over all shapes in the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Check if shape is a group shape and its AlternativeText contains "Header"
                        IGroupShape groupShape = shape as IGroupShape;
                        if (groupShape != null && groupShape.AlternativeText != null && groupShape.AlternativeText.Contains("Header"))
                        {
                            // Ensure the shape has a FillFormat
                            if (groupShape.FillFormat != null)
                            {
                                // Set fill type to solid and color to gray
                                groupShape.FillFormat.FillType = FillType.Solid;
                                groupShape.FillFormat.SolidFillColor.Color = Color.Gray;
                            }
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}