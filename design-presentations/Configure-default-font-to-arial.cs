using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

namespace ConfigureDefaultFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to input and output files
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation with default regular font set to Arial
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.DefaultRegularFont = "Arial";

            Aspose.Slides.Presentation presentation = null;

            try
            {
                // Load the presentation using the load options
                presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

                // Add a new empty slide based on the first slide's layout
                Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a rectangle shape with a text frame; the text will use the default Arial font
                Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)newSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("This text uses the default Arial font.");

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is properly disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}