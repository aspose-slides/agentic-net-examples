using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first master slide
                Aspose.Slides.IMasterSlide master = presentation.Masters[0];

                // Add a custom layout slide to the presentation
                Aspose.Slides.ILayoutSlide customLayout = presentation.LayoutSlides.Add(master, SlideLayoutType.Custom, "MyCustomLayout");

                // Apply the custom layout to the first slide
                presentation.Slides[0].LayoutSlide = customLayout;

                // Access the shape collection of the first slide
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add two shapes to connect
                Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 100, 100);
                Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 100, 100);

                // Add a connector shape
                Aspose.Slides.IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

                // Connect the shapes
                connector.StartShapeConnectedTo = ellipse;
                connector.EndShapeConnectedTo = rectangle;

                // Retrieve the effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveLineFormat = connector.LineFormat.GetEffective();

                // Output the effective line width
                Console.WriteLine("Effective line width: " + effectiveLineFormat.Width);

                // Save the presentation
                presentation.Save("ConnectorEffectiveLineWidth.pptx", SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}