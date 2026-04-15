using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string sourcePath = "source.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        Presentation srcPres = null;
        Presentation destPres = null;

        try
        {
            srcPres = new Presentation(sourcePath);
        }
        catch (Exception)
        {
            // Format not supported
            Console.WriteLine("Failed to load source presentation. Format may not be supported.");
            return;
        }

        try
        {
            destPres = new Presentation();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to create destination presentation: " + ex.Message);
            return;
        }

        // Clone the first slide from source to destination at position 0
        destPres.Slides.InsertClone(0, srcPres.Slides[0]);

        // Adjust destination slide size to match source slide size
        System.Drawing.SizeF srcSize = srcPres.SlideSize.Size;
        destPres.SlideSize.SetSize(srcSize.Width, srcSize.Height, SlideSizeScaleType.EnsureFit);

        // Save the destination presentation
        try
        {
            destPres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up
        srcPres.Dispose();
        destPres.Dispose();
    }
}