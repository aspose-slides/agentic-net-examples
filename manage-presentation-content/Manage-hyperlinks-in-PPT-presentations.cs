using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // -------------------------------------------------
        // Create a new shape with an external hyperlink
        // -------------------------------------------------
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
        shape.AddTextFrame("Click Here");
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
            new Aspose.Slides.Hyperlink("https://www.example.com");
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Go to Example";

        // -------------------------------------------------
        // Modify the existing hyperlink (change URL and tooltip)
        // -------------------------------------------------
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
            new Aspose.Slides.Hyperlink("https://www.changed.com");
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Changed Link";

        // -------------------------------------------------
        // Delete the hyperlink from the shape using HyperlinkManager
        // -------------------------------------------------
        Aspose.Slides.IHyperlinkManager manager = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
        manager.RemoveHyperlinkClick();

        // -------------------------------------------------
        // Remove all hyperlinks from the presentation
        // -------------------------------------------------
        presentation.HyperlinkQueries.RemoveAllHyperlinks();

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}