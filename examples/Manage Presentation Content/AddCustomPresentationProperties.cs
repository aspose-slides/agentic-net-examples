using System;

namespace PresentationPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Set built-in properties
            docProps.Author = "John Doe";
            docProps.Title = "Custom Properties Demo";
            docProps.Subject = "Aspose.Slides Example";

            // Add custom properties
            docProps.SetCustomPropertyValue("CustomString", "Hello World");
            docProps.SetCustomPropertyValue("CustomInt", 42);
            docProps.SetCustomPropertyValue("CustomDate", DateTime.UtcNow);

            // Save the presentation in PPT format
            presentation.Save("CustomPropertiesDemo.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        }
    }
}