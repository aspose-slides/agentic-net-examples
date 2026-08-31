// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Generate smartart thumbnail with fallback fonts JPEG using C#

//

// Description:

// Demonstrates how to add a SmartArt diagram to a presentation, generate

// slide thumbnails using a fallback font, and save the results as JPEG images

// using C# and Aspose.Slides for .NET. The example processes a PPTX file,

// creates a SmartArt shape on the first slide, renders each slide to a JPEG

// with a specified default regular font, and saves both the thumbnails and the

// modified presentation. This pattern helps automate PowerPoint workflows,

// ensure consistent rendering with fallback fonts, and integrate presentation

// handling into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Generate, SmartArt,

// Thumbnail, Fallback Font, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate generation of slide thumbnails with fallback fonts in JPEG format.

// - Add SmartArt diagrams programmatically to PowerPoint presentations.

// - Build C# tools for PowerPoint presentation processing and image export.

// - Validate and transform PPTX files in .NET applications before publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using Aspose.Slides.SmartArt;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputDir = "output";



        try

        {

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            using (Presentation pres = new Presentation(inputPath))

            {

                if (!Directory.Exists(outputDir))

                {

                    Directory.CreateDirectory(outputDir);

                }



                // Add a SmartArt diagram to the first slide

                ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(

                    50f, 50f, 400f, 300f, SmartArtLayoutType.BasicBlockList);



                // Set rendering options with a fallback font

                RenderingOptions renderingOpts = new RenderingOptions();

                renderingOpts.DefaultRegularFont = "Arial Black";



                for (int i = 0; i < pres.Slides.Count; i++)

                {

                    ISlide slide = pres.Slides[i];

                    IImage thumbnail = slide.GetImage(renderingOpts, 1f, 1f);

                    string outPath = Path.Combine(outputDir, $"slide_{i + 1}.jpg");

                    thumbnail.Save(outPath, ImageFormat.Jpeg);

                }



                // Save the modified presentation

                string savedPath = Path.Combine(outputDir, "result.pptx");

                pres.Save(savedPath, SaveFormat.Pptx);

            }

        }

        catch (Aspose.Slides.PptxUnsupportedFormatException ex)

        {

            // Format not supported

            Console.WriteLine("Unsupported file format: " + ex.Message);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

