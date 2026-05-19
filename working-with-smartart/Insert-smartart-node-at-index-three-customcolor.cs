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