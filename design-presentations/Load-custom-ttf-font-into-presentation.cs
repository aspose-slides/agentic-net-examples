using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadCustomTtfFont
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the custom TrueType font file
                string fontPath = "customfont.ttf";

                // Load the font bytes and register the font with Aspose.Slides
                byte[] fontBytes = File.ReadAllBytes(fontPath);
                Aspose.Slides.FontsLoader.LoadExternalFont(fontBytes);

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide (created by default)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape with a text frame
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("Sample text using custom font");

                // Set the custom font for all portions in the text frame
                string customFontName = Path.GetFileNameWithoutExtension(fontPath);
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData(customFontName);
                }

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
                Aspose.Slides.FontsLoader.ClearCache();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}