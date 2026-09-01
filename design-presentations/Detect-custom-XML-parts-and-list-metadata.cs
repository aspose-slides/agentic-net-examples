// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Detect custom XML parts and list metadata using C#

//

// Description:

// Demonstrates how to detect custom XML parts embedded in a PowerPoint presentation

// and list their metadata and XML content using C# and Aspose.Slides for .NET.

// The example loads a PPTX file, enumerates all custom XML parts, prints their

// ItemId and XML string, and saves the presentation unchanged.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Detect, Custom XML Parts, List Metadata,

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate detection of custom XML parts and extraction of their data.

// - Build C# utilities for PowerPoint presentation analysis and validation.

// - Integrate custom XML handling into .NET applications that process PPTX files.

// - Verify and audit embedded XML content before publishing or further transformation.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace DetectCustomXmlParts

{

    class Program

    {

        static void Main(string[] args)

        {

            // Path to the presentation file

            string presentationPath = "sample.pptx";



            // Verify that the file exists

            if (!File.Exists(presentationPath))

            {

                Console.WriteLine("File not found: " + presentationPath);

                return;

            }



            try

            {

                // Load the presentation

                using (Presentation presentation = new Presentation(presentationPath))

                {

                    // Retrieve all custom XML parts

                    ICustomXmlPart[] customParts = presentation.AllCustomXmlParts;



                    if (customParts.Length == 0)

                    {

                        Console.WriteLine("No custom XML parts found.");

                    }

                    else

                    {

                        Console.WriteLine("Custom XML parts found: " + customParts.Length);

                        for (int i = 0; i < customParts.Length; i++)

                        {

                            ICustomXmlPart part = customParts[i];

                            Console.WriteLine($"Part {i + 1}:");

                            Console.WriteLine("  ItemId: " + part.ItemId);

                            Console.WriteLine("  XML Content:");

                            Console.WriteLine(part.XmlAsString);

                        }

                    }



                    // Save the presentation before exiting

                    presentation.Save(presentationPath, SaveFormat.Pptx);

                }

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException ex)

            {

                Console.WriteLine("Unsupported PPTX format: " + ex.Message);

            }

            catch (Aspose.Slides.PptUnsupportedFormatException ex)

            {

                Console.WriteLine("Unsupported PPT format: " + ex.Message);

            }

            catch (Exception ex)

            {

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

