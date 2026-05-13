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
                var presentation = new Aspose.Slides.Presentation();
                var shapes = presentation.Slides[0].Shapes;

                // Define a set of connector shape types to examine
                var connectorTypes = new Aspose.Slides.ShapeType[]
                {
                    Aspose.Slides.ShapeType.BentConnector2,
                    Aspose.Slides.ShapeType.StraightConnector1,
                    Aspose.Slides.ShapeType.CurvedConnector2,
                    Aspose.Slides.ShapeType.BentConnector3
                };

                foreach (var type in connectorTypes)
                {
                    // Add a connector of the current type
                    var connector = shapes.AddConnector(type, 0, 0, 10, 10);
                    // Retrieve the number of adjustment points
                    var adjustmentCount = connector.Adjustments.Count;
                    Console.WriteLine($"Connector Type: {type}, Adjustment Points: {adjustmentCount}");
                }

                var outputPath = "ConnectorAdjustments.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}