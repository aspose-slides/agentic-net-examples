using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedCustomFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the custom TrueType font file
            string fontPath = "customfont.ttf";
            // Path to the output presentation
            string outputPath = "EmbeddedFontPresentation.pptx";

            try
            {
                // Load the custom font data into memory
                byte[] fontBytes = File.ReadAllBytes(fontPath);
                // Register the custom font with Aspose.Slides (must be done before creating a Presentation)
                FontsLoader.LoadExternalFont(fontBytes);

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Embed the custom font into the presentation (embed all characters)
                presentation.FontsManager.AddEmbeddedFont(fontBytes, EmbedFontCharacters.All);

                // Optional: add a slide with a text frame using the custom font
                ISlide slide = presentation.Slides[0];
                IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 600, 100);
                autoShape.AddTextFrame("Sample text using the embedded custom font.");
                // Set the font for the text portion
                string customFontName = Path.GetFileNameWithoutExtension(fontPath);
                autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData(customFontName);

                // Save the presentation (using fully qualified SaveFormat)
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}