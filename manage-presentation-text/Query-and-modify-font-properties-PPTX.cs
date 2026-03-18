using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation pres = new Presentation("input.pptx");

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Get the first shape as an AutoShape
                IAutoShape shape = slide.Shapes[0] as IAutoShape;

                // Access the text frame of the shape
                ITextFrame textFrame = shape.TextFrame;

                // Get the first paragraph and its first portion
                IParagraph paragraph = textFrame.Paragraphs[0];
                IPortion portion = paragraph.Portions[0];

                // Modify font properties
                portion.PortionFormat.LatinFont = new FontData("Arial");
                portion.PortionFormat.FontBold = NullableBool.True;
                portion.PortionFormat.FontItalic = NullableBool.True;
                portion.PortionFormat.FontHeight = 24f;
                portion.PortionFormat.FillFormat.FillType = FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Query effective font height (read‑only property)
                IPortionFormatEffectiveData effectivePortion = portion.PortionFormat.GetEffective();
                float effectiveHeight = effectivePortion.FontHeight;
                Console.WriteLine("Effective font height: " + effectiveHeight);

                // Save the modified presentation
                pres.Save("output.pptx", SaveFormat.Pptx);

                // Release resources
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}