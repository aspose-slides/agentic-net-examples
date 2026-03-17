using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontStylingExample
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

                // Add a rectangle shape with text
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Styled Text Example");

                // Apply font styling to the text
                IPortion portion = shape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.FontHeight = 24;
                portion.PortionFormat.FontBold = NullableBool.True;
                portion.PortionFormat.FontItalic = NullableBool.False;
                portion.PortionFormat.FontUnderline = TextUnderlineType.None;

                // Set default regular font for the presentation using PptOptions
                PptOptions saveOptions = new PptOptions();
                saveOptions.DefaultRegularFont = "Arial";

                // Save the presentation in PPT format
                presentation.Save("StyledPresentation.ppt", SaveFormat.Ppt, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}