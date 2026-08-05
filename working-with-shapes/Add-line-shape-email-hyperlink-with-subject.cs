// -----------------------------------------------------------------------------
// Example: Add line shape email hyperlink with subject using C#
//
// Description:
// Demonstrates how to add a line shape with an email hyperlink that includes a
// subject line using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a line shape, assigns a mailto hyperlink with a subject,
// and saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint workflows that require interactive email links.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Email Hyperlink, Subject,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with email hyperlinks that include predefined subjects.
// - Build C# utilities for enhancing PowerPoint presentations with interactive email links.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate hyperlink functionality within presentation automation pipelines.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 100f, 100f, 400f, 0f);
            line.LineFormat.Width = 5f;

            // Hyperlink that opens an email client with a subject line
            Hyperlink emailLink = new Hyperlink("mailto:someone@example.com?subject=Hello");
            line.HyperlinkClick = emailLink;

            // Save the presentation
            presentation.Save("LineHyperlink.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
