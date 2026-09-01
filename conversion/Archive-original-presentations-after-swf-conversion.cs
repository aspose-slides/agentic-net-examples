// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Archive original presentations after swf conversion using C#

//

// Description:

// Demonstrates how to archive the original PowerPoint presentation after converting

// it to SWF format using Aspose.Slides for .NET. The example loads a PPTX file,

// saves it as SWF, moves the original file to an archive folder, and handles

// basic error scenarios in a console application.

//

// Keywords:

// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Archive, Original, 

// Presentations, Conversion, Automation, Office Automation

//

// Use Cases:

// - Automate archiving of source presentations after SWF conversion.

// - Build C# utilities for PowerPoint to SWF transformation workflows.

// - Manage presentation assets by separating processed files from originals.

// - Integrate presentation conversion and archiving into .NET applications.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace SwfConversionAndArchive

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define paths

            string inputPath = @"C:\Presentations\example.pptx";

            string outputDirectory = @"C:\Presentations\Converted";

            string archiveDirectory = @"C:\Presentations\Archive";



            // Ensure output and archive directories exist

            Directory.CreateDirectory(outputDirectory);

            Directory.CreateDirectory(archiveDirectory);



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load presentation

                Presentation presentation = new Presentation(inputPath);



                // Prepare SWF options (default settings)

                SwfOptions swfOptions = new SwfOptions();



                // Define output SWF file path

                string outputSwfPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".swf");



                // Save as SWF

                presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);



                // Archive original presentation

                string archivedPath = Path.Combine(archiveDirectory, Path.GetFileName(inputPath));

                // Overwrite if already exists in archive

                if (File.Exists(archivedPath))

                {

                    File.Delete(archivedPath);

                }

                File.Move(inputPath, archivedPath);



                // Dispose presentation

                presentation.Dispose();



                Console.WriteLine("Conversion successful. Original file archived.");

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The file format is not supported for SWF conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

