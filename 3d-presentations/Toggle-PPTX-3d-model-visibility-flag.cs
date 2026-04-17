using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        bool show3D = true;
        if (args.Length > 1)
        {
            bool parsed;
            if (bool.TryParse(args[1], out parsed))
            {
                show3D = parsed;
            }
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                ISlide slide = pres.Slides[0];
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    IShape shape = slide.Shapes[i];
                    if (shape.ThreeDFormat != null)
                    {
                        if (show3D)
                        {
                            shape.ThreeDFormat.ExtrusionHeight = 100; // make 3D visible
                        }
                        else
                        {
                            shape.ThreeDFormat.ExtrusionHeight = 0; // hide 3D
                        }
                    }
                }

                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}