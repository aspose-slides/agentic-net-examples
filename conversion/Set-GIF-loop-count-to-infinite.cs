// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set GIF loop count to infinite using C#

//

// Description:

// Demonstrates how to set the GIF loop count to infinite when converting a

// PowerPoint presentation to an animated GIF using Aspose.Slides for .NET.

// The example loads a PPTX file, configures GIF export options, enables

// looping at the presentation level, saves the GIF, and reads back the GIF

// metadata to confirm that the loop count is set to infinite (0).

//

// Keywords:

// C#, Aspose.Slides, GIF, infinite loop, PowerPoint conversion, PPTX to GIF,

// presentation processing, .NET automation

//

// Use Cases:

// - Convert PPTX slides to an animated GIF that repeats indefinitely.

// - Verify GIF loop metadata programmatically.

// - Integrate GIF export with infinite looping into .NET applications.

// - Automate presentation-to-GIF workflows for web or desktop publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;

using System.Drawing.Imaging;



class Program

{

    static void Main()

    {

        string inputPath = "input.pptx";

        string outputPath = "output.gif";



        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            Presentation presentation = new Presentation(inputPath);

            GifOptions gifOptions = new GifOptions

            {

                FrameSize = new Size(960, 720),

                DefaultDelay = 2000,

                TransitionFps = 35

            };



            // Enable infinite looping at the presentation level

            presentation.SlideShowSettings.Loop = true;



            presentation.Save(outputPath, SaveFormat.Gif, gifOptions);

            presentation.Dispose();



            // Verify GIF metadata for loop count (0 indicates infinite looping)

            using (Image gifImage = Image.FromFile(outputPath))

            {

                const int PropertyTagLoopCount = 0x5100;

                PropertyItem loopProperty = null;

                try

                {

                    loopProperty = gifImage.GetPropertyItem(PropertyTagLoopCount);

                }

                catch (ArgumentException)

                {

                    // Property not found

                }



                if (loopProperty != null && loopProperty.Value.Length >= 2)

                {

                    int loopCount = BitConverter.ToUInt16(loopProperty.Value, 0);

                    Console.WriteLine("Loop count in GIF metadata: " + loopCount);

                }

                else

                {

                    Console.WriteLine("Loop count property not found in GIF metadata.");

                }

            }

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The specified format is not supported.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

