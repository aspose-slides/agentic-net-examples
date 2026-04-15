using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace RectangleDashStyleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "RectangleDashStyleDemo.pptx");

            // Ensure the directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            ISlide slide = presentation.Slides[0];
            IShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

            // Set initial line dash style to Solid
            rectangle.LineFormat.DashStyle = LineDashStyle.Solid;

            // Add a click-triggered animation effect (Fade) to the rectangle
            // This represents the user interaction event
            IEffect clickEffect = slide.Timeline.MainSequence.AddEffect(
                rectangle,
                EffectType.Fade,
                EffectSubtype.None,
                EffectTriggerType.OnClick);

            // After the click effect, change the line dash style to DashDot
            rectangle.LineFormat.DashStyle = LineDashStyle.DashDot;

            try
            {
                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation
                presentation.Dispose();
            }
        }
    }
}