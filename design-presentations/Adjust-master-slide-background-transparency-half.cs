using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
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
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first master slide
                IMasterSlide masterSlide = presentation.Masters[0];

                // Set the background to use its own fill
                masterSlide.Background.Type = BackgroundType.OwnBackground;

                // Use a solid fill with 50% transparency (alpha = 128)
                masterSlide.Background.FillFormat.FillType = FillType.Solid;
                masterSlide.Background.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 255, 255, 255);

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions (e.g., network errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}