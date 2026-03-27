using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define file paths
        string inputPath = "input.pptx";
        string outputPath = "output_removed.pptx";
        string newPresentationPath = "new_with_hyperlink.pptx";

        // Remove all hyperlinks from an existing presentation if the file exists
        if (File.Exists(inputPath))
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            presentation.HyperlinkQueries.RemoveAllHyperlinks();
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }

        // Create a new presentation and add a text box with a hyperlink
        Aspose.Slides.Presentation newPres = new Aspose.Slides.Presentation();
        Aspose.Slides.IAutoShape shape = newPres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);
        shape.AddTextFrame("Visit Aspose");
        // Set external hyperlink on the text portion
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com");
        // Set tooltip and formatting for the hyperlink
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Aspose website";
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14;
        // Save the new presentation
        newPres.Save(newPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        newPres.Dispose();
    }
}