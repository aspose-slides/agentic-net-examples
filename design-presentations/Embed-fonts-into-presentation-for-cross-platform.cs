using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output_embedded.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape and a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);
            autoShape.AddTextFrame("Sample text with custom font.");

            // Embed all fonts used in the presentation
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData fontData in allFonts)
            {
                bool isEmbedded = false;
                foreach (Aspose.Slides.IFontData ef in embeddedFonts)
                {
                    if (ef.Equals(fontData))
                    {
                        isEmbedded = true;
                        break;
                    }
                }
                if (!isEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(fontData, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}