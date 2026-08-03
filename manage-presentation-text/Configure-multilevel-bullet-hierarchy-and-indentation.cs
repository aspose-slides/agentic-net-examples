// -----------------------------------------------------------------------------
// Example: Configure multilevel bullet hierarchy and indentation using C#
//
// Description:
// Demonstrates how to configure a multilevel bullet hierarchy and indentation 
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example 
// creates a new presentation, adds a rectangle shape with a text frame, sets 
// up three bullet levels with custom indentation, and saves the result as a PPTX 
// file. This pattern can be used to automate bullet formatting in .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Multilevel, Bullet, 
// Hierarchy, Indentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate configuration of multilevel bullet hierarchy and indentation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom bullet structures in .NET 
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BulletHierarchyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Get the first slide
            ISlide slide = presentation.Slides[0];
            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);
            // Add a text frame with initial text
            ITextFrame textFrame = shape.AddTextFrame("Root Item");
            // Set autofit for the text frame
            textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

            // Configure first level bullet (depth 0)
            IParagraph para1 = textFrame.Paragraphs[0];
            para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226); // bullet character
            para1.ParagraphFormat.Depth = 0;
            para1.ParagraphFormat.Indent = 20f;

            // Add second level bullet (depth 1)
            Paragraph para2 = new Paragraph();
            para2.Text = "Second level item";
            para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
            para2.ParagraphFormat.Depth = 1;
            para2.ParagraphFormat.Indent = 40f;
            textFrame.Paragraphs.Add(para2);

            // Add third level bullet (depth 2)
            Paragraph para3 = new Paragraph();
            para3.Text = "Third level item";
            para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
            para3.ParagraphFormat.Depth = 2;
            para3.ParagraphFormat.Indent = 60f;
            textFrame.Paragraphs.Add(para3);

            // Save the presentation
            string outPath = Path.Combine(Environment.CurrentDirectory, "MultilevelBullets_out.pptx");
            try
            {
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
