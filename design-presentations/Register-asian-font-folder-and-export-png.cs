// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Register Asian font folder and export slides as PNG using C#

//

// Description:

// Demonstrates how to register an external Asian fonts folder, load a PowerPoint

// presentation, export each slide as a high‑resolution PNG image, and save the

// presentation using Aspose.Slides for .NET. The example includes validation of

// input files, creation of output directories, and cleanup of loaded fonts.

// This pattern can be used in console applications to automate slide image

// generation and ensure proper font rendering for Asian characters.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Register, Asian, Font,

// Folder, Presentation Processing, Slide Export, Image Export, Office Automation

//

// Use Cases:

// - Automate registration of Asian font folders for correct rendering.

// - Generate PNG images from each slide of a PPTX file.

// - Build .NET tools for batch processing of presentations.

// - Validate and transform presentations before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace FontFolderExport

{

    class Program

    {

        static void Main(string[] args)

        {

            // Define paths

            string fontsFolderPath = @"C:\AsianFonts";

            string inputPresentationPath = @"C:\Presentations\input.pptx";

            string outputPresentationPath = @"C:\Presentations\output.pptx";

            string outputImagesFolder = @"C:\Presentations\SlideImages";



            // Verify input file exists

            if (!File.Exists(inputPresentationPath))

            {

                Console.WriteLine("Input presentation file does not exist.");

                return;

            }



            // Load external Asian fonts before creating the presentation

            Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontsFolderPath });



            // Load the presentation

            Presentation presentation = new Presentation(inputPresentationPath);



            // Ensure output directory exists

            Directory.CreateDirectory(outputImagesFolder);



            // Export each slide as a high‑resolution PNG image

            for (int i = 0; i < presentation.Slides.Count; i++)

            {

                // Get slide image with scaling factor 2 (high resolution)

                IImage slideImage = presentation.Slides[i].GetImage(2f, 2f);

                string imagePath = Path.Combine(outputImagesFolder, $"Slide_{i + 1}.png");

                slideImage.Save(imagePath, Aspose.Slides.ImageFormat.Png);

            }



            // Save the presentation (required before exit)

            presentation.Save(outputPresentationPath, SaveFormat.Pptx);



            // Clear loaded fonts cache

            Aspose.Slides.FontsLoader.ClearCache();



            // Dispose presentation

            presentation.Dispose();

        }

    }

}

