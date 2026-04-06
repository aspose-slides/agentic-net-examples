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
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];

                    // Treat hidden slides as confidential
                    if (slide.Hidden)
                    {
                        // Remove all comments from the confidential slide
                        Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);
                        for (int j = 0; j < comments.Length; j++)
                        {
                            comments[j].Remove();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}