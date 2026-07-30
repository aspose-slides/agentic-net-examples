// -----------------------------------------------------------------------------
// Example: Validate picture frame AspectRatioLocked consistency using C#
//
// Description:
// Demonstrates how to iterate through all slides and picture frames in a PPTX
// file to verify that the ShapeLock.AspectRatioLocked property is consistent
// across the entire presentation. The example loads a presentation, checks the
// setting, reports the result, and saves the file using Aspose.Slides for .NET.
// This pattern helps developers enforce uniform picture frame lock settings in
// automated PowerPoint processing.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, PictureFrame, AspectRatioLocked, ShapeLock,
// Presentation Validation, Office Automation
//
// Use Cases:
// - Verify that all picture frames share the same AspectRatioLocked value.
// - Build validation tools for PowerPoint presentations in .NET.
// - Enforce consistent picture frame lock settings before publishing.
// - Integrate picture frame consistency checks into automated PPTX workflows.
// -----------------------------------------------------------------------------
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
