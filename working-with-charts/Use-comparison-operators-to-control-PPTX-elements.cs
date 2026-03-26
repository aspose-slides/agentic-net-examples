using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonDemo
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
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide in the presentation
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Use comparison operators to control slide visibility
                    // Hide even-numbered slides, show odd-numbered slides
                    if ((slide.SlideNumber % 2) == 0)
                    {
                        slide.Hidden = true;
                    }
                    else
                    {
                        slide.Hidden = false;
                    }

                    // Compare background type and modify if it is an own background
                    if (slide.Background.Type == Aspose.Slides.BackgroundType.OwnBackground)
                    {
                        // Change background to solid red
                        slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        slide.Background.FillFormat.SolidFillColor.Color = Color.Red;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}