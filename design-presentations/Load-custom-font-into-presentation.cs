using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadCustomFontExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the custom font file
                string fontPath = "customfont.ttf";

                // Load the custom font into Aspose.Slides font cache
                byte[] fontBytes = File.ReadAllBytes(fontPath);
                FontsLoader.LoadExternalFont(fontBytes);

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a new slide based on the layout of the first slide
                ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a rectangle shape to the slide
                IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle, 50, 50, 400, 100);

                // Add a text frame with sample text
                autoShape.AddTextFrame("Sample text with custom font");

                // Set the custom font for all portions in the text frame
                string customFontName = Path.GetFileNameWithoutExtension(fontPath);
                IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.LatinFont = new FontData(customFontName);
                }

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);

                // Clear the font cache
                FontsLoader.ClearCache();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}