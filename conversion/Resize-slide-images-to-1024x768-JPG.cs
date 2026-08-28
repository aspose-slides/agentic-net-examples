// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Resize slide images to 1024x768 JPG using C#

//

// Description:

// Demonstrates how to resize slide images to 1024x768 JPG using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPG, Resize, Slide, Images, 

// 1024X768, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate resize slide images to 1024x768 JPG.

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

        string outputDir = "output";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

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

                foreach (ISlide slide in presentation.Slides)

                {

                    using (IImage image = slide.GetImage(new System.Drawing.Size(1024, 768)))

                    {

                        string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");

                        image.Save(outputPath, ImageFormat.Jpeg);

                    }

                }



                // Save the presentation before exiting (even if unchanged)

                string presOutput = Path.Combine(outputDir, "ModifiedPresentation.pptx");

                presentation.Save(presOutput, SaveFormat.Pptx);

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error: " + ex.Message);

        }

    }

}

