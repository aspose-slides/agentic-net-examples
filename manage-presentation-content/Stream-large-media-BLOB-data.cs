using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputFolder = "output_videos";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

                using (Presentation pres = new Presentation(inputPath, loadOptions))
                {
                    byte[] buffer = new byte[8 * 1024];
                    for (int i = 0; i < pres.Videos.Count; i++)
                    {
                        IVideo video = pres.Videos[i];
                        using (Stream videoStream = video.GetStream())
                        {
                            string outputPath = Path.Combine(outputFolder, "video" + i + ".dat");
                            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                            {
                                int bytesRead;
                                while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    outputFile.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }

                    string savedPath = "saved_output.pptx";
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}