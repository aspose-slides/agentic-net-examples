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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                // Add a connector shape using default template styling
                Aspose.Slides.IConnector connector = slide.Shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 100, 0);
                // Retrieve effective line format data
                Aspose.Slides.ILineFormatEffectiveData effectiveData = connector.LineFormat.GetEffective();
                double effectiveWidth = effectiveData.Width;
                Console.WriteLine("Effective line width: " + effectiveWidth);
                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, indicate it
                Console.WriteLine("An error occurred (possible unsupported format): " + ex.Message);
            }
        }
    }
}