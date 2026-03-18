using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ConnectSmartArtExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the shape collection of the first slide
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = shapes.AddSmartArt(0, 0, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Retrieve the first two SmartArt nodes
                Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes[0];
                Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes[1];

                // Get the first shape from each node
                Aspose.Slides.SmartArt.ISmartArtShape smartShape1 = node1.Shapes[0];
                Aspose.Slides.SmartArt.ISmartArtShape smartShape2 = node2.Shapes[0];

                // Add a bent connector shape
                Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the connector between the two SmartArt shapes
                connector.StartShapeConnectedTo = smartShape1;
                connector.EndShapeConnectedTo = smartShape2;

                // Reroute the connector to the shortest path
                connector.Reroute();

                // Save the presentation
                presentation.Save("ConnectorSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}