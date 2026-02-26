using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load an existing PPT presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.ppt");

        // Access the document properties of the presentation
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Modify built‑in properties
        docProps.Author = "John Doe";
        docProps.Title = "Updated Presentation";
        docProps.Subject = "Demo";

        // Save the presentation in PPT format
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Release resources
        presentation.Dispose();
    }
}