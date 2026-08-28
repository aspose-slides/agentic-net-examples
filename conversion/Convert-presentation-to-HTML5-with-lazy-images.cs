// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Convert presentation to HTML5 with lazy images using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to an HTML5 file

// with lazy-loaded images using Aspose.Slides for .NET. The example loads a

// PPTX file, configures Html5Options to externalize images, and saves the

// result along with a resources folder containing the image files.

// This pattern can be used in console applications to automate PPTX to HTML5

// conversion while keeping the output lightweight.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Convert, Presentation, Html5,

// Lazy Images, External Resources, Office Automation

//

// Use Cases:

// - Automate conversion of presentations to HTML5 with external image resources.

// - Build tools that generate web‑ready slideshows from PPTX files.

// - Integrate presentation conversion into .NET services or CI pipelines.

// - Reduce HTML size by using lazy loading of images for faster page loads.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ConvertToHtml5LazyImages

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            // Output HTML5 file path

            string outputPath = "output.html";

            // Folder where external resources (images, scripts, etc.) will be stored

            string resourcesFolder = "output_resources";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(inputPath))

                {

                    // Configure HTML5 export options for lazy loading (do not embed images)

                    Html5Options html5Options = new Html5Options

                    {

                        EmbedImages = false,          // Images will be saved as external files

                        OutputPath = resourcesFolder  // Specify folder for external resources

                    };



                    // Ensure the resources folder exists

                    if (!Directory.Exists(resourcesFolder))

                    {

                        Directory.CreateDirectory(resourcesFolder);

                    }



                    // Save the presentation as HTML5

                    presentation.Save(outputPath, SaveFormat.Html5, html5Options);

                }



                Console.WriteLine("Conversion completed successfully.");

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Handle unsupported file format

                Console.WriteLine("The provided file format is not supported for conversion.");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

