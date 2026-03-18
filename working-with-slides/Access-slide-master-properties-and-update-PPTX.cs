using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output file paths
            string dataDir = "Data/";
            string inputPath = dataDir + "input.pptx";
            string outputPath = dataDir + "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first master slide using the Masters collection
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Change the background color of the master slide to ForestGreen
            masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}