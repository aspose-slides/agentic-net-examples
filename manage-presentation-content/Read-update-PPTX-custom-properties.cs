using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access document properties
            Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;

            // Update or add a custom property named "CustomProp"
            if (properties.ContainsCustomProperty("CustomProp"))
            {
                // Update existing custom property
                properties.SetCustomPropertyValue("CustomProp", "UpdatedValue");
            }
            else
            {
                // Add new custom property
                properties.SetCustomPropertyValue("CustomProp", "InitialValue");
            }

            // Save the presentation with updated properties
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}