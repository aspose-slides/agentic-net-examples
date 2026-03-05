using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first shape on the first slide as an AutoShape
        Aspose.Slides.AutoShape autoShape = (Aspose.Slides.AutoShape)presentation.Slides[0].Shapes[0];

        // Highlight the word "example" with Yellow color
        autoShape.TextFrame.HighlightText("example", System.Drawing.Color.Yellow);

        // Highlight the whole word "test" with LightBlue color using search options
        Aspose.Slides.TextSearchOptions options = new Aspose.Slides.TextSearchOptions();
        options.WholeWordsOnly = true;
        autoShape.TextFrame.HighlightText("test", System.Drawing.Color.LightBlue, options, null);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}