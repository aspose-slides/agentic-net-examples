using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";

        // Path where the updated PPTX will be saved
        string outputPath = "output.pptx";

        // Load the presentation from the source file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath);

        // Find and replace text throughout the presentation (including master slides)
        // Parameters: presentation, withMasters, find text, replace text, optional format (null uses existing format)
        Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "oldText", "newText", null);

        // Save the modified presentation in PPTX format
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}