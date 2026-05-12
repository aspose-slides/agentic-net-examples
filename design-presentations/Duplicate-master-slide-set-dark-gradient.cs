using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
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
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Get the first master slide
                Aspose.Slides.IMasterSlide sourceMaster = pres.Masters[0];

                // Clone the master slide and insert at the end of the masters collection
                Aspose.Slides.IMasterSlide clonedMaster = pres.Masters.InsertClone(pres.Masters.Count, sourceMaster);

                // Modify the cloned master background to a dark gradient
                clonedMaster.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                clonedMaster.Background.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                clonedMaster.Background.FillFormat.GradientFormat.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}