using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation instance
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Get the document properties object
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Modify built‑in properties
            docProps.Author = "John Doe";
            docProps.Title = "Sample Presentation";
            docProps.Subject = "Demo";
            docProps.Category = "Examples";
            docProps.Comments = "Created with Aspose.Slides";
            docProps.Company = "Acme Corp";

            // Save the presentation in PPT format
            presentation.Save("ModifiedPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}