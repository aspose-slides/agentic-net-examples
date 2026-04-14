using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorDuplicationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
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
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    Aspose.Slides.ISlideCollection slides = pres.Slides;
                    for (int slideIndex = 0; slideIndex < slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = slides[slideIndex];
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                        // Iterate through shapes to find connectors
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.Shape shape = (Aspose.Slides.Shape)shapes[shapeIndex];
                            if (shape is Aspose.Slides.Connector)
                            {
                                Aspose.Slides.Connector originalConnector = (Aspose.Slides.Connector)shape;

                                // Duplicate the connector with an offset of 15 points
                                float newX = originalConnector.X + 15f;
                                float newY = originalConnector.Y + 15f;
                                float width = originalConnector.Width;
                                float height = originalConnector.Height;

                                // Add the duplicated connector to the slide
                                Aspose.Slides.IConnector duplicatedConnector = shapes.AddConnector(
                                    originalConnector.ShapeType,
                                    newX,
                                    newY,
                                    width,
                                    height);

                                // Optionally, copy line formatting (if needed)
                                duplicatedConnector.LineFormat.FillFormat.FillType = originalConnector.LineFormat.FillFormat.FillType;
                                duplicatedConnector.LineFormat.Width = originalConnector.LineFormat.Width;
                            }
                        }
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported file format, the format is not supported.
            }
        }
    }
}