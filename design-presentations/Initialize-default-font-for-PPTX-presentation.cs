using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "DefaultFontPresentation.pptx";

        // Set default regular font for the presentation
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DefaultRegularFont = "Arial";

        Aspose.Slides.Presentation pres = null;
        try
        {
            // Create a new presentation with the specified load options
            pres = new Aspose.Slides.Presentation(loadOptions);

            // Add a rectangle shape with a text frame to verify the default font
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample text with default font");

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Ensure resources are released
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}