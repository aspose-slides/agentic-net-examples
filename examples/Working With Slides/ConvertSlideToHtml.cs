using System;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation from file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        
        // Convert the presentation to HTML format and save
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);
        
        // Release resources
        presentation.Dispose();
    }
}