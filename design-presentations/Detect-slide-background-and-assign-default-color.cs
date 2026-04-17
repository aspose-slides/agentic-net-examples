using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideBackgroundUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    // Get effective background data
                    IBackgroundEffectiveData effective = presentation.Slides[i].Background.GetEffective();

                    // If the effective fill type is not solid, set a default solid color
                    if (effective.FillFormat.FillType != FillType.Solid)
                    {
                        // Set own background
                        presentation.Slides[i].Background.Type = BackgroundType.OwnBackground;
                        presentation.Slides[i].Background.FillFormat.FillType = FillType.Solid;

                        // Choose a color based on slide index
                        Color slideColor;
                        switch (i % 5)
                        {
                            case 0:
                                slideColor = Color.LightBlue;
                                break;
                            case 1:
                                slideColor = Color.LightGreen;
                                break;
                            case 2:
                                slideColor = Color.LightCoral;
                                break;
                            case 3:
                                slideColor = Color.LightGoldenrodYellow;
                                break;
                            default:
                                slideColor = Color.LightGray;
                                break;
                        }

                        // Apply the color
                        presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = slideColor;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error processing presentation: " + ex.Message);
            }
        }
    }
}