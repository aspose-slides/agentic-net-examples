// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Test font fallback collection count using C#

//

// Description:

// Demonstrates how to create a presentation, add specific font fallback rules,

// verify the collection count, and save the file using Aspose.Slides for .NET.

// This standalone console example shows the essential steps for managing

// font fallback collections in PowerPoint files.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Font, Fallback, Collection,

// Presentation Processing, Office Automation, Testing

//

// Use Cases:

// - Verify that font fallback rules are correctly added to a presentation.

// - Build automated tests for font fallback configurations.

// - Create utilities that manipulate font fallback settings in PPTX files.

// - Ensure presentation compatibility across different language scripts.

// -----------------------------------------------------------------------------

using System;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Example

{

    class Program

    {

        static void Main()

        {

            // Create a new presentation

            using (Presentation presentation = new Presentation())

            {

                // Retrieve the FontFallBack rules collection

                IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;



                // Add expected rules

                rules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                rules.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho"));



                // Assert that the collection contains the expected number of rules

                int expectedCount = 2;

                if (rules.Count != expectedCount)

                {

                    throw new Exception("FontFallBackRulesCollection count mismatch. Expected " + expectedCount + " but was " + rules.Count);

                }



                // Save the presentation before exiting

                presentation.Save("FontFallbackTest.pptx", SaveFormat.Pptx);

            }

        }

    }

}

