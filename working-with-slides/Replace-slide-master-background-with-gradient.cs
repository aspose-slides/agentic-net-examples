using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceSlideMasterBackgroundWithGradient
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load existing presentation if it exists; otherwise create a new one
            Presentation pres;
            if (File.Exists(inputPath))
            {
                try
                {
                    pres = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported file format
                    // Format not supported
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                pres = new Presentation();
            }

            // Ensure there is at least one master slide
            if (pres.Masters.Count == 0)
            {
                // Add a default master slide by adding a new slide (which creates a master if none)
                ISlide tempSlide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            }

            // Replace background of the first master slide with a gradient using RGB colors
            pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
            pres.Masters[0].Background.FillFormat.FillType = FillType.Gradient;

            // Set gradient properties
            pres.Masters[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;
            pres.Masters[0].Background.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

            // Add gradient stops (red to blue)
            pres.Masters[0].Background.FillFormat.GradientFormat.GradientStops.Add(0f, Color.FromArgb(255, 0, 0));   // Red at start
            pres.Masters[0].Background.FillFormat.GradientFormat.GradientStops.Add(1f, Color.FromArgb(0, 0, 255));   // Blue at end

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}