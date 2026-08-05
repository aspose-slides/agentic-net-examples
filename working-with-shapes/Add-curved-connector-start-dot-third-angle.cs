// -----------------------------------------------------------------------------
// Example: Add curved connector start dot third angle using C#
//
// Description:
// Demonstrates how to add a rectangle shape, create a curved connector, attach
// the connector's start point to the third connection site of the rectangle,
// calculate the connector's line angle, and save the result as a PPTX file
// using Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces the requested output in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Curved Connector, Start Dot,
// Third Connection Site, Angle Calculation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a curved connector with its start dot linked to the third
//   connection site of a shape.
// - Build C# utilities for PowerPoint presentation processing that involve
//   custom connector placement.
// - Generate or transform PPTX files with specific connector configurations in
//   .NET applications.
// - Validate connector geometry and angles before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape to provide connection sites
                IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

                // Add a curved connector
                IConnector connector = slide.Shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 100, 100);

                // Set the start dot to the third connection site (index 2)
                connector.StartShapeConnectedTo = rect;
                connector.StartShapeConnectionSiteIndex = 2;

                // Compute the line angle based on the connector's bounding box
                double deltaX = connector.X + connector.Width - connector.X;
                double deltaY = connector.Y + connector.Height - connector.Y;
                double angleRadians = Math.Atan2(deltaY, deltaX);
                double angleDegrees = angleRadians * (180.0 / Math.PI);
                Console.WriteLine("Connector line angle: " + angleDegrees);

                // Save the presentation
                pres.Save("CurvedConnector.pptx", SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxException ex)
        {
            Console.WriteLine("PPTX format error: " + ex.Message);
        }
        catch (Aspose.Slides.PptException ex)
        {
            Console.WriteLine("PPT format error: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
