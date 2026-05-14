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

        Presentation presentation = null;
        try
        {
            if (File.Exists(inputPath))
            {
                presentation = new Presentation(inputPath);
            }
            else
            {
                presentation = new Presentation();
            }

            // Set custom slide size with EnsureFit scaling
            presentation.SlideSize.SetSize(800f, 600f, SlideSizeScaleType.EnsureFit);
            // Set slide size to A4 paper with Maximize scaling
            presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize);

            // Save the presentation as PPTX
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
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