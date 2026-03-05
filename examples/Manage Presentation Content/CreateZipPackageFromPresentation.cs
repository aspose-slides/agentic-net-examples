using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide (the presentation is created with one empty slide)
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Configure PPTX save options to use ZIP64 format
        Aspose.Slides.Export.PptxOptions pptxOptions = new Aspose.Slides.Export.PptxOptions();
        pptxOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always;

        // Define output file path
        string outputPath = "output.pptx";

        // Save the presentation as PPTX with ZIP64 options
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
    }
}