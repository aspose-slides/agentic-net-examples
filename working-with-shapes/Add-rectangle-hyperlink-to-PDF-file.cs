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
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
            shape.AddTextFrame("Open PDF");
            // Set external hyperlink to a local PDF file
            shape.HyperlinkManager.SetExternalHyperlinkClick("C:\\Docs\\sample.pdf");
            // Save the presentation
            presentation.Save("HyperlinkPdf.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file scenario
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}