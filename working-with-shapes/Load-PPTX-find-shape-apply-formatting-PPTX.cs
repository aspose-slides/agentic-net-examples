using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Set load options with default font
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions))
            {
                // Find the shape by its alternative text
                Aspose.Slides.IShape shape = Aspose.Slides.Util.SlideUtil.FindShape(presentation, "TargetShapeAltText");
                if (shape != null)
                {
                    // Cast to AutoShape to modify properties
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null)
                    {
                        // Change fill to solid blue
                        autoShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        autoShape.FillFormat.SolidFillColor.Color = Color.Blue;

                        // Ensure a text frame exists
                        if (autoShape.TextFrame == null)
                        {
                            autoShape.AddTextFrame("Sample Text");
                        }

                        // Modify text formatting
                        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];
                        Aspose.Slides.IPortion portion = paragraph.Portions[0];
                        portion.PortionFormat.FontHeight = 24;
                        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
                    }
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