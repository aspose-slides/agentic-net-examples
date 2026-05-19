using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other loading errors
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Iterate through slides and SmartArt shapes
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    Aspose.Slides.SmartArt.SmartArtLayoutType layout = smartArt.Layout;
                    int nodeCount = smartArt.AllNodes.Count;
                    Console.WriteLine(string.Format("Slide {0}: SmartArt Layout = {1}, Node Count = {2}", slideIndex + 1, layout, nodeCount));
                }
            }
        }

        try
        {
            // Save the presentation before exit
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}