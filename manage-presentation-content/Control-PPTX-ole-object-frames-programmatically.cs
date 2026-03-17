using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IOleObjectFrame oleFrame = slide.Shapes[shapeIndex] as Aspose.Slides.IOleObjectFrame;
                        if (oleFrame != null && oleFrame.EmbeddedData != null && oleFrame.EmbeddedData.EmbeddedFileData != null)
                        {
                            // Extract embedded OLE data to a file
                            byte[] data = oleFrame.EmbeddedData.EmbeddedFileData;
                            string extension = oleFrame.EmbeddedData.EmbeddedFileExtension;
                            string outputPath = $"extracted_{slideIndex}_{shapeIndex}{extension}";

                            using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                            {
                                fs.Write(data, 0, data.Length);
                            }
                        }
                    }
                }

                // Save the presentation after processing
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}