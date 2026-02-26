using System;
using System.Text.RegularExpressions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first shape on the first slide as an AutoShape
        Aspose.Slides.AutoShape autoShape = presentation.Slides[0].Shapes[0] as Aspose.Slides.AutoShape;

        if (autoShape != null && autoShape.TextFrame != null)
        {
            // Define a regex to match words with 10 or more characters
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\b[^\s]{10,}\b");

            // Highlight matches in blue
            autoShape.TextFrame.HighlightRegex(regex, System.Drawing.Color.Blue, null);
        }

        // Save the modified presentation as PPTX
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}