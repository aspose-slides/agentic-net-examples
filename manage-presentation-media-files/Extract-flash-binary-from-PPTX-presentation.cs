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
            string inputPath = "input.pptx";
            string outputDirectory = "ExtractedFlash";
            Directory.CreateDirectory(outputDirectory);

            using (Presentation presentation = new Presentation(inputPath))
            {
                int flashIndex = 0;
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        OleObjectFrame oleObject = shape as OleObjectFrame;
                        if (oleObject != null && oleObject.EmbeddedData != null)
                        {
                            string extension = oleObject.EmbeddedData.EmbeddedFileExtension;
                            if (string.Equals(extension, "swf", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(extension, ".swf", StringComparison.OrdinalIgnoreCase))
                            {
                                byte[] data = oleObject.EmbeddedData.EmbeddedFileData;
                                string outputPath = Path.Combine(outputDirectory, "FlashObject_" + flashIndex + ".swf");
                                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                                {
                                    fileStream.Write(data, 0, data.Length);
                                }
                                flashIndex++;
                            }
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}