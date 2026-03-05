using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape with an external hyperlink
        Aspose.Slides.IAutoShape linkShape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);
        linkShape.AddTextFrame("Visit Aspose");
        linkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com");
        linkShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Aspose website";

        // Add a button shape with a macro hyperlink
        string macroName = "MyMacro";
        Aspose.Slides.IAutoShape macroShape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.BlankButton, 100, 200, 200, 40);
        macroShape.HyperlinkManager.SetMacroHyperlinkClick(macroName);

        // Save the presentation before exiting
        presentation.Save("PresentationLinks.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}