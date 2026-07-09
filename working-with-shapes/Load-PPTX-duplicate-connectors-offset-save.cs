using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesConnectorClone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Assume processing the first slide; adjust as needed
                    Aspose.Slides.ISlide slide = presentation.Slides[0];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                    // Collect all connectors on the slide
                    List<Aspose.Slides.IConnector> connectors = new List<Aspose.Slides.IConnector>();
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        Aspose.Slides.IShape shape = shapes[i];
                        if (shape is Aspose.Slides.IConnector)
                        {
                            connectors.Add((Aspose.Slides.IConnector)shape);
                        }
                    }

                    // Duplicate each connector with an offset of 15 points
                    foreach (Aspose.Slides.IConnector originalConnector in connectors)
                    {
                        float newX = originalConnector.X + 15f;
                        float newY = originalConnector.Y + 15f;

                        // Clone the connector and place it at the new location
                        shapes.AddClone((Aspose.Slides.IShape)originalConnector, newX, newY);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}