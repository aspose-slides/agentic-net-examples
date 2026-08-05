// -----------------------------------------------------------------------------
// Example: Set first slide number and custom start using C#
//
// Description:
// Demonstrates how to set a custom first slide number in a PowerPoint presentation
// using Aspose.Slides for .NET. The example creates a new presentation, assigns a
// custom starting slide number, and saves the file as PPTX. This pattern can be
// used to control slide numbering when merging or reordering slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, First Slide Number, Custom Start,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Set a custom starting slide number for newly created presentations.
// - Adjust slide numbering after inserting or removing slides.
// - Automate slide numbering in batch processing of PPTX files.
// - Ensure correct slide numbers when combining multiple presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetFirstSlideNumberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "CustomFirstSlideNumber.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Set the first slide number to a custom start value (e.g., 5)
                presentation.FirstSlideNumber = 5;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
