// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add fade spin animation to chart using C#

//

// Description:

// Demonstrates how to add fade and spin animations to a chart using C# and 

// Aspose.Slides for .NET. The example shows the required 

// presentation-processing steps for PowerPoint files and produces the 

// requested output in a standalone console application. Developers can use 

// this pattern to automate PPTX workflows, validate results, or integrate 

// presentation logic into .NET applications.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Fade, Spin, Animation, Chart, 

// Presentation Processing, Office Automation

//

// Use Cases:

// - Automate adding fade and spin animations to charts.

// - Build C# tools for PowerPoint presentation processing.

// - Generate or transform PPTX files with animated charts in .NET applications.

// - Validate presentation workflows before publishing or integration.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Charts;

using Aspose.Slides.Animation;

using Aspose.Slides.Export;



namespace AddFadeSpinAnimationToChart

{

    class Program

    {

        static void Main(string[] args)

        {

            string inputPath = "template.pptx";

            Presentation presentation = null;

            try

            {

                if (File.Exists(inputPath))

                {

                    presentation = new Presentation(inputPath);

                }

                else

                {

                    presentation = new Presentation();

                }



                ISlide slide = presentation.Slides[0];



                // Add a chart to the slide

                IChart chart = slide.Shapes.AddChart(

                    ChartType.ClusteredColumn, 50, 50, 400, 300);



                // Add Fade effect to the chart

                slide.Timeline.MainSequence.AddEffect(

                    chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);



                // Add Spin effect to the chart

                slide.Timeline.MainSequence.AddEffect(

                    chart, EffectChartMajorGroupingType.BySeries, 0,

                    EffectType.Spin, EffectSubtype.None, EffectTriggerType.AfterPrevious);



                // Save the presentation

                presentation.Save("FadeSpinChart.pptx", SaveFormat.Pptx);

            }

            catch (Exception ex)

            {

                // Handle errors such as unsupported format

                Console.WriteLine("Error: " + ex.Message);

            }

            finally

            {

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

