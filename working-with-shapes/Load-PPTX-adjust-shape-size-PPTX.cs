using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation from a file
                Presentation presentation = new Presentation("input.pptx");

                // Locate the shape by its alternative text
                IShape shape = SlideUtil.FindShape(presentation, "TargetShape");

                // Cast to AutoShape to modify dimensions
                IAutoShape autoShape = shape as IAutoShape;
                if (autoShape != null)
                {
                    // Adjust width and height (points)
                    autoShape.Width = 400f;
                    autoShape.Height = 300f;
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