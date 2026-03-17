using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Specify folders containing custom fonts
                string[] fontFolders = new string[] { "C:\\CustomFonts" };
                // Load custom fonts before creating any presentation objects
                Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape to hold text
                    Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                    // Add a text frame with sample text
                    Aspose.Slides.ITextFrame textFrame = ((Aspose.Slides.IAutoShape)shape).AddTextFrame(
                        "Sample text with custom font");

                    // Apply the custom font to the first portion of the first paragraph
                    textFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("MyCustomFont");

                    // Save the presentation
                    presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}