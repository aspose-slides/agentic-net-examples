// -----------------------------------------------------------------------------
// Example: Add connector set adjustments (half) and save PPTX using C#
//
// Description:
// Demonstrates how to add a bent connector shape, unlock its adjustment handles,
// set its adjustment values to half (0.5) and save the presentation as PPTX using
// Aspose.Slides for .NET. The example illustrates the required steps for
// manipulating connector adjustments and persisting the result in a console
// application.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Connector, BentConnector, Adjustments, Half, Save
//
// Use Cases:
// - Programmatically add connectors with specific adjustment values.
// - Create or modify PPTX files with customized connector geometry.
// - Automate presentation generation or transformation in .NET applications.
// - Validate connector adjustments before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddConnectorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a bent connector shape
                IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 100, 100, 200, 0);

                // Enable adjustment handles
                connector.ConnectorLock.AdjustHandlesLocked = false;

                // Set both adjustment values to 0.5 (using RawValue; the actual scale depends on the shape)
                // Here we use a generic value; adjust as needed for specific shape behavior
                if (connector.Adjustments.Count > 0)
                {
                    connector.Adjustments[0].RawValue = 50000; // Approx. 0.5 in shape's internal units
                }
                if (connector.Adjustments.Count > 1)
                {
                    connector.Adjustments[1].RawValue = 50000;
                }

                // Save the presentation
                try
                {
                    presentation.Save("ConnectorAdjustment.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
