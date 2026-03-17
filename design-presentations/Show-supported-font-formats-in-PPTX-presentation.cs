using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // List of supported font formats
            string[] fontFormats = new string[] { "TrueType", "OpenType", "Embedded OpenType", "PostScript", "Bitmap" };

            // Iterate over each format and create a slide
            for (int i = 0; i < fontFormats.Length; i++)
            {
                ISlide slide;
                if (i == 0)
                {
                    // Use the default first slide
                    slide = pres.Slides[0];
                }
                else
                {
                    // Add a new empty slide based on the layout of the first slide
                    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
                }

                // Add a title shape
                IAutoShape titleShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 600, 50);
                titleShape.TextFrame.Text = fontFormats[i] + " Font Format";
                titleShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
                titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
                titleShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontBold = NullableBool.True;

                // Add a description shape
                IAutoShape descShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 80, 600, 300);
                descShape.TextFrame.Text = GetDescriptionForFormat(fontFormats[i]);
                descShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 18;
            }

            // Save the presentation before exiting
            pres.Save("SupportedFontFormats.pptx", SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Helper method to provide usage guidelines for each font format
    static string GetDescriptionForFormat(string format)
    {
        switch (format)
        {
            case "TrueType":
                return "TrueType fonts are widely supported and allow embedding.";
            case "OpenType":
                return "OpenType fonts support advanced typographic features.";
            case "Embedded OpenType":
                return "Embedded OpenType fonts are stored within the presentation.";
            case "PostScript":
                return "PostScript fonts are used for high-quality printing.";
            case "Bitmap":
                return "Bitmap fonts are raster images of characters.";
            default:
                return "Unknown font format.";
        }
    }
}