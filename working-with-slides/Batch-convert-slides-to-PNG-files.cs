using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Convert each slide to a PNG file using a foreach loop
            int index = 0;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                using (Aspose.Slides.IImage image = slide.GetImage())
                {
                    string outputPath = string.Format("slide_{0}.png", index);
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
                index++;
            }

            // Save the (unchanged) presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}