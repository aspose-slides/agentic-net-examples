using System;

class Program
{
    static void Main(string[] args)
    {
        // Load the PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Convert and save to HTML using default image DPI (72)
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);
        // Release resources
        presentation.Dispose();
    }
}