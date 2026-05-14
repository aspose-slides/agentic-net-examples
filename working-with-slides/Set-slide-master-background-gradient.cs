using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetMasterBackgroundGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

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

                // Access the first master slide
                Aspose.Slides.IMasterSlide masterSlide = pres.Masters[0];

                // Set the background to use a gradient fill
                masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Gradient;

                // Configure gradient properties
                Aspose.Slides.IGradientFormat gradientFormat = masterSlide.Background.FillFormat.GradientFormat;
                gradientFormat.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

                // Add gradient stops with RGB colors
                gradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));   // Red at start
                gradientFormat.GradientStops.Add(1, Color.FromArgb(0, 0, 255));   // Blue at end

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxReadException)
            {
                // Handle unsupported file format
                Console.WriteLine("File format not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}