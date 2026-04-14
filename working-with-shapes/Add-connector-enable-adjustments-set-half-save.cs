using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a bent connector shape
            Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(
                Aspose.Slides.ShapeType.BentConnector2, 100, 100, 200, 0);

            // Enable adjustment handles (unlock them)
            connector.ConnectorLock.AdjustHandlesLocked = false;

            // Set both adjustment values to 0.5 (if they exist)
            if (connector.Adjustments.Count > 0)
            {
                Aspose.Slides.IAdjustValue adjust0 = (Aspose.Slides.IAdjustValue)connector.Adjustments[0];
                adjust0.AngleValue = 0.5f;
            }
            if (connector.Adjustments.Count > 1)
            {
                Aspose.Slides.IAdjustValue adjust1 = (Aspose.Slides.IAdjustValue)connector.Adjustments[1];
                adjust1.AngleValue = 0.5f;
            }

            // Save the presentation
            try
            {
                presentation.Save("ConnectorAdjustment.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}