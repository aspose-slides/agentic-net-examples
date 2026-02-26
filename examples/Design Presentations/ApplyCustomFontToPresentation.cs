using System;

namespace AsposeSlidesCustomFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder that contains custom font files (e.g., .ttf)
            string fontsFolder = @"C:\CustomFonts";

            // Load custom fonts before creating any presentation objects
            Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontsFolder });

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape to the slide
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Add a TextFrame with sample text
                Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("Hello with custom font");

                // Set the custom font for the first portion of the text
                Aspose.Slides.IPortion portion = textFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("MyCustomFont");

                // Save the presentation
                presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Clear the font cache after processing
            Aspose.Slides.FontsLoader.ClearCache();
        }
    }
}