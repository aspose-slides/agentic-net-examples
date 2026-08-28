// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Render PPTX slide notes to PNG using C#

//

// Description:

// Demonstrates how to render PPTX slide notes to PNG using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Render, Pptx, Slide, 

// Notes, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate render PPTX slide notes to PNG.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace RenderNotesToPng

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            // Output folder for notes images

            string outputDir = Path.Combine(Environment.CurrentDirectory, "NotesImages");

            // Output presentation path (saved after processing)

            string outputPresentationPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Ensure output directory exists

            if (!Directory.Exists(outputDir))

            {

                Directory.CreateDirectory(outputDir);

            }



            // Load presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                // Desired image dimensions for notes (high‑resolution)

                int desiredWidth = 1200;

                int desiredHeight = 800;



                // Calculate scaling factors based on slide size

                float scaleX = (float)desiredWidth / pres.SlideSize.Size.Width;

                float scaleY = (float)desiredHeight / pres.SlideSize.Size.Height;



                // Configure rendering options to include notes (bottom truncated)

                RenderingOptions renderingOpts = new RenderingOptions();

                renderingOpts.SlidesLayoutOptions = new NotesCommentsLayoutingOptions

                {

                    NotesPosition = NotesPositions.BottomTruncated

                };



                // Iterate through each slide and render its notes

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    ISlide slide = pres.Slides[i];

                    // Generate image with notes using rendering options and scaling

                    using (IImage img = slide.GetImage(renderingOpts, scaleX, scaleY))

                    {

                        string noteImagePath = Path.Combine(outputDir, $"Slide_{i + 1}_Notes.png");

                        img.Save(noteImagePath, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save the (potentially modified) presentation before exit

                try

                {

                    pres.Save(outputPresentationPath, SaveFormat.Pptx);

                }

                catch (NotSupportedException)

                {

                    // Format not supported – handle accordingly

                }

            }

        }

    }

}

