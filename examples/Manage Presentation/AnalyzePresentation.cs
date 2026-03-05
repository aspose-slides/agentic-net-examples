using System;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access built‑in document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
        Console.WriteLine("Author: " + docProps.Author);
        Console.WriteLine("Title: " + docProps.Title);
        Console.WriteLine("Subject: " + docProps.Subject);
        Console.WriteLine("Created: " + docProps.CreatedTime);

        // Modify custom properties (example: append index to string values)
        for (int i = 0; i < docProps.CountOfCustomProperties; i++)
        {
            string propName = docProps.GetCustomPropertyName(i);
            object propValue = docProps[propName];

            if (propValue is string)
            {
                docProps[propName] = ((string)propValue) + (i + 1);
            }
            else if (propValue is int)
            {
                docProps[propName] = ((int)propValue) + (i + 1);
            }
        }

        // Get file format information using PresentationFactory
        Aspose.Slides.IPresentationInfo info = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
        Aspose.Slides.LoadFormat loadFormat = info.LoadFormat;
        Console.WriteLine("Load format: " + loadFormat);

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}