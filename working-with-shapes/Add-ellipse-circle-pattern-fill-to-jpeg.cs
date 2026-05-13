using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            IShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

            // Apply pattern fill (small circles)
            ellipse.FillFormat.FillType = FillType.Pattern;
            ellipse.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallConfetti; // small circles pattern
            ellipse.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.White;
            ellipse.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.Black;

            // Save the presentation (handle unsupported format)
            string presentationPath = Path.Combine(outputDir, "EllipsePattern.pptx");
            try
            {
                presentation.Save(presentationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Export the slide as JPEG
            float scaleX = 1f;
            float scaleY = 1f;
            using (IImage slideImage = slide.GetImage(scaleX, scaleY))
            {
                string jpegPath = Path.Combine(outputDir, "Slide1.jpg");
                slideImage.Save(jpegPath, ImageFormat.Jpeg);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}