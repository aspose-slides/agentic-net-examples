using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractFlashObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "input.pptx";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int slideIndex = 0;
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        int shapeIndex = 0;
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.OleObjectFrame oleFrame = shape as Aspose.Slides.OleObjectFrame;
                            if (oleFrame != null)
                            {
                                Aspose.Slides.IOleEmbeddedDataInfo embeddedData = oleFrame.EmbeddedData;
                                if (embeddedData != null)
                                {
                                    string extension = embeddedData.EmbeddedFileExtension;
                                    if (!string.IsNullOrEmpty(extension) && extension.Equals("swf", StringComparison.OrdinalIgnoreCase))
                                    {
                                        byte[] data = embeddedData.EmbeddedFileData;
                                        string fileName = $"Flash_{slideIndex}_{shapeIndex}.{extension}";
                                        using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                                        {
                                            fileStream.Write(data, 0, data.Length);
                                        }
                                    }
                                }
                            }
                            shapeIndex++;
                        }
                        slideIndex++;
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}