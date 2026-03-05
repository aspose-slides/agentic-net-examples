using System;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Get the first shape as AutoShape
        Aspose.Slides.AutoShape shape = pres.Slides[0].Shapes[0] as Aspose.Slides.AutoShape;

        // Highlight text matching the regex pattern
        if (shape != null && shape.TextFrame != null)
        {
            shape.TextFrame.HighlightRegex(
                new Regex(@"\b[^\s]{10,}\b"),
                System.Drawing.Color.Blue,
                null);
        }

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}