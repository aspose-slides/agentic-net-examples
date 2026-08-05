// -----------------------------------------------------------------------------
// Example: Retrieve connector adjustment counts and log using C#
//
// Description:
// Demonstrates how to create connectors of various types in a new presentation,
// retrieve each connector's adjustment point count, and log the results to the
// console. The example uses Aspose.Slides for .NET to add connectors, query the
// Adjustments collection, and save the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retrieve, Connector, 
// Adjustment, Counts, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval of connector adjustment counts for validation.
// - Build C# utilities that analyze or modify connector shapes in PPTX files.
// - Generate sample presentations with connectors for testing or demos.
// - Integrate connector inspection into larger .NET PowerPoint workflows.
// -----------------------------------------------------------------------------
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
                var presentation = new Presentation();
                var shapes = presentation.Slides[0].Shapes;

                // Define a set of connector shape types to examine
                var connectorTypes = new ShapeType[]
                {
                    ShapeType.BentConnector2,
                    ShapeType.StraightConnector1,
                    ShapeType.CurvedConnector2,
                    ShapeType.BentConnector3
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
                presentation.Save(outputPath, SaveFormat.Pptx);
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
