using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputCsvPath = "group_shapes_alttext.csv";
            string savedPath = "saved_output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Prepare CSV writer
                    using (StreamWriter sw = new StreamWriter(outputCsvPath, false))
                    {
                        // Write CSV header
                        sw.WriteLine("SlideIndex,GroupShapeIndex,AltText");

                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                        {
                            ISlide slide = pres.Slides[slideIndex];
                            // Iterate through shapes on the slide
                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                IShape shape = slide.Shapes[shapeIndex];
                                // Check if the shape is a group shape
                                IGroupShape groupShape = shape as IGroupShape;
                                if (groupShape != null)
                                {
                                    string altText = groupShape.AlternativeText ?? string.Empty;
                                    // Escape double quotes in CSV
                                    altText = altText.Replace("\"", "\"\"");
                                    sw.WriteLine($"{slideIndex + 1},{shapeIndex + 1},\"{altText}\"");
                                }
                            }
                        }
                    }

                    // Save presentation before exit (optional copy)
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}