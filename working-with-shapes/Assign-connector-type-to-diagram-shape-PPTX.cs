using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first SmartArt diagram on the slide
                IShape smartArtShape = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        smartArtShape = shape;
                        break;
                    }
                }

                if (smartArtShape != null)
                {
                    // Cast to ISmartArt to work with its nodes
                    ISmartArt smartArt = (ISmartArt)smartArtShape;

                    // Ensure there are at least two nodes to connect
                    if (smartArt.Nodes.Count >= 2)
                    {
                        // Get the first shape of the first two nodes
                        ISmartArtShape firstNodeShape = smartArt.Nodes[0].Shapes[0];
                        ISmartArtShape secondNodeShape = smartArt.Nodes[1].Shapes[0];

                        // Add a bent connector to the slide
                        IShapeCollection shapes = slide.Shapes;
                        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                        connector.StartShapeConnectedTo = firstNodeShape;
                        connector.EndShapeConnectedTo = secondNodeShape;
                        connector.Reroute();
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}