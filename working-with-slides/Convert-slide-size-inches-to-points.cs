using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSizeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                // Custom slide size in inches
                float widthInches = 10.0f;
                float heightInches = 7.5f;

                // Convert inches to points (1 inch = 72 points)
                float widthPoints = widthInches * 72f;
                float heightPoints = heightInches * 72f;

                // Set slide size with scaling to ensure content fits
                presentation.SlideSize.SetSize(widthPoints, heightPoints, SlideSizeScaleType.EnsureFit);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
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
}