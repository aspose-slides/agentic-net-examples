using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "source.pptx";
        string outputPath = "cloned.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load source presentation
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(inputPath);
            // Create destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Get the first slide and its master from the source
            Aspose.Slides.ISlide sourceSlide = srcPres.Slides[0];
            Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

            // Clone the master slide into the destination presentation
            Aspose.Slides.IMasterSlide destMaster = destPres.Masters.AddClone(sourceMaster);

            // Clone the slide into the destination, preserving animations
            destPres.Slides.AddClone(sourceSlide, destMaster, true);

            // Save the destination presentation
            destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            srcPres.Dispose();
            destPres.Dispose();
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (System.Net.WebException ex)
        {
            // Handle external URL or web service errors
            Console.WriteLine("Web exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}