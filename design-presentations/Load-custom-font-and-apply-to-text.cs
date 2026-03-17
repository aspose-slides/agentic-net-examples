using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load custom fonts from a folder
                string[] fontFolders = new string[] { "C:\\CustomFonts" };
                Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape with text
                    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 400, 100);
                    shape.AddTextFrame("Hello with custom font");

                    // Apply the custom font to the text
                    IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
                    portion.PortionFormat.LatinFont = new FontData("MyCustomFont");
                    portion.PortionFormat.FontHeight = 24;

                    // Save the presentation
                    presentation.Save("CustomFontPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}