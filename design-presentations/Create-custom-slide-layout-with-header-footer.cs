// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create custom slide layout with header footer using C#

//

// Description:

// Demonstrates how to create a custom slide layout that includes header, footer,

// and a content placeholder using C# and Aspose.Slides for .NET. The example

// creates a new presentation, defines a custom layout on the master slide,

// configures footer and date-time placeholders, adds a content placeholder,

// inserts a slide based on this layout, and saves the result as a PPTX file.

// This pattern can be used to automate PowerPoint layout creation and

// manipulation in .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Slide Layout, Header,

// Footer, Content Placeholder, Presentation Processing, Office Automation

//

// Use Cases:

// - Automate creation of custom slide layouts with header/footer in PowerPoint.

// - Build .NET tools for generating or modifying PPTX files with predefined

//   layouts.

// - Integrate custom slide designs into presentation generation workflows.

// - Validate and test slide layout configurations before deployment.

// -----------------------------------------------------------------------------



using System;

using Aspose.Slides;

using Aspose.Slides.Export;



class Program

{

    static void Main()

    {

        // Create a new presentation

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();



        // Get the first master slide

        Aspose.Slides.IMasterSlide master = presentation.Masters[0];



        // Add a custom layout slide with header, footer, and content placeholder

        Aspose.Slides.ILayoutSlide customLayout = master.LayoutSlides.Add(Aspose.Slides.SlideLayoutType.Custom, "HeaderFooterContentLayout");



        // Configure footer and date-time placeholders on the layout

        Aspose.Slides.ILayoutSlideHeaderFooterManager layoutHeaderFooter = customLayout.HeaderFooterManager;

        layoutHeaderFooter.SetFooterAndChildFootersVisibility(true);

        layoutHeaderFooter.SetFooterAndChildFootersText("Sample Footer");

        layoutHeaderFooter.SetDateTimeAndChildDateTimesVisibility(true);

        layoutHeaderFooter.SetDateTimeAndChildDateTimesText(DateTime.Now.ToString("yyyy-MM-dd"));



        // Add a content placeholder to the layout

        Aspose.Slides.IAutoShape contentPlaceholder = customLayout.PlaceholderManager.AddContentPlaceholder(50f, 100f, 600f, 300f);

        contentPlaceholder.AddTextFrame("Content goes here");



        // Add a new slide based on the custom layout

        Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(customLayout);



        // Save the presentation

        string outputPath = "CustomLayoutPresentation.pptx";

        try

        {

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        }

        catch (Exception ex)

        {

            // Handle exceptions such as unsupported format

            Console.WriteLine("Error saving presentation: " + ex.Message);

        }

    }

}

