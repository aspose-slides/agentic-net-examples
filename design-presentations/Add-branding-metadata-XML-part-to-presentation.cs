// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add branding metadata XML part to presentation using C#

//

// Description:

// Demonstrates how to add branding metadata XML part to a PowerPoint presentation 

// using C# and Aspose.Slides for .NET. The example loads an existing PPTX file 

// (or creates a new one if it does not exist), inserts a custom XML part that 

// contains branding information, and saves the modified presentation.

// This pattern can be used to embed custom metadata into PPTX files for 

// downstream processing, compliance, or branding purposes.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Branding, Metadata, Part, 

// Presentation, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding branding metadata XML part to presentations.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides.Export;



namespace AddBrandingMetadata

{

    class Program

    {

        static void Main()

        {

            // Paths for input and output presentations

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Branding metadata as XML string

            string brandingXml = "<Branding><Company>MyCompany</Company><Product>MyProduct</Product></Branding>";



            try

            {

                // Load existing presentation if it exists; otherwise create a new one

                Aspose.Slides.Presentation presentation;

                if (File.Exists(inputPath))

                {

                    presentation = new Aspose.Slides.Presentation(inputPath);

                }

                else

                {

                    presentation = new Aspose.Slides.Presentation();

                }



                // Add custom XML part containing branding metadata

                Aspose.Slides.ICustomData customData = presentation.CustomData;

                Aspose.Slides.ICustomXmlPartCollection xmlParts = customData.CustomXmlParts;

                xmlParts.Add(brandingXml);



                // Save the presentation

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            }

            catch (NotSupportedException)

            {

                // Format not supported

                Console.WriteLine("The specified file format is not supported.");

            }

            catch (Exception ex)

            {

                // Handle other exceptions (e.g., file I/O, Aspose.Slides errors)

                Console.WriteLine("An error occurred: " + ex.Message);

            }

        }

    }

}

