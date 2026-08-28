// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Create comment density heatmap dashboard using C#

//

// Description:

// Demonstrates how to generate a comment density heatmap dashboard for a PowerPoint

// presentation using C# and Aspose.Slides for .NET. The example loads a PPTX file,

// calculates the number of comments on each slide, maps comment density to a red‑tone

// heat‑map background, and saves the resulting presentation. This pattern can be used

// to visualize comment distribution across slides in automated workflows.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Comment, Density, Heatmap,

// Dashboard, Presentation Processing, Office Automation

//

// Use Cases:

// - Visualize comment density across slides as a heat‑map.

// - Automate creation of presentation dashboards highlighting review activity.

// - Integrate comment analysis into .NET PowerPoint processing tools.

// - Generate reports for stakeholders to identify heavily commented slides.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using System.Drawing;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace CommentDensityDashboard

{

    public class Program

    {

        public static void Main(string[] args)

        {

            // Input presentation path

            string inputPath = "input.pptx";

            if (args.Length > 0)

            {

                inputPath = args[0];

            }



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            // Load the presentation with exception handling for unsupported formats

            Aspose.Slides.Presentation presentation = null;

            try

            {

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Aspose.Slides.PptxUnsupportedFormatException)

            {

                // Format not supported: PPTX

                Console.WriteLine("The file format is not supported (PPTX).");

                return;

            }

            catch (Aspose.Slides.PptUnsupportedFormatException)

            {

                // Format not supported: PPT

                Console.WriteLine("The file format is not supported (PPT).");

                return;

            }



            // Determine the maximum number of comments on any slide

            int maxComments = 0;

            int slideCount = presentation.Slides.Count;

            for (int i = 0; i < slideCount; i++)

            {

                Aspose.Slides.ISlide slide = presentation.Slides[i];

                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                int commentCount = comments.Length;

                if (commentCount > maxComments)

                {

                    maxComments = commentCount;

                }

            }



            // Avoid division by zero

            if (maxComments == 0)

            {

                maxComments = 1;

            }



            // Apply a heat‑map background color based on comment density

            for (int i = 0; i < slideCount; i++)

            {

                Aspose.Slides.ISlide slide = presentation.Slides[i];

                Aspose.Slides.IComment[] comments = slide.GetSlideComments(null);

                int commentCount = comments.Length;



                // Compute intensity (0.0 to 1.0)

                float intensity = (float)commentCount / (float)maxComments;



                // Map intensity to a red color (more comments = deeper red)

                int red = 255;

                int green = (int)(255 * (1.0f - intensity));

                int blue = (int)(255 * (1.0f - intensity));

                Color heatColor = Color.FromArgb(red, green, blue);



                // Set slide background to solid fill with the heat color

                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;

                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                slide.Background.FillFormat.SolidFillColor.Color = heatColor;

            }



            // Save the modified presentation

            string outputPath = "CommentDensityHeatmap.pptx";

            try

            {

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Heat‑map dashboard saved to: " + outputPath);

            }

            finally

            {

                // Ensure resources are released

                if (presentation != null)

                {

                    presentation.Dispose();

                }

            }

        }

    }

}

