using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find the first shape that contains a text frame
                Aspose.Slides.IAutoShape shape = slide.Shapes[0] as Aspose.Slides.IAutoShape;
                if (shape != null && shape.TextFrame != null)
                {
                    // Get the first paragraph in the text frame
                    Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

                    // Create a new portion with the desired text
                    Aspose.Slides.IPortion newPortion = new Aspose.Slides.Portion("Inserted");

                    // Apply bold formatting
                    newPortion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

                    // Apply red color formatting
                    newPortion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    newPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

                    // Insert the new portion at the desired position (e.g., after the first existing portion)
                    paragraph.Portions.Insert(1, newPortion);
                }

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}