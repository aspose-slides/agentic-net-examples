// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Add analytics script to HTML5 presentation using C#

//

// Description:

// Demonstrates how to convert a PowerPoint presentation to HTML5 using Aspose.Slides for .NET,

// then embed a custom analytics JavaScript snippet into the generated HTML file. The example

// includes loading the PPTX, configuring Html5Options, saving as HTML5, and inserting the script

// before the closing </body> tag. This pattern can be used to automate PPTX to HTML5 conversion

// with analytics integration.

//

// Keywords:

// C#, PowerPoint, PPTX, Aspose.Slides for .NET, HTML5, Analytics, JavaScript, Script Injection,

// Presentation Conversion, Office Automation

//

// Use Cases:

// - Convert PPTX files to HTML5 presentations with embedded analytics.

// - Add custom JavaScript tracking to generated HTML5 slides.

// - Build .NET tools for automated presentation publishing workflows.

// - Integrate analytics reporting into PowerPoint-to-HTML5 pipelines.

// -----------------------------------------------------------------------------

using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace Html5ConversionWithAnalytics

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "presentation.pptx";

            string outputHtmlPath = "presentation.html";



            // Verify that the input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist: " + inputPath);

                return;

            }



            Aspose.Slides.Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Aspose.Slides.Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or loading errors

                Console.WriteLine("Failed to load presentation. Possible unsupported format.");

                Console.WriteLine("Error: " + ex.Message);

                return;

            }



            // Set HTML5 export options

            Aspose.Slides.Export.Html5Options html5Options = new Aspose.Slides.Export.Html5Options();

            html5Options.AnimateShapes = true;

            html5Options.AnimateTransitions = true;

            // Ensure JavaScript links are not skipped so we can embed our script

            html5Options.SkipJavaScriptLinks = false;



            try

            {

                // Save the presentation as HTML5

                presentation.Save(outputHtmlPath, Aspose.Slides.Export.SaveFormat.Html5, html5Options);

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to save presentation as HTML5.");

                Console.WriteLine("Error: " + ex.Message);

                presentation.Dispose();

                return;

            }



            // Embed custom analytics script into the generated HTML

            try

            {

                string htmlContent = File.ReadAllText(outputHtmlPath);

                string analyticsScript = "<script type=\"text/javascript\">\n" +

                                         "    // Custom analytics to track slide views\n" +

                                         "    document.addEventListener('DOMContentLoaded', function() {\n" +

                                         "        var slides = document.querySelectorAll('.slide');\n" +

                                         "        slides.forEach(function(slide, index) {\n" +

                                         "            slide.addEventListener('click', function() {\n" +

                                         "                console.log('Slide viewed: ' + (index + 1));\n" +

                                         "                // Insert analytics reporting code here\n" +

                                         "            });\n" +

                                         "        });\n" +

                                         "    });\n" +

                                         "</script>\n";



                // Insert the script before the closing </body> tag

                int bodyCloseIndex = htmlContent.LastIndexOf("</body>", StringComparison.OrdinalIgnoreCase);

                if (bodyCloseIndex >= 0)

                {

                    htmlContent = htmlContent.Insert(bodyCloseIndex, analyticsScript);

                    File.WriteAllText(outputHtmlPath, htmlContent);

                }

                else

                {

                    // If </body> not found, append the script at the end

                    File.AppendAllText(outputHtmlPath, analyticsScript);

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine("Failed to embed analytics script.");

                Console.WriteLine("Error: " + ex.Message);

            }



            // Dispose the presentation object

            presentation.Dispose();



            Console.WriteLine("Conversion completed successfully.");

        }

    }

}

