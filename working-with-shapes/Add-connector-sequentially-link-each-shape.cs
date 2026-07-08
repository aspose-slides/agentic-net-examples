using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesConnectorBatch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add sample shapes to the slide
                    IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 100);
                    IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 250, 50, 150, 100);
                    IAutoShape triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 150, 200, 150, 100);

                    // Store shapes in an array for sequential processing
                    IShape[] shapes = new IShape[] { rect, ellipse, triangle };

                    // Iterate through shapes and connect each shape to the next one
                    for (int i = 0; i < shapes.Length - 1; i++)
                    {
                        IShape startShape = shapes[i];
                        IShape endShape = shapes[i + 1];

                        // Ensure both shapes have at least one connection site
                        if (startShape.ConnectionSiteCount == 0 || endShape.ConnectionSiteCount == 0)
                        {
                            // Skip connection if a shape does not support connection sites
                            continue;
                        }

                        // Add a bent connector to the slide
                        IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                        // Connect the shapes
                        connector.StartShapeConnectedTo = startShape;
                        connector.EndShapeConnectedTo = endShape;

                        // Use the first connection site (index 0) for both shapes
                        connector.StartShapeConnectionSiteIndex = 0;
                        connector.EndShapeConnectionSiteIndex = 0;

                        // Reroute the connector to take the shortest path
                        connector.Reroute();
                    }

                    // Save the presentation before exiting
                    presentation.Save("ConnectedShapes.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}