// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to PNG sequence zero padded using C#

//

// Description:

// Demonstrates how to export each slide of a PPTX file to a PNG image sequence

// with zero‑padded filenames using C# and Aspose.Slides for .NET. The example

// loads a presentation, determines the required filename padding based on the

// total slide count, saves each slide as a PNG file with names like

// slide_001.png, slide_002.png, etc., and finally saves the original

// presentation (no modifications are made). This pattern can be used in

// console utilities or automated workflows that need consistent image naming.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Sequence, Zero

// Padding, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate export of PPTX slides to a zero‑padded PNG sequence.

// - Build C# command‑line tools for PowerPoint slide image extraction.

// - Integrate slide‑to‑image conversion into .NET applications with predictable

//   file naming.

// - Prepare slide assets for publishing, documentation, or further image

//   processing pipelines.

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

        string outputDir = "output";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist: " + inputPath);

            return;

        }



        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                int slideCount = presentation.Slides.Count;

                int padding = slideCount.ToString().Length;



                for (int i = 0; i < slideCount; i++)

                {

                    ISlide slide = presentation.Slides[i];

                    using (IImage image = slide.GetImage())

                    {

                        string fileName = Path.Combine(outputDir, $"slide_{(i + 1).ToString().PadLeft(padding, '0')}.png");

                        image.Save(fileName, Aspose.Slides.ImageFormat.Png);

                    }

                }



                // Save presentation before exit (no modifications made)

                presentation.Save(inputPath, SaveFormat.Pptx);

            }

        }

        catch (PptxUnsupportedFormatException)

        {

            // Format not supported

            Console.WriteLine("The presentation format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

