// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create markdown with embedded base64 images using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to a markdown file

// with images embedded as base64 data URIs using Aspose.Slides for .NET. The

// example loads an existing PPTX, configures MarkdownSaveOptions to replace

// image links with base64-encoded strings, saves the markdown output, and

// optionally saves the presentation back to PPTX.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Markdown, Embedded Images,

// Base64, Image Saving, Presentation Conversion, Office Automation

//

// Use Cases:

// - Generate markdown documentation from PowerPoint slides with inline images.

// - Create self‑contained markdown files for web publishing or documentation.

// - Automate conversion of PPTX to markdown in CI/CD pipelines.

// - Preserve visual content without external image files.

// -----------------------------------------------------------------------------



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

