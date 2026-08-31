// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Load presentation with Asian font and generate thumbnail using C#

//

// Description:

// Demonstrates how to load a PowerPoint presentation while specifying a default

// Asian font, create a full‑scale thumbnail of the first slide, and save both the

// thumbnail image and the (potentially modified) presentation using Aspose.Slides

// for .NET. The example is a self‑contained console application suitable for

// automating PPTX processing tasks that involve Asian text rendering.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, LoadOptions, DefaultAsianFont,

// Thumbnail, Image, Slide, Presentation Processing, Office Automation

//

// Use Cases:

// - Load presentations containing Asian characters with a fallback font.

// - Generate slide thumbnails for preview or indexing purposes.

// - Save processed presentations after applying load options.

// - Integrate thumbnail generation into .NET tools for PowerPoint automation.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AsposeSlidesExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation file path

            string presentationPath = "input.pptx";

            // Output thumbnail image path

            string thumbnailPath = "thumbnail.png";

            // Path to save the presentation after processing

            string savedPresentationPath = "output.pptx";



            // Verify that the input file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("Presentation file not found: " + presentationPath);

                return;

            }



            try

            {

                // Configure load options with a default Asian font

                LoadOptions loadOptions = new LoadOptions();

                loadOptions.DefaultAsianFont = "Arial Unicode MS";



                // Load the presentation using the specified load options

                using (Presentation presentation = new Presentation(presentationPath, loadOptions))

                {

                    // Access the first slide in the presentation

                    ISlide slide = presentation.Slides[0];



                    // Generate a full‑scale thumbnail image of the slide

                    IImage thumbnail = slide.GetImage(1f, 1f);



                    // Save the thumbnail as a PNG file

                    thumbnail.Save(thumbnailPath, ImageFormat.Png);



                    // Save the presentation (required before exiting)

                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);

                }

            }

            catch (NotSupportedException)

            {

                // Handle unsupported file format

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // General error handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

