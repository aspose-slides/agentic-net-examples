using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access document properties
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                // Add custom properties
                docProps.SetCustomPropertyValue("CustomString", "Hello World");
                docProps.SetCustomPropertyValue("CustomNumber", 123);
                docProps.SetCustomPropertyValue("CustomDate", DateTime.Now);

                // Save the presentation with the new custom properties
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}