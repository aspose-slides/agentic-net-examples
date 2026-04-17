using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectAllShapes
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
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through each slide
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    IShapeCollection shapes = slide.Shapes;

                    // Connect every pair of shapes on the slide
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        for (int j = i + 1; j < shapes.Count; j++)
                        {
                            IShape shape1 = shapes[i];
                            IShape shape2 = shapes[j];

                            // Add a bent connector and connect the two shapes
                            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                            connector.StartShapeConnectedTo = shape1;
                            connector.EndShapeConnectedTo = shape2;
                            connector.Reroute();
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported file format
                Console.WriteLine("An error occurred: " + ex.Message);
                // TODO: Add specific handling for unsupported formats
            }
        }
    }
}