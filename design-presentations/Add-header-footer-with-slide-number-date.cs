// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add header footer with slide number date using C#

//

// Description:

// Demonstrates how to add a custom footer, date, and slide number to each slide

// of a PowerPoint presentation using C# and Aspose.Slides for .NET. The example

// loads an existing PPTX file, configures header/footer visibility and text,

// and saves the updated presentation. This pattern can be used to automate

// PPTX workflows, apply consistent branding, or prepare presentations for

// distribution.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Header, Footer, Slide Number,

// Date, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding custom footer, date, and slide numbers to presentations.

// - Build C# tools for PowerPoint branding and metadata insertion.

// - Generate or modify PPTX files in .NET applications.

// - Validate and standardize presentation layouts before publishing.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace AddHeaderFooter

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



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

                    // Set the current date/time for date-time placeholders (optional)

                    presentation.CurrentDateTime = DateTime.Now;



                    // Iterate through each slide and configure header/footer

                    for (int i = 0; i < presentation.Slides.Count; i++)

                    {

                        ISlide slide = presentation.Slides[i];

                        ISlideHeaderFooterManager headerFooter = slide.HeaderFooterManager;



                        // Ensure footer placeholder is visible and set custom text

                        if (!headerFooter.IsFooterVisible)

                        {

                            headerFooter.SetFooterVisibility(true);

                        }

                        headerFooter.SetFooterText("Custom Footer Text");



                        // Ensure date-time placeholder is visible and set current date

                        if (!headerFooter.IsDateTimeVisible)

                        {

                            headerFooter.SetDateTimeVisibility(true);

                        }

                        headerFooter.SetDateTimeText(DateTime.Now.ToString("D"));



                        // Ensure slide number placeholder is visible

                        if (!headerFooter.IsSlideNumberVisible)

                        {

                            headerFooter.SetSlideNumberVisibility(true);

                        }

                    }



                    // Save the modified presentation

                    presentation.Save(outputPath, SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // The file format is not supported for PPTX

                Console.WriteLine("The input file format is not supported (PPTX).");

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // The file format is not supported for PPT

                Console.WriteLine("The input file format is not supported (PPT).");

            }

            catch (Exception ex)

            {

                // General exception handling

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

