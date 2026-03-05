using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationContentInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the directory containing the presentation files
            string dataDir = @"C:\PresentationData";

            // Ensure the directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Input PPT file path
            string inputPath = Path.Combine(dataDir, "input.ppt");

            // Get presentation information without loading the full presentation
            Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);
            Aspose.Slides.LoadFormat loadFormat = presentationInfo.LoadFormat;
            Console.WriteLine("Presentation load format: " + loadFormat);

            // Load the presentation for editing
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape to the slide
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 100);

            // Add a TextFrame to the AutoShape (cast to IAutoShape to access AddTextFrame)
            autoShape.AddTextFrame("Hello Aspose.Slides!");

            // Save the modified presentation in PPT format
            string outputPath = Path.Combine(dataDir, "output.ppt");
            presentation.Save(outputPath, SaveFormat.Ppt);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}