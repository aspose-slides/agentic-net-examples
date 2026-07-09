using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectorAdjustmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the shape collection of the first slide
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add different types of connectors
                Aspose.Slides.IConnector bentConnector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
                Aspose.Slides.IConnector straightConnector = shapes.AddConnector(Aspose.Slides.ShapeType.StraightConnector1, 20, 0, 10, 10);
                Aspose.Slides.IConnector curvedConnector = shapes.AddConnector(Aspose.Slides.ShapeType.CurvedConnector2, 40, 0, 10, 10);

                // Array of connectors to process
                Aspose.Slides.IConnector[] connectors = new Aspose.Slides.IConnector[] { bentConnector, straightConnector, curvedConnector };

                // Log adjustment point counts for each connector type
                foreach (Aspose.Slides.IConnector connector in connectors)
                {
                    int adjustmentCount = connector.Adjustments.Count;
                    Console.WriteLine("Connector type " + connector.ShapeType.ToString() + " has " + adjustmentCount + " adjustment points.");
                }

                // Save the presentation
                string outputPath = "ConnectorAdjustments.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (System.Exception ex)
            {
                // Handle any unexpected exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}