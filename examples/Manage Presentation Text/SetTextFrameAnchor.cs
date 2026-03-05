using System;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve all text frames from the presentation (including master slides)
        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

        // Iterate through each text frame and set its vertical anchoring type
        foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
        {
            // Access the text frame format
            Aspose.Slides.ITextFrameFormat format = textFrame.TextFrameFormat;

            // Set the anchoring type (e.g., Bottom)
            format.AnchoringType = Aspose.Slides.TextAnchorType.Bottom;
        }

        // Save the updated presentation as PPTX
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}