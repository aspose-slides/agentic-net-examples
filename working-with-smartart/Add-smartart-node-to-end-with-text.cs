// -----------------------------------------------------------------------------
// Example: Add SmartArt Node to End with Custom Text
//
// Description:
// This console application creates a new PowerPoint presentation, inserts a
// SmartArt diagram, adds a new node at the end of the SmartArt node collection,
// sets custom text for the node, and saves the presentation as a PPTX file.
// It demonstrates automating PowerPoint content creation using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, add node, custom text
//
// Use Cases:
// - Dynamically generate slide decks with customized SmartArt diagrams.
// - Automate report generation that includes hierarchical visualizations.
// - Integrate SmartArt manipulation into enterprise .NET applications.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "SmartArtNodeExample.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a SmartArt diagram to the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    50, 50, 500, 300,
                    Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

                // Add a new node at the end of the SmartArt node collection
                Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

                // Set custom text for the new node
                newNode.TextFrame.Text = "New End Node";

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
