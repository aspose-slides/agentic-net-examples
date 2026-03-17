using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load custom fonts from a folder (ensure the folder exists and contains .ttf files)
            string[] fontFolders = new string[] { "customfonts" };
            Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first (default) slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape that will contain text
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Cast to IAutoShape to access text frame
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                autoShape.AddTextFrame("Sample text with custom font");

                // Replace a source font (e.g., Arial) with the custom font throughout the presentation
                Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
                Aspose.Slides.IFontData destFont = new Aspose.Slides.FontData("CustomFontName");
                presentation.FontsManager.ReplaceFont(sourceFont, destFont);

                // Set save options to use the custom font as the default regular font
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.DefaultRegularFont = "CustomFontName";

                // Save the presentation
                presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }

            // Clear the font cache after processing
            Aspose.Slides.FontsLoader.ClearCache();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}