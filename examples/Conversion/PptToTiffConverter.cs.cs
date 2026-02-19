using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPptPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.ppt");
        string inputPptxPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample.pptx");
        string outputTiffFromPpt = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample_from_ppt.tiff");
        string outputTiffFromPptx = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "sample_from_pptx.tiff");

        // Convert PPT to TIFF
        Aspose.Slides.Presentation presPpt = new Aspose.Slides.Presentation(inputPptPath);
        Aspose.Slides.Export.TiffOptions tiffOptionsPpt = new Aspose.Slides.Export.TiffOptions();
        tiffOptionsPpt.DpiX = 300;
        tiffOptionsPpt.DpiY = 300;
        presPpt.Save(outputTiffFromPpt, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptionsPpt);
        presPpt.Dispose();

        // Convert PPTX to TIFF
        Aspose.Slides.Presentation presPptx = new Aspose.Slides.Presentation(inputPptxPath);
        Aspose.Slides.Export.TiffOptions tiffOptionsPptx = new Aspose.Slides.Export.TiffOptions();
        tiffOptionsPptx.DpiX = 300;
        tiffOptionsPptx.DpiY = 300;
        presPptx.Save(outputTiffFromPptx, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptionsPptx);
        presPptx.Dispose();
    }
}