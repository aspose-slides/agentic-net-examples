using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Hide the slide during a slide show
                slide.Hidden = true;

                // Set the slide background color to LightBlue
                slide.Background.Type = BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

                // Add a rectangle shape with text
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 400, 200);
                shape.TextFrame.Text = "Hello Aspose.Slides!";
                shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.Yellow;

                // Update document properties
                presentation.DocumentProperties.Title = "Modified Presentation";
                presentation.DocumentProperties.Author = "Aspose.Slides Example";

                // Save the presentation
                presentation.Save("ModifiedPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}