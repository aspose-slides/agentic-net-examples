using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MarkdownExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure Markdown save options
                MarkdownSaveOptions markdownOptions = new MarkdownSaveOptions();
                markdownOptions.ShowSlideNumber = true;
                markdownOptions.Flavor = Flavor.Github;
                markdownOptions.ExportType = MarkdownExportType.Sequential;

                // Handle image saving to embed images as Base64 data URIs
                markdownOptions.ImageSaving += new MarkdownSaveOptions.MarkdownImageSavingHandler(
                    (Aspose.Slides.IImage image, Aspose.Slides.ImageFormat format, ref string link) =>
                    {
                        // Save the image to a memory stream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            image.Save(ms, format);
                            byte[] imageBytes = ms.ToArray();
                            string base64String = Convert.ToBase64String(imageBytes);

                            // Determine MIME type based on image format
                            string mimeType;
                            if (format == Aspose.Slides.ImageFormat.Png)
                                mimeType = "image/png";
                            else if (format == Aspose.Slides.ImageFormat.Jpeg)
                                mimeType = "image/jpeg";
                            else if (format == Aspose.Slides.ImageFormat.Gif)
                                mimeType = "image/gif";
                            else
                                mimeType = "application/octet-stream";

                            // Set the Markdown link to the data URI
                            link = "data:" + mimeType + ";base64," + base64String;
                        }

                        // Indicate that the custom link should be used
                        return true;
                    });

                // Output Markdown file path
                string outputPath = "output.md";

                try
                {
                    // Save the presentation as Markdown with embedded images
                    pres.Save(outputPath, SaveFormat.Md, markdownOptions);
                    Console.WriteLine("Markdown file created successfully: " + outputPath);
                }
                catch (NotSupportedException)
                {
                    // Handle unsupported format
                    Console.WriteLine("The requested format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}