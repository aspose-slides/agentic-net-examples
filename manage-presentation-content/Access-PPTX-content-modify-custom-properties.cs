using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the document properties of the presentation
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Modify built‑in properties
            docProps.Author = "John Doe";
            docProps.Title = "Sample Presentation";

            // Add custom properties
            docProps.SetCustomPropertyValue("CustomString", "Hello World");
            docProps.SetCustomPropertyValue("CustomNumber", 123);

            // Retrieve a custom property value
            if (docProps.ContainsCustomProperty("CustomString"))
            {
                object customValue = docProps["CustomString"]; // Indexer accesses custom property by name
                Console.WriteLine("CustomString = " + customValue);
            }

            // Update an existing custom property
            docProps["CustomNumber"] = 456;

            // Remove a custom property
            docProps.RemoveCustomProperty("CustomString");

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}