using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide and its first shape (assumed to be an AutoShape with a text frame)
            Aspose.Slides.IShape shape = presentation.Slides[0].Shapes[0];
            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

            if (autoShape != null && autoShape.TextFrame != null)
            {
                // Iterate through all paragraphs and portions
                foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                {
                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                    {
                        // Apply superscript if the portion text contains "sup"
                        if (portion.Text.Contains("sup"))
                        {
                            portion.PortionFormat.Escapement = 100f; // superscript
                        }
                        // Apply subscript if the portion text contains "sub"
                        else if (portion.Text.Contains("sub"))
                        {
                            portion.PortionFormat.Escapement = -100f; // subscript
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}