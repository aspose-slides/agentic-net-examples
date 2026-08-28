// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPT slides as JPEG 80percent quality using C#

//

// Description:

// Demonstrates how to save PPT slides as JPEG 80percent quality using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PPT, JPEG, Save, Slides, Jpeg, 

// 80Percent, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate save PPT slides as JPEG 80percent quality.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SlideToJpeg

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input PPT file path

            string inputPath = "input.pptx";

            // Output directory for JPEG images

            string outputDir = "OutputImages";



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



            try

            {

                // Load presentation

                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);



                // Iterate through slides and save each as JPEG with 80% quality

                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    Aspose.Slides.ISlide slide = pres.Slides[i];

                    Aspose.Slides.IImage image = slide.GetImage(1f, 1f);

                    string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");

                    // Save with quality parameter (0-100)

                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 80);

                }



                // Save presentation before exit (optional, preserving original)

                string savedPath = Path.Combine(outputDir, "SavedPresentation.pptx");

                pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

