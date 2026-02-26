using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Save the presentation as XPS format
        presentation.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps);
        // Ensure resources are released
        presentation.Dispose();
    }
}