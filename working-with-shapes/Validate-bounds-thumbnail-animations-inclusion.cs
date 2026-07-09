using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            using (Presentation presentation = new Presentation(inputPath))
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Generate animation frames and save them as images
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    int frameIndex = 0;
                    using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                    {
                        player.FrameTick += (sender, args) =>
                        {
                            string framePath = Path.Combine(outputDir, $"frame_{frameIndex}.png");
                            args.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                            frameIndex++;
                        };

                        animationsGenerator.Run(presentation.Slides);
                    }
                }

                // Generate bounds‑based thumbnails for each shape on each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    for (int j = 0; j < slide.Shapes.Count; j++)
                    {
                        IShape shape = slide.Shapes[j];
                        using (IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Appearance, 1f, 1f))
                        {
                            string shapePath = Path.Combine(outputDir, $"slide_{i}_shape_{j}.png");
                            shapeImage.Save(shapePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }
                }

                // Save the (potentially modified) presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Net.WebException)
        {
            // Handle external URL/web service exception
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}