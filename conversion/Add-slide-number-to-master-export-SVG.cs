// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add slide number to master export SVG using C#

//

// Description:

// Demonstrates how to enable slide number placeholders on a master slide and

// export each slide of a PowerPoint presentation to separate SVG files using

// Aspose.Slides for .NET. The example also shows how to create a new presentation

// when an input file is not found, and how to save the modified presentation.

// This pattern can be used to automate slide numbering and SVG conversion in

// .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Slide Number, Master Slide,

// Export, Presentation Processing, Office Automation

//

// Use Cases:

// - Add slide numbers to master slide before exporting slides as SVG.

// - Build C# tools for batch conversion of PPTX slides to SVG format.

// - Generate or transform PPTX files with slide numbering in .NET applications.

// - Validate and automate presentation workflows prior to publishing.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Define directories and file paths

        string dataDir = "Data";

        if (!Directory.Exists(dataDir))

        {

            Directory.CreateDirectory(dataDir);

        }



        string inputPath = Path.Combine(dataDir, "input.pptx");

        string outputDir = Path.Combine(dataDir, "output");

        if (!Directory.Exists(outputDir))

        {

            Directory.CreateDirectory(outputDir);

        }



        // Load existing presentation or create a new one

        Presentation pres = null;

        try

        {

            if (File.Exists(inputPath))

            {

                pres = new Presentation(inputPath);

            }

            else

            {

                pres = new Presentation();

                // Add a blank slide to the new presentation

                pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

            }

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error loading or creating presentation: " + ex.Message);

            return;

        }



        // Enable slide number placeholder on the master slide

        try

        {

            IMasterSlideHeaderFooterManager masterHeaderFooter = pres.Masters[0].HeaderFooterManager;

            masterHeaderFooter.SetSlideNumberAndChildSlideNumbersVisibility(true);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error setting slide number placeholder: " + ex.Message);

        }



        // Export each slide to SVG

        for (int i = 0; i < pres.Slides.Count; i++)

        {

            string svgPath = Path.Combine(outputDir, $"slide_{i + 1}.svg");

            try

            {

                using (FileStream fs = new FileStream(svgPath, FileMode.Create, FileAccess.Write))

                {

                    pres.Slides[i].WriteAsSvg(fs);

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine($"Error exporting slide {i + 1} to SVG: " + ex.Message);

            }

        }



        // Save the modified presentation

        string outputPptx = Path.Combine(outputDir, "result.pptx");

        try

        {

            pres.Save(outputPptx, SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }

        finally

        {

            pres.Dispose();

        }

    }

}

