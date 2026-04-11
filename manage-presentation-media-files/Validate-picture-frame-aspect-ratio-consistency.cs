using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            // format not supported
            return;
        }

        // Validate AspectRatioLocked consistency across all picture frames
        bool? firstValue = null;
        bool consistent = true;

        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            ISlide slide = pres.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];
                IPictureFrame pictureFrame = shape as IPictureFrame;
                if (pictureFrame != null)
                {
                    bool current = pictureFrame.ShapeLock.AspectRatioLocked;
                    if (firstValue == null)
                    {
                        firstValue = current;
                    }
                    else if (firstValue.Value != current)
                    {
                        consistent = false;
                        break;
                    }
                }
            }
            if (!consistent)
                break;
        }

        if (consistent)
        {
            Console.WriteLine("All picture frames have consistent AspectRatioLocked setting.");
        }
        else
        {
            Console.WriteLine("Inconsistent AspectRatioLocked settings found among picture frames.");
        }

        // Save the presentation before exit
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}