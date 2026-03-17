using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.DOM.Ole;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputDirectory = "ExtractedFlash";
            Directory.CreateDirectory(outputDirectory);

            using (Presentation presentation = new Presentation(inputPath))
            {
                int flashIndex = 0;

                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        OleObjectFrame oleObject = shape as OleObjectFrame;

                        if (oleObject != null)
                        {
                            IOleEmbeddedDataInfo embeddedInfo = oleObject.EmbeddedData;

                            if (embeddedInfo != null &&
                                string.Equals(embeddedInfo.EmbeddedFileExtension, "swf", StringComparison.OrdinalIgnoreCase))
                            {
                                byte[] flashData = embeddedInfo.EmbeddedFileData;
                                string flashFileName = $"flash_{flashIndex}.swf";
                                string flashPath = Path.Combine(outputDirectory, flashFileName);

                                using (FileStream fileStream = new FileStream(flashPath, FileMode.Create, FileAccess.Write))
                                {
                                    fileStream.Write(flashData, 0, flashData.Length);
                                }

                                flashIndex++;
                            }
                        }
                    }
                }

                // Save the presentation (optional)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}