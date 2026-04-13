using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MultilingualPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle AutoShape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

                // Add an empty TextFrame to the shape
                shape.AddTextFrame("");

                // Access the first paragraph
                Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];
                // Clear any default portions
                paragraph.Portions.Clear();

                // English portion
                Aspose.Slides.IPortion englishPortion = new Aspose.Slides.Portion("Hello ");
                englishPortion.PortionFormat.LanguageId = "en-US";
                paragraph.Portions.Add(englishPortion);

                // French portion
                Aspose.Slides.IPortion frenchPortion = new Aspose.Slides.Portion("Bonjour ");
                frenchPortion.PortionFormat.LanguageId = "fr-FR";
                paragraph.Portions.Add(frenchPortion);

                // Japanese portion
                Aspose.Slides.IPortion japanesePortion = new Aspose.Slides.Portion("こんにちは ");
                japanesePortion.PortionFormat.LanguageId = "ja-JP";
                paragraph.Portions.Add(japanesePortion);

                // Save the presentation as PPTX
                string outputPath = "MultilingualPresentation.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported: comment placeholder
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}