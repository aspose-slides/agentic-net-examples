using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPptx = "output.pptx";
        string outputPng = "slide.png";

        // Load existing presentation if it exists; otherwise create a new one
        Aspose.Slides.Presentation pres;
        if (File.Exists(inputPath))
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        else
        {
            pres = new Aspose.Slides.Presentation();
        }

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram and set its layout to Horizontal Organization Chart
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.HorizontalOrganizationChart;

        // Save the modified presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

        // Export the first slide as a PNG image
        using (Aspose.Slides.IImage image = slide.GetImage())
        {
            image.Save(outputPng, Aspose.Slides.ImageFormat.Png);
        }

        // Clean up resources
        pres.Dispose();
    }
}