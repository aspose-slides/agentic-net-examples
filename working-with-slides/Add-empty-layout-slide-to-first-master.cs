using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string inputFile = "input.pptx";
        string inputPath = Path.Combine(dataDir, inputFile);
        string outputFile = "output.pptx";
        string outputPath = Path.Combine(dataDir, outputFile);

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other loading errors
            Console.WriteLine("Error loading presentation (possible unsupported format): " + ex.Message);
            return;
        }

        // Get the first master slide
        Aspose.Slides.IMasterSlide firstMaster = pres.Masters[0];

        // Add a new empty layout slide to the first master
        Aspose.Slides.ILayoutSlide newLayout = firstMaster.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.Blank, "NewBlankLayout");

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}