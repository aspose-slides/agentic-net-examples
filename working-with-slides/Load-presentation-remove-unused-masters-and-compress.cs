using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Remove unused master slides
                presentation.Masters.RemoveUnused(false);

                // Compress images in all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            pictureFrame.PictureFormat.CompressImage(true, Aspose.Slides.Export.PicturesCompression.Dpi96);
                        }
                    }
                }

                // Save with PPTX options (ZIP64 mode)
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.IfNecessary;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}