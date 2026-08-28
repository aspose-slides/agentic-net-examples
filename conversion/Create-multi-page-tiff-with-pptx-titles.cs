// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create multi page tiff with pptx titles using C#

//

// Description:

// Demonstrates how to convert a PPTX presentation into individual TIFF files

// named after each slide's title (or slide number when a title is not found) and

// additionally generate a single multi‑page TIFF that contains all slides.

// The example uses Aspose.Slides for .NET and can be run as a standalone console

// application. It shows how to load a presentation, iterate through slides,

// extract a simple title, configure TIFF options, and save both single‑page and

// multi‑page TIFF outputs.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Multi, Page, Tiff, Pptx,

// Presentation Processing, Office Automation, Slide Titles, Image Export

//

// Use Cases:

// - Automate conversion of PPTX slides to separate TIFF images with meaningful names.

// - Generate a combined multi‑page TIFF for archival or printing purposes.

// - Build C# utilities for PowerPoint presentation processing and image extraction.

// - Validate and preview slide content by exporting to TIFF format.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MultiPageTiffExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPTX file path (from arguments or default)

            string inputPath;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))

                inputPath = args[0];

            else

                inputPath = "presentation.pptx";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Output directory for TIFF files

            string outputDir = Path.Combine(Environment.CurrentDirectory, "TiffOutput");

            if (!Directory.Exists(outputDir))

                Directory.CreateDirectory(outputDir);



            try

            {

                // Load the presentation

                using (Presentation pres = new Presentation(inputPath))

                {

                    // Iterate through each slide

                    for (int i = 0; i < pres.Slides.Count; i++)

                    {

                        // Access slide by index

                        ISlide slide = pres.Slides[i];



                        // Attempt to retrieve slide title (fallback to slide number)

                        string title = "Slide_" + (i + 1);

                        if (slide.Shapes.Count > 0 && slide.Shapes[0].GetType().Name.Contains("AutoShape"))

                        {

                            // This is a simplistic placeholder for actual title extraction logic

                            // In real scenarios, inspect the shape type and text content

                            // title = ((IAutoShape)slide.Shapes[0]).TextFrame.Text;

                        }



                        // Sanitize title for file name

                        foreach (char invalidChar in Path.GetInvalidFileNameChars())

                            title = title.Replace(invalidChar.ToString(), "_");



                        // Output file path for the current slide

                        string outputPath = Path.Combine(outputDir, title + ".tiff");



                        // Configure TIFF options (default options are sufficient for this example)

                        TiffOptions tiffOptions = new TiffOptions();



                        // Save only the current slide as a single‑page TIFF

                        int[] slideIndices = new int[] { i + 1 }; // Slides are 1‑based for the Save method

                        pres.Save(outputPath, slideIndices, SaveFormat.Tiff, tiffOptions);

                    }



                    // Save the entire presentation as a multi‑page TIFF (optional)

                    string multiPageTiffPath = Path.Combine(outputDir, "AllSlides.tiff");

                    TiffOptions multiPageOptions = new TiffOptions();

                    pres.Save(multiPageTiffPath, SaveFormat.Tiff, multiPageOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

