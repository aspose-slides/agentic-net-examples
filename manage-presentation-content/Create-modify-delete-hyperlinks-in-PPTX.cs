using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Add a rectangle shape with an external hyperlink
            Aspose.Slides.IAutoShape rectShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);
            rectShape.AddTextFrame("Click Here");
            rectShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("https://www.example.com");
            rectShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Example site";
            rectShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 20;

            // Modify the hyperlink's tooltip and font size
            rectShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Updated example";
            rectShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;

            // Add a blank button shape with a macro hyperlink
            Aspose.Slides.IAutoShape macroShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.BlankButton, 100, 200, 150, 40);
            macroShape.HyperlinkManager.SetMacroHyperlinkClick("MyMacro");

            // Remove the hyperlink from the rectangle shape
            rectShape.HyperlinkManager.RemoveHyperlinkClick();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}