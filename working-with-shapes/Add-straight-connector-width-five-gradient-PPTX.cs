using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a straight connector (line shape) to the slide
        Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

        // Set the line width to five points
        connector.LineFormat.Width = 5;

        // Apply a gradient fill to the connector line
        connector.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        connector.LineFormat.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Linear;
        connector.LineFormat.FillFormat.GradientFormat.GradientDirection = Aspose.Slides.GradientDirection.FromCorner2;

        // Define gradient stops (blue to red)
        connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(0, Aspose.Slides.PresetColor.Blue);
        connector.LineFormat.FillFormat.GradientFormat.GradientStops.Add(1, Aspose.Slides.PresetColor.Red);

        // Save the presentation
        string outputPath = "ConnectorGradient.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}