using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ImportTtfFontAndApply
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths (adjust as needed)
            string dataDir = @"C:\Data\";
            string fontPath = Path.Combine(dataDir, "CustomFont.ttf");
            string outputPath = Path.Combine(dataDir, "OutputPresentation.pptx");

            try
            {
                // Load external TrueType font before creating the presentation
                byte[] fontBytes = File.ReadAllBytes(fontPath);
                Aspose.Slides.FontsLoader.LoadExternalFont(fontBytes);

                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first (default) slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle shape with a text frame
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Sample text using custom font");

                // Apply the imported font to all portions in the text frame
                Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                {
                    // Use FontData to reference the imported font by name
                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Clear loaded fonts from cache
                Aspose.Slides.FontsLoader.ClearCache();
            }
        }
    }
}