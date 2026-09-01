// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Save PPTX slides as PNG zero padded using C#

//

// Description:

// Demonstrates how to save PPTX slides as PNG zero padded using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Pptx, Slides, Zero, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate save PPTX slides as PNG zero padded.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            using (Presentation pres = new Presentation(inputPath))

            {

                int slideCount = pres.Slides.Count;

                int padLength = slideCount.ToString().Length;



                // Export each slide as a PNG with zero‑padded index

                for (int i = 0; i < slideCount; i++)

                {

                    ISlide slide = pres.Slides[i];

                    string outputPath = $"slide_{(i + 1).ToString().PadLeft(padLength, '0')}.png";



                    // Use GetImage inside a using block and save as PNG

                    using (IImage image = slide.GetImage())

                    {

                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save the presentation before exiting (no modifications made)

                pres.Save("output.pptx", SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine($"Error: {ex.Message}");

        }

    }

}

