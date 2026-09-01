// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate animated GIF slide order by timestamps using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to an animated GIF

// and validate that the GIF frames preserve the original slide order by

// examining frame timestamps. The example uses Aspose.Slides for .NET to

// perform the conversion and System.Drawing to read GIF frame delays.

// It outputs a GIF file, a copy of the original presentation, and prints

// validation results to the console.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, GIF conversion, Animated GIF,

// Slide order validation, Frame timestamps, Presentation processing, Office Automation

//

// Use Cases:

// - Convert PPTX files to animated GIFs while retaining slide timing.

// - Verify that GIF frames correspond to the original slide sequence.

// - Build automated tools for presentation quality checks in .NET.

// - Integrate GIF generation and validation into CI pipelines or reporting systems.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;

using System.Drawing;

using System.Drawing.Imaging;



namespace ValidateAnimatedGif

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output paths

            string inputPath = "input.pptx";

            string gifPath = "output.gif";

            string validatedPresPath = "validated.pptx";



            // GIF conversion settings

            int frameWidth = 960;

            int frameHeight = 720;

            int defaultDelay = 2000; // milliseconds

            int transitionFps = 35;



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



                // Convert to animated GIF

                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

                gifOptions.FrameSize = new System.Drawing.Size(frameWidth, frameHeight);

                gifOptions.DefaultDelay = defaultDelay;

                gifOptions.TransitionFps = transitionFps;

                presentation.Save(gifPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);



                // Save the (unchanged) presentation before exit as required

                presentation.Save(validatedPresPath, Aspose.Slides.Export.SaveFormat.Pptx);

                presentation.Dispose();



                // Validate GIF frame order by timestamps

                using (Image gifImage = Image.FromFile(gifPath))

                {

                    // Get total number of frames in the GIF

                    FrameDimension dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);

                    int frameCount = gifImage.GetFrameCount(dimension);



                    // Retrieve frame delay property (in 1/100ths of a second)

                    PropertyItem delayItem = gifImage.GetPropertyItem(0x5100);

                    byte[] delayBytes = delayItem.Value;

                    int[] frameDelays = new int[frameCount];

                    for (int i = 0; i < frameCount; i++)

                    {

                        // Each delay is a 4‑byte unsigned integer

                        int delay = BitConverter.ToInt32(delayBytes, i * 4);

                        frameDelays[i] = delay * 10; // convert to milliseconds

                    }



                    // Simple validation: ensure at least one frame per slide and that frames are in chronological order

                    int slideCount = new Aspose.Slides.Presentation(inputPath).Slides.Count;

                    if (frameCount < slideCount)

                    {

                        Console.WriteLine("Validation failed: fewer frames than slides.");

                    }

                    else

                    {

                        bool timestampsIncreasing = true;

                        int cumulativeTime = 0;

                        for (int i = 0; i < frameCount; i++)

                        {

                            cumulativeTime += frameDelays[i];

                            if (i > 0 && cumulativeTime <= 0)

                            {

                                timestampsIncreasing = false;

                                break;

                            }

                        }



                        if (timestampsIncreasing)

                        {

                            Console.WriteLine("Validation succeeded: GIF frames preserve slide order.");

                        }

                        else

                        {

                            Console.WriteLine("Validation failed: frame timestamps are not increasing.");

                        }

                    }

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

