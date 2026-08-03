// -----------------------------------------------------------------------------
// Example: Check autoshape istextbox after adding text using C#
//
// Description:
// Demonstrates how to check if an AutoShape becomes a text box after adding a
// text frame using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a rectangle AutoShape, adds text to it, evaluates the
// IsTextBox property, outputs the result, and saves the presentation.
// This pattern helps developers automate PPTX workflows, validate shape
// properties, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, AutoShape, IsTextBox, 
// AddTextFrame, Presentation Processing, Office Automation
//
// Use Cases:
// - Verify whether an AutoShape is recognized as a text box after adding text.
// - Build C# utilities for PowerPoint presentation analysis and transformation.
// - Validate shape properties in automated PPTX generation pipelines.
// - Integrate shape‑type checks into larger .NET office automation solutions.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);
            autoShape.AddTextFrame("Sample text");
            bool isTextBox = autoShape.IsTextBox;
            Console.WriteLine("Is the shape a text box? " + isTextBox);
            try
            {
                pres.Save("IsTextBoxDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }
    }
}
