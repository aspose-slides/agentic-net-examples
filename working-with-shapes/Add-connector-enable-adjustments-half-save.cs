using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a bent connector to the slide
                IConnector connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 100, 100, 200, 0);

                // Enable adjustment handles
                connector.ConnectorLock.AdjustHandlesLocked = false;

                // Set both adjustment values to 0.5
                // Adjustments collection is read‑only, but each adjustment object can be modified
                if (connector.Adjustments.Count > 0)
                {
                    connector.Adjustments[0].AngleValue = 0.5f;
                }
                if (connector.Adjustments.Count > 1)
                {
                    connector.Adjustments[1].AngleValue = 0.5f;
                }

                // Save the presentation
                presentation.Save("ConnectorExample.pptx", SaveFormat.Pptx);
            }
        }
    }
}