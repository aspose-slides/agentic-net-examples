// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Set PPTX master slides gray background using C#

//

// Description:

// Demonstrates how to set the background color of all master slides in PPTX

// files to solid gray using C# and Aspose.Slides for .NET. The console

// application processes every *.pptx file in a specified input folder,

// updates each master slide, and saves the modified presentations into a

// "Processed" subfolder while preserving the original file names.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Master Slides, Gray Background,

// Presentation Processing, Batch Processing, Office Automation, Folder Scan

//

// Use Cases:

// - Batch update master slide backgrounds to a corporate gray theme.

// - Build automated tools for preparing presentations before distribution.

// - Integrate background styling into .NET PowerPoint workflow pipelines.

// - Validate and enforce visual consistency across multiple PPTX files.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SetMasterSlideGrayBackground

{

    class Program

    {

        static void Main(string[] args)

        {

            // Folder path can be passed as first argument; default to "input"

            string folderPath = args.Length > 0 ? args[0] : "input";



            if (!Directory.Exists(folderPath))

            {

                Console.WriteLine("The specified folder does not exist.");

                return;

            }



            // Get all PPTX files in the folder

            string[] pptxFiles = Directory.GetFiles(folderPath, "*.pptx");



            foreach (string filePath in pptxFiles)

            {

                if (!File.Exists(filePath))

                {

                    // Skip if file somehow does not exist

                    continue;

                }



                try

                {

                    // Load the presentation

                    using (Presentation presentation = new Presentation(filePath))

                    {

                        // Iterate through all master slides and set solid gray background

                        foreach (IMasterSlide masterSlide in presentation.Masters)

                        {

                            masterSlide.Background.Type = BackgroundType.OwnBackground;

                            masterSlide.Background.FillFormat.FillType = FillType.Solid;

                            masterSlide.Background.FillFormat.SolidFillColor.Color = Color.Gray;

                        }



                        // Prepare output path (creates a "Processed" subfolder)

                        string outputDirectory = Path.Combine(folderPath, "Processed");

                        Directory.CreateDirectory(outputDirectory);

                        string outputFilePath = Path.Combine(outputDirectory, Path.GetFileName(filePath));



                        // Save the modified presentation

                        presentation.Save(outputFilePath, SaveFormat.Pptx);

                    }

                }

                catch (PptxUnsupportedFormatException)

                {

                    // Format not supported – comment as required

                    // Unsupported file format; skipping this file.

                }

                catch (Exception ex)

                {

                    // General exception handling (e.g., I/O errors)

                    Console.WriteLine($"Error processing file '{filePath}': {ex.Message}");

                }

            }

        }

    }

}

