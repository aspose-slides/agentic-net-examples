// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Export PPTX to SWF no audio using C#

//

// Description:

// Demonstrates how to export a PPTX file to SWF format while removing all

// audio content using C# and Aspose.Slides for .NET. The example loads a

// presentation, hides any audio frames, configures SWF export options, and

// saves the result as a SWF file. This pattern can be used in console

// applications to automate PowerPoint conversion workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Export, Audio, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate conversion of PPTX presentations to SWF without audio.

// - Create C# utilities for PowerPoint content sanitization before publishing.

// - Integrate SWF export into .NET applications that require audio‑free output.

// - Validate and preprocess presentations in batch processing pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ExportPptxToSwf

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.swf";



            // Check if the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file not found: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Disable all audio frames by hiding them

                    foreach (ISlide slide in presentation.Slides)

                    {

                        foreach (IShape shape in slide.Shapes)

                        {

                            IAudioFrame audioFrame = shape as IAudioFrame;

                            if (audioFrame != null)

                            {

                                audioFrame.Hidden = true;

                            }

                        }

                    }



                    // Configure SWF export options (audio is already hidden)

                    SwfOptions swfOptions = new SwfOptions();

                    // Example: disable the integrated viewer to reduce size further

                    swfOptions.ViewerIncluded = false;



                    // Save the presentation as SWF with the specified options

                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                }



                Console.WriteLine("Presentation exported successfully to: " + outputPath);

            }

            catch (NotSupportedException ex)

            {

                // Handle unsupported format exception

                Console.WriteLine("Format not supported: " + ex.Message);

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., I/O errors)

                Console.WriteLine("Error: " + ex.Message);

            }

        }

    }

}

