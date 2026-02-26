using System;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Modify built‑in properties (Author, Title, Subject, Comments)
        docProps.Author = "John Doe";
        docProps.Title = "Modified Presentation";
        docProps.Subject = "Demo";
        docProps.Comments = "Updated using Aspose.Slides";

        // Add new custom properties
        docProps["CustomInt"] = 123;
        docProps["CustomString"] = "Custom Value";

        // Modify existing custom properties
        for (int i = 0; i < docProps.CountOfCustomProperties; i++)
        {
            string propName = docProps.GetCustomPropertyName(i);
            object propValue = docProps[propName];

            // Example modification: increment integers, append index to strings
            if (propValue is int)
            {
                docProps[propName] = ((int)propValue) + (i + 1);
            }
            else if (propValue is string)
            {
                docProps[propName] = ((string)propValue) + (i + 1).ToString();
            }
        }

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}