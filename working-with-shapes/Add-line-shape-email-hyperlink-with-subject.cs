using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100f, 100f, 400f, 0f);
            line.LineFormat.Width = 5f;
            // Hyperlink that opens an email client with a subject line
            Aspose.Slides.Hyperlink emailLink = new Aspose.Slides.Hyperlink("mailto:someone@example.com?subject=Hello");
            line.HyperlinkClick = emailLink;
            // Save the presentation
            presentation.Save("LineHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}