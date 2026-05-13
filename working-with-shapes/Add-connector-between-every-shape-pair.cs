using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    IShapeCollection shapes = presentation.Slides[slideIndex].Shapes;
                    int shapeCount = shapes.Count;

                    // Add a connector between every pair of shapes
                    for (int i = 0; i < shapeCount; i++)
                    {
                        for (int j = i + 1; j < shapeCount; j++)
                        {
                            IShape shape1 = shapes[i];
                            IShape shape2 = shapes[j];

                            // Create a bent connector (default size, will be rerouted)
                            IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
                            connector.StartShapeConnectedTo = shape1;
                            connector.EndShapeConnectedTo = shape2;
                            connector.Reroute();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}