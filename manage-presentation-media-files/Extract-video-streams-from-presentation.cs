using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input presentation path and output directory
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: VideoExtractor <input-pptx> <output-dir>");
                return;
            }

            string inputPath = args[0];
            string outputDir = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            try
            {
                int videoIndex = 0;
                foreach (ISlide slide in presentation.Slides)
                {
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is VideoFrame)
                        {
                            IVideoFrame vf = (IVideoFrame)shape;
                            string contentType = vf.EmbeddedVideo.ContentType;
                            int slashPos = contentType.LastIndexOf('/');
                            string extension = contentType.Substring(slashPos + 1);
                            byte[] data = vf.EmbeddedVideo.BinaryData;
                            string outPath = Path.Combine(outputDir, $"video_{videoIndex}.{extension}");
                            FileStream fs = new FileStream(outPath, FileMode.Create, FileAccess.Write, FileShare.Read);
                            try
                            {
                                fs.Write(data, 0, data.Length);
                            }
                            finally
                            {
                                fs.Dispose();
                            }
                            videoIndex++;
                        }
                    }
                }
            }
            finally
            {
                // Save presentation before exit (may be unchanged)
                try
                {
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Original format may not support saving as PPTX; ignore for extraction purpose
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }

                presentation.Dispose();
            }
        }
    }
}