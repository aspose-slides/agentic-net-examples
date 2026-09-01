// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Apply 1024x768 dimensions to TIFF from PPT using C#

//

// Description:

// Demonstrates how to apply 1024x768 dimensions to a TIFF image generated from a

// PowerPoint presentation using C# and Aspose.Slides for .NET. The example loads

// a PPTX file, configures TIFF export options with a custom image size, and

// saves the result as a TIFF file. This pattern can be used to automate image

// generation with specific dimensions from presentations.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, TIFF, ImageSize, 1024x768,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PowerPoint slides to TIFF images with a fixed resolution.

// - Generate high‑resolution slide thumbnails for documentation or web use.

// - Integrate PPTX to TIFF conversion into .NET batch processing pipelines.

// - Ensure consistent image dimensions across exported slide assets.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides.Export;

using System.Drawing;



class Program

{

    static void Main(string[] args)

    {

        // Define input and output file paths

        string inputPath = "input.pptx";

        string outputPath = "output.tiff";



        // Verify that the input file exists

        if (!File.Exists(inputPath))

        {

            Console.WriteLine("Input file does not exist.");

            return;

        }



        try

        {

            // Load the presentation

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);



            // Create TIFF options and set custom image dimensions

            Aspose.Slides.Export.TiffOptions options = new Aspose.Slides.Export.TiffOptions();

            options.ImageSize = new Size(1024, 768);



            // Save the presentation as TIFF with the specified options

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, options);



            // Dispose the presentation object

            presentation.Dispose();

        }

        catch (NotSupportedException)

        {

            // Format not supported

            Console.WriteLine("The file format is not supported.");

        }

        catch (Exception ex)

        {

            // Handle other possible exceptions

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }

}

