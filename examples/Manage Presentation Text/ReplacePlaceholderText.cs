using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Replace placeholder text "[placeholder]" with "New Text"
        Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, "[placeholder]", "New Text", null);

        // Save the updated presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}