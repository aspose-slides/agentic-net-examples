using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        try
        {
            // Load the presentation from the specified file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access document properties and modify the title
                Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;
                properties.Title = "Processed Presentation";

                // Save the modified presentation back to a PPTX file
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        // Catch more specific Aspose.Slides exceptions first
        catch (Aspose.Slides.PptxEditException editEx)
        {
            Console.WriteLine("Edit error: " + editEx.Message);
        }
        catch (Aspose.Slides.PptxReadException readEx)
        {
            Console.WriteLine("Read error: " + readEx.Message);
        }
        // General exception handler
        catch (Exception ex)
        {
            Console.WriteLine("General error: " + ex.Message);
        }
    }
}