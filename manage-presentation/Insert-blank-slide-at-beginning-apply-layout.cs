using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the master layout slide collection
                Aspose.Slides.IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;

                // Try to get a predefined layout (TitleAndObject, then Title, then Blank)
                Aspose.Slides.ILayoutSlide layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.TitleAndObject);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Title);
                }
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
                }

                // Insert a new empty slide at the beginning using the selected layout
                presentation.Slides.InsertEmptySlide(0, layoutSlide);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}