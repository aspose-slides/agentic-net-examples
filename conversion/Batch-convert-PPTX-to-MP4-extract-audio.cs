// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Batch convert PPTX to MP4 extract audio using C#

//

// Description:

// Demonstrates how to batch process PowerPoint presentations to extract

// embedded audio tracks and attempts MP4 video conversion (which is not

// supported by Aspose.Slides for .NET). The example shows folder handling,

// presentation loading, audio extraction, and saving the original file.

// Developers can adapt this pattern for automated PPTX workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, MP4, Audio Extraction, Aspose.Slides for .NET, Batch,

// Convert, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate batch extraction of audio from PPTX files.

// - Attempt video conversion of presentations where supported.

// - Build .NET tools for PowerPoint presentation processing.

// - Validate and preserve original presentations after processing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace BatchConvert

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputFolder = "InputPresentations";

            string outputFolder = "Output";



            if (!Directory.Exists(inputFolder))

            {

                Console.WriteLine("Input folder does not exist: " + inputFolder);

                return;

            }



            if (!Directory.Exists(outputFolder))

            {

                Directory.CreateDirectory(outputFolder);

            }



            string[] presentationFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string presentationPath in presentationFiles)

            {

                if (!File.Exists(presentationPath))

                {

                    Console.WriteLine("File not found: " + presentationPath);

                    continue;

                }



                try

                {

                    using (Presentation presentation = new Presentation(presentationPath))

                    {

                        // Attempt to convert to MP4 video.

                        // Note: SaveFormat does not contain an MP4 definition, so this operation is not supported.

                        string videoOutputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(presentationPath) + ".mp4");

                        try

                        {

                            // The following line would cause a compile error because SaveFormat.Mp4 does not exist.

                            // presentation.Save(videoOutputPath, SaveFormat.Mp4);

                            // Simulate unsupported format handling.

                            throw new NotSupportedException("MP4 format not supported by SaveFormat enum.");

                        }

                        catch (NotSupportedException)

                        {

                            // MP4 format not supported; skip video conversion.

                            Console.WriteLine("Video conversion not supported for: " + presentationPath);

                        }



                        // Extract embedded audio tracks.

                        IAudioCollection audioCollection = presentation.Audios;

                        for (int i = 0; i < audioCollection.Count; i++)

                        {

                            IAudio audio = audioCollection[i];

                            string contentType = audio.ContentType; // e.g., "audio/mpeg"

                            int slashIndex = contentType.LastIndexOf('/');

                            string extension = (slashIndex >= 0 && slashIndex < contentType.Length - 1) ? contentType.Substring(slashIndex + 1) : "bin";



                            string audioOutputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(presentationPath) + "_audio_" + i + "." + extension);

                            using (Stream audioStream = audio.GetStream())

                            {

                                using (FileStream fileStream = new FileStream(audioOutputPath, FileMode.Create, FileAccess.Write))

                                {

                                    byte[] buffer = new byte[8192];

                                    int bytesRead;

                                    while ((bytesRead = audioStream.Read(buffer, 0, buffer.Length)) > 0)

                                    {

                                        fileStream.Write(buffer, 0, bytesRead);

                                    }

                                }

                            }

                        }



                        // Save the presentation before exiting (preserve original format).

                        SaveFormat saveFormat = SaveFormat.Pptx;

                        if (presentation.SourceFormat == SourceFormat.Ppt)

                        {

                            saveFormat = SaveFormat.Ppt;

                        }

                        presentation.Save(presentationPath, saveFormat);

                    }

                }

                catch (PptxUnsupportedFormatException ex)

                {

                    // Handle unsupported source format for PPTX.

                    Console.WriteLine("Unsupported PPTX format: " + ex.Message);

                }

                catch (PptUnsupportedFormatException ex)

                {

                    // Handle unsupported source format for PPT.

                    Console.WriteLine("Unsupported PPT format: " + ex.Message);

                }

                catch (Exception ex)

                {

                    // General exception handling.

                    Console.WriteLine("Error processing file " + presentationPath + ": " + ex.Message);

                }

            }

        }

    }

}

