using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Load custom font from file into Aspose.Slides font cache
            string fontPath = "customfonts/CustomFont.ttf";
            byte[] fontData = System.IO.File.ReadAllBytes(fontPath);
            Aspose.Slides.FontsLoader.LoadExternalFont(fontData);

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle shape to hold text
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Add a text frame with sample text
                Aspose.Slides.ITextFrame tf = shape.TextFrame;
                tf.Text = "Sample text with custom font";

                // Apply custom font and styling to the text portion
                Aspose.Slides.IPortion portion = tf.Paragraphs[0].Portions[0];
                portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");
                portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                portion.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
                portion.PortionFormat.FontHeight = 24f;
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Save the presentation
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
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