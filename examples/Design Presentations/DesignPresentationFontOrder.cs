using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontSelectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape that will contain text
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                autoShape.TextFrame.Text = "Sample text with default fonts";

                // Retrieve fonts used in the presentation
                Aspose.Slides.IFontData[] usedFonts = presentation.FontsManager.GetFonts();

                // List the fonts in the console
                foreach (Aspose.Slides.IFontData font in usedFonts)
                {
                    Console.WriteLine("Font used: " + font.FontName);
                }

                // Replace a specific font (e.g., Arial) with another (e.g., Calibri)
                Aspose.Slides.IFontData sourceFont = new Aspose.Slides.FontData("Arial");
                Aspose.Slides.IFontData destinationFont = new Aspose.Slides.FontData("Calibri");
                presentation.FontsManager.ReplaceFont(sourceFont, destinationFont);

                // Save the presentation
                presentation.Save("FontSelectionDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}