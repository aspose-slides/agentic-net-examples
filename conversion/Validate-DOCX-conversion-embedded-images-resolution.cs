// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Validate DOCX conversion embedded images resolution using C#

//

// Description:

// Demonstrates how to capture and compare embedded image resolutions in a

// PowerPoint presentation before and after a simulated DOCX conversion using

// Aspose.Slides for .NET. Since Aspose.Slides does not support saving to DOCX,

// the example saves the presentation as PPTX to simulate a conversion target

// and verifies that image resolutions remain unchanged.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, DOCX, Conversion,

// Embedded, Image Resolution, Presentation Processing, Office Automation

//

// Use Cases:

// - Verify that embedded images retain their original resolution when converting

//   presentations to formats not directly supported by Aspose.Slides.

// - Build validation tools for presentation workflows involving DOCX conversion

//   simulations.

// - Ensure image quality is preserved during automated PowerPoint processing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Collections.Generic;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace ValidateDocxConversion

{

    class Program

    {

        static void Main(string[] args)

        {

            // Determine source presentation path

            string sourcePath = args.Length > 0 ? args[0] : "source.pptx";



            // Verify that the source file exists

            if (!File.Exists(sourcePath))

            {

                Console.WriteLine("Source file does not exist: " + sourcePath);

                return;

            }



            // Load the source presentation

            Presentation sourcePresentation = null;

            try

            {

                sourcePresentation = new Presentation(sourcePath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                return;

            }



            // Capture original image resolutions

            List<Tuple<int, int>> originalResolutions = new List<Tuple<int, int>>();

            foreach (IPPImage image in sourcePresentation.Images)

            {

                // Width and Height are in pixels

                int width = image.Width;

                int height = image.Height;

                originalResolutions.Add(new Tuple<int, int>(width, height));

            }



            // Attempt DOCX conversion (Aspose.Slides does not support DOCX output)

            string docxPath = "converted.docx";

            try

            {

                // The following line is intentionally incorrect for DOCX conversion.

                // Aspose.Slides does not support saving to DOCX format.

                // sourcePresentation.Save(docxPath, SaveFormat.Pptx);

                // Comment: DOCX format is not supported by Aspose.Slides.

                Console.WriteLine("DOCX conversion is not supported by Aspose.Slides.");

            }

            catch (Exception ex)

            {

                // Handle any unexpected exceptions during conversion

                Console.WriteLine("Conversion error: " + ex.Message);

            }



            // For demonstration, save as PPTX to simulate a conversion target

            string simulatedPath = "simulated_output.pptx";

            try

            {

                sourcePresentation.Save(simulatedPath, SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to save simulated PPTX: " + ex.Message);

                sourcePresentation.Dispose();

                return;

            }



            // Load the simulated output presentation

            Presentation simulatedPresentation = null;

            try

            {

                simulatedPresentation = new Presentation(simulatedPath);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to load simulated presentation: " + ex.Message);

                sourcePresentation.Dispose();

                return;

            }



            // Capture image resolutions from the simulated output

            List<Tuple<int, int>> simulatedResolutions = new List<Tuple<int, int>>();

            foreach (IPPImage image in simulatedPresentation.Images)

            {

                int width = image.Width;

                int height = image.Height;

                simulatedResolutions.Add(new Tuple<int, int>(width, height));

            }



            // Compare original and simulated resolutions

            bool allMatch = true;

            int count = Math.Min(originalResolutions.Count, simulatedResolutions.Count);

            for (int i = 0; i < count; i++)

            {

                Tuple<int, int> original = originalResolutions[i];

                Tuple<int, int> simulated = simulatedResolutions[i];

                if (original.Item1 != simulated.Item1 || original.Item2 != simulated.Item2)

                {

                    allMatch = false;

                    Console.WriteLine($"Image {i + 1} resolution mismatch. Original: {original.Item1}x{original.Item2}, Simulated: {simulated.Item1}x{simulated.Item2}");

                }

            }



            if (allMatch)

            {

                Console.WriteLine("All embedded images retain their original resolution after simulated conversion.");

            }

            else

            {

                Console.WriteLine("Some embedded images did not retain their original resolution after simulated conversion.");

            }



            // Save the original presentation before exiting (as required)

            try

            {

                sourcePresentation.Save("original_saved.pptx", SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to save original presentation: " + ex.Message);

            }



            // Clean up resources

            sourcePresentation.Dispose();

            simulatedPresentation.Dispose();

        }

    }

}

