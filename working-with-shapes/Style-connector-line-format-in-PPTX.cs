using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesConnectorStyling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the existing presentation
                var presentation = new Presentation("input.pptx");

                // Get the first slide
                var slide = presentation.Slides[0];

                // Assume the first shape is a connector; cast it to IConnector
                var connector = slide.Shapes[0] as IConnector;
                if (connector != null)
                {
                    // Set line width
                    connector.LineFormat.Width = 5.0f;

                    // Set line dash style
                    connector.LineFormat.DashStyle = LineDashStyle.Dash;

                    // Set solid line fill color using a scheme color
                    connector.LineFormat.FillFormat.FillType = FillType.Solid;
                    connector.LineFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}