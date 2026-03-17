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
            Presentation presentation = new Presentation("input.pptx");

            // Access the document properties interface
            IDocumentProperties docProps = presentation.DocumentProperties;

            // Modify built‑in properties
            docProps.Author = "John Doe";
            docProps.Title = "Sample Presentation";
            docProps.Subject = "Demo";

            // Add a custom property
            docProps.SetCustomPropertyValue("CustomKey", "CustomValue");

            // Retrieve and display properties
            Console.WriteLine("Author: " + docProps.Author);
            Console.WriteLine("Title: " + docProps.Title);
            Console.WriteLine("Subject: " + docProps.Subject);

            // Retrieve and display the custom property
            string customValue;
            docProps.GetCustomPropertyValue("CustomKey", out customValue);
            Console.WriteLine("CustomKey: " + customValue);

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}