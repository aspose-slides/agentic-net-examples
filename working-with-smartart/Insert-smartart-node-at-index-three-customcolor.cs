// -----------------------------------------------------------------------------
// Example: Insert smartart node at index three customcolor using C#
//
// Description:
// Demonstrates how to insert a SmartArt node at index three with a custom
// bullet fill color using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a Basic Block List SmartArt diagram, ensures at least
// three existing nodes, inserts a new node at the fourth position (zero‑based
// index three), applies an orange solid fill to the node's bullet, and saves
// the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, SmartArt, Node, Index,
// Custom Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a SmartArt node at a specific index with custom styling.
// - Build C# tools for PowerPoint presentation processing that modify SmartArt.
// - Generate or transform PPTX files with customized SmartArt elements in .NET applications.
// - Validate SmartArt manipulation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Ensure there are at least three nodes before inserting at index three
                while (smartArt.Nodes.Count < 3)
                {
                    smartArt.Nodes.AddNode();
                }

                // Insert a new node at position three (zero‑based)
                ISmartArtNode newNode = smartArt.Nodes.AddNodeByPosition(3);

                // Apply a custom fill color to the new node's bullet
                if (newNode.BulletFillFormat != null)
                {
                    newNode.BulletFillFormat.FillType = FillType.Solid;
                    newNode.BulletFillFormat.SolidFillColor.Color = Color.Orange;
                }

                // Save the presentation
                presentation.Save("SmartArtNodeInserted.pptx", SaveFormat.Pptx);
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            // Handle index out of range errors
            Console.WriteLine("Index error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
