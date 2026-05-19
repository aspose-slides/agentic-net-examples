using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Find the first SmartArt shape on the slide
                Aspose.Slides.IShape smartArtShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        smartArtShape = shape;
                        break;
                    }
                }

                if (smartArtShape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                {
                    // Remove the second root node if it exists
                    if (smartArt.Nodes.Count > 1)
                    {
                        smartArt.Nodes.RemoveNode(1);
                    }
                }
                else
                {
                    Console.WriteLine("No SmartArt found on the first slide.");
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}