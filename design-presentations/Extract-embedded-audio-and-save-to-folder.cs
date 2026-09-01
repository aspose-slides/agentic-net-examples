// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Extract embedded audio and save to folder using C#

//

// Description:

// Demonstrates how to extract embedded audio and save to folder using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Embedded, Audio, Save, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate extract embedded audio and save to folder.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AudioExtractionExample

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output folder for extracted audio files

            string outputFolder = "ExtractedAudios";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("The specified presentation file does not exist.");

                return;

            }



            // Ensure the output directory exists

            Directory.CreateDirectory(outputFolder);



            try

            {

                // Load the presentation

                Presentation pres = new Presentation(inputPath);



                // Iterate through all embedded audio clips

                for (int i = 0; i < pres.Audios.Count; i++)

                {

                    IAudio audio = pres.Audios[i];

                    if (audio != null && audio.BinaryData != null)

                    {

                        string audioFilePath = Path.Combine(outputFolder, $"audio_{i}.bin");

                        File.WriteAllBytes(audioFilePath, audio.BinaryData);

                    }

                }



                // Save the presentation before exiting (no changes made)

                pres.Save(inputPath, SaveFormat.Pptx);

                pres.Dispose();

            }

            catch (Exception ex)

            {

                // Handle unsupported format or other errors

                // Format not supported

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

        }

    }

}

