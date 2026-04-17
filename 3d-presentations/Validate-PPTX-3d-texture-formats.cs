using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Validate that all 3D objects use supported texture file formats
                foreach (ISlide slide in pres.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        IThreeDFormat threeDFormat = shape.ThreeDFormat;
                        if (threeDFormat != null)
                        {
                            // Placeholder for texture format validation.
                            // For example, if the shape uses a picture fill, you could inspect the image format here.
                            // Supported formats could be .png, .jpg, .jpeg, .bmp, etc.
                        }
                    }
                }

                // Save the presentation before exiting
                string outputPath = "output.pptx";
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Handle unsupported PPTX format
            Console.WriteLine("Unsupported PPTX format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Handle unsupported PPT format
            Console.WriteLine("Unsupported PPT format: " + ex.Message);
        }
        catch (NotSupportedException ex)
        {
            // Handle other format-related errors
            Console.WriteLine("Format not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}