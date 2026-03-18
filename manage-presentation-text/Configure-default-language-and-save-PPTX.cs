using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Set default text language via LoadOptions
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultTextLanguage = "en-US";

            // Create a new presentation with the specified load options
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(loadOptions);

            // Add a rectangle shape with a text frame to demonstrate the language setting
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 100);
            shape.AddTextFrame("Sample text");

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}