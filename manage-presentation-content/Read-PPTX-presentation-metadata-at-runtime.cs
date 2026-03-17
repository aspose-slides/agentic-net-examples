using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Read built-in properties
            Console.WriteLine("Author: " + docProps.Author);
            Console.WriteLine("Title: " + docProps.Title);
            Console.WriteLine("Created: " + docProps.CreatedTime);

            // Update built-in properties
            docProps.Author = "John Doe";
            docProps.Title = "Metadata Example";
            docProps.Subject = "Demonstrating property manipulation";

            // Add custom properties
            docProps.SetCustomPropertyValue("Project", "Aspose Slides");
            docProps.SetCustomPropertyValue("Version", 1);

            // Remove a specific custom property if it exists
            if (docProps.ContainsCustomProperty("Version"))
            {
                docProps.RemoveCustomProperty("Version");
            }

            // Clear all custom properties
            docProps.ClearCustomProperties();

            // Save the presentation
            presentation.Save("MetadataDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}