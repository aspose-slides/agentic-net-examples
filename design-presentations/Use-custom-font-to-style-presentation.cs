using System;
using System.IO;
using Aspose.Slides.Export;

namespace CustomFontPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the folder containing custom fonts (e.g., .ttf files)
                string fontsFolder = Path.Combine(Directory.GetCurrentDirectory(), "CustomFonts");
                // Load all fonts from the specified folder
                Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontsFolder });

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first (default) slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to the slide
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 100, 500, 100);

                // Add a text frame with sample text
                autoShape.AddTextFrame("This text uses a custom font.");

                // Apply the custom font to all portions in the text frame
                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                {
                    // Replace "CustomFontName" with the actual font name (without file extension)
                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFontName");
                }

                // Save the presentation before exiting
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CustomFontPresentation.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                // Clear the loaded custom fonts from the cache
                Aspose.Slides.FontsLoader.ClearCache();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}