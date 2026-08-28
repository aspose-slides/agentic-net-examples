// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export presentation to MP4 with animations using C#

//

// Description:

// Demonstrates how to export a PowerPoint presentation (PPTX) to an MP4 video

// while preserving slide animations, using Aspose.Slides for .NET. The example

// loads an input file, generates animation data, resolves the MP4 save format

// at runtime, and saves the resulting video. It includes basic error handling

// for missing files and unsupported formats.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, MP4, Video, Animations,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to MP4 videos with animations.

// - Build .NET tools for generating video content from PowerPoint files.

// - Integrate presentation-to-video functionality into larger applications.

// - Validate that slide animations are correctly rendered in exported videos.

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

        string outputPath = "output.mp4";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            using (Presentation presentation = new Presentation(inputPath))

            {

                // Generate animations to ensure they are rendered correctly

                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))

                {

                    animationsGenerator.Run(presentation.Slides);

                }



                // Resolve MP4 SaveFormat at runtime to avoid compile‑time errors

                Aspose.Slides.Export.SaveFormat mp4Format = (Aspose.Slides.Export.SaveFormat)Enum.Parse(

                    typeof(Aspose.Slides.Export.SaveFormat), "Mp4");



                // Save the presentation as MP4 video

                presentation.Save(outputPath, mp4Format);

            }

        }

        catch (ArgumentException)

        {

            // MP4 format not found in SaveFormat enumeration

            Console.WriteLine("MP4 format is not supported by this version of Aspose.Slides.");

        }

        catch (NotSupportedException)

        {

            // Unsupported save format

            Console.WriteLine("MP4 format is not supported.");

        }

        catch (Exception ex)

        {

            // General exception handling

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

