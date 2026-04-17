using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        string filePath = "sample.pptx";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist: " + filePath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(filePath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    if (slide.Hidden)
                    {
                        ITextFrame[] textFrames = SlideUtil.GetAllTextBoxes(slide);
                        Console.WriteLine("Hidden slide index " + slide.SlideNumber + " contains " + textFrames.Length + " text boxes.");
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}