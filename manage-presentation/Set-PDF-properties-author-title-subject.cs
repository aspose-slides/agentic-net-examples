using System;
using System.IO;
using Aspose.Slides;
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

            // Load existing presentation if it exists; otherwise create a new one
            Aspose.Slides.Presentation presentation;
            if (File.Exists(inputPath))
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                presentation = new Aspose.Slides.Presentation();
            }

            // Update built‑in document properties
            Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;
            properties.Author = "John Doe";
            properties.Title = "Sample Presentation";
            properties.Subject = "Demo of Document Properties";

            // Set default text language for the presentation
            presentation.DefaultTextStyle.DefaultParagraphFormat.DefaultPortionFormat.LanguageId = "en-US";

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)
        }
    }
}