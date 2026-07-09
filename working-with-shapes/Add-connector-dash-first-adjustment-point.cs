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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bent connector to the slide
            Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
                Aspose.Slides.ShapeType.BentConnector2, 100, 100, 200, 0);

            // Apply a dashed line style to the connector
            connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.Dash;

            // Adjust the first adjustment point of the connector
            Aspose.Slides.IAdjustValue firstAdjustment = connector.Adjustments[0];
            firstAdjustment.RawValue = 5000; // Example raw value

            // Save the presentation
            presentation.Save("ConnectorDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}