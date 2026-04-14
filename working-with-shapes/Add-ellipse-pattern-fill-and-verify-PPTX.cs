using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AddEllipsePatternFill
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add an ellipse shape
                    IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

                    // Set fill to a diagonal line pattern
                    ellipse.FillFormat.FillType = FillType.Pattern;
                    ellipse.FillFormat.PatternFormat.PatternStyle = PatternStyle.DiagonalCross;
                    ellipse.FillFormat.PatternFormat.ForeColor.Color = Color.Black;
                    ellipse.FillFormat.PatternFormat.BackColor.Color = Color.White;

                    // Verify rendering by saving the slide as an image
                    using (IImage slideImage = slide.GetImage(1f, 1f))
                    {
                        slideImage.Save("RenderedSlide.png", Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation
                    presentation.Save("EllipsePatternPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, rendering errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}