using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyPresentationApp
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
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];
                    // Add a rectangle shape with text
                    slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100).TextFrame.Text = "Hello, Aspose!";

                    // Save the presentation to an in‑memory stream
                    using (MemoryStream outStream = new MemoryStream())
                    {
                        presentation.Save(outStream, SaveFormat.Pptx);
                        Console.WriteLine("Presentation saved to memory stream. Size: {0} bytes", outStream.Length);
                    }
                }
            }
            catch (Aspose.Slides.PptxException pptxEx)
            {
                Console.WriteLine("PPTX error: " + pptxEx.Message);
            }
            catch (Aspose.Slides.PptException pptEx)
            {
                Console.WriteLine("PPT error: " + pptEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }
        }
    }
}