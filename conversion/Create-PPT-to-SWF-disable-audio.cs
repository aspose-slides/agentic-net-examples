// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create PPT to SWF disable audio using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation (PPTX) to SWF format

// while disabling all audio by muting audio frames using C# and Aspose.Slides

// for .NET. The example loads a presentation, sets the volume of each audio

// frame to zero, configures SWF export options, and saves the result as an

// SWF file.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Disable Audio, Presentation

// Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX files to SWF without audio for web publishing.

// - Build C# utilities that process presentations and remove sound.

// - Automate batch conversion of presentations to lightweight SWF files.

// - Integrate audio‑free presentation export into .NET applications.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace MyApp

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Mute all audio frames to effectively disable audio tracks

                    foreach (ISlide slide in presentation.Slides)

                    {

                        for (int i = 0; i < slide.Shapes.Count; i++)

                        {

                            IShape shape = slide.Shapes[i];

                            IAudioFrame audioFrame = shape as IAudioFrame;

                            if (audioFrame != null)

                            {

                                // Set volume to zero

                                audioFrame.VolumeValue = 0f;

                            }

                        }

                    }



                    // Configure SWF export options

                    SwfOptions swfOptions = new SwfOptions();

                    // Exclude the integrated viewer to reduce file size

                    swfOptions.ViewerIncluded = false;

                    // Hide UI elements to further reduce size

                    swfOptions.ShowBottomPane = false;

                    swfOptions.ShowFullScreen = false;

                    swfOptions.ShowLeftPane = false;

                    swfOptions.ShowPageBorder = false;

                    swfOptions.ShowPageStepper = false;

                    swfOptions.ShowSearch = false;

                    swfOptions.ShowTopPane = false;



                    // Save the presentation as SWF

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                }

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., web service errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

