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
            string markdownPath = "output.md";
            string presentationSavePath = "output_saved.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure markdown save options with base64 image embedding
                    MarkdownSaveOptions markdownOptions = new MarkdownSaveOptions();
                    markdownOptions.ImageSaving += new MarkdownSaveOptions.MarkdownImageSavingHandler(
                        delegate (IImage image, ImageFormat format, ref string link)
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, format);
                                string base64 = Convert.ToBase64String(ms.ToArray());
                                string mime;
                                if (format == Aspose.Slides.ImageFormat.Png)
                                    mime = "png";
                                else if (format == Aspose.Slides.ImageFormat.Jpeg)
                                    mime = "jpeg";
                                else if (format == Aspose.Slides.ImageFormat.Gif)
                                    mime = "gif";
                                else if (format == Aspose.Slides.ImageFormat.Bmp)
                                    mime = "bmp";
                                else
                                    mime = format.ToString().ToLower();

                                link = "data:image/" + mime + ";base64," + base64;
                                return true; // Use custom link
                            }
                        });

                    // Save presentation as markdown with embedded images
                    presentation.Save(markdownPath, SaveFormat.Md, markdownOptions);

                    // Save the presentation before exiting
                    presentation.Save(presentationSavePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}