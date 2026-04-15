using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPath = "source.pptx";
        var destPath = "dest.pptx";
        var modifiedSourcePath = "source_modified.pptx";

        // Check if the source file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load source presentation
            using (var srcPres = new Presentation(inputPath))
            {
                // Create destination presentation
                using (var destPres = new Presentation())
                {
                    // Clone slide with its master to destination
                    var sourceSlide = srcPres.Slides[0];
                    var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
                    var destMaster = destPres.Masters.AddClone(sourceMaster);
                    destPres.Slides.AddClone(sourceSlide, destMaster, true);

                    // Save destination presentation
                    destPres.Save(destPath, SaveFormat.Pptx);
                }

                // Remove the original slide from source presentation
                var firstSlide = srcPres.Slides[0];
                srcPres.Slides.Remove(firstSlide);

                // Save modified source presentation
                srcPres.Save(modifiedSourcePath, SaveFormat.Pptx);
            }
        }
        // Handle format not supported (commented as per requirement)
        // catch (Aspose.Slides.Exceptions.UnsupportedFileFormatException) { /* format not supported */ }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}