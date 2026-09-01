// -----------------------------------------------------------------------------

// Tested and verified with Aspose.Slides for .NET 26.8.0.
// Example: Update hyperlink URLs to HTTPS using C# and Aspose.Slides

//

// Description:

// Demonstrates how to scan all slides, shapes, and text portions in a PowerPoint

// presentation and replace any hyperlink that starts with "http://" with an

// equivalent "https://" URL. The example loads a PPTX file, updates the links,

// and saves the modified presentation using Aspose.Slides for .NET.

// This pattern can be used to enforce secure links in PPTX files programmatically.

//

// Keywords:

// C#, Aspose.Slides, PowerPoint, PPTX, Hyperlink, HTTPS, URL conversion, Presentation automation, Office Open XML

//

// Use Cases:

// - Convert insecure http hyperlinks to secure https in existing presentations.

// - Enforce corporate security policies on PowerPoint files automatically.

// - Build .NET utilities for bulk processing of PPTX documents.

// - Integrate hyperlink validation and correction into document workflows.

// -----------------------------------------------------------------------------



using System;

using System.IO;

using Aspose.Slides;

using Aspose.Slides.Export;



namespace UpdateHyperlinks

{

    class Program

    {

        static void Main(string[] args)

        {

            // Input and output file paths

            string inputPath = "input.pptx";

            string outputPath = "output.pptx";



            // Verify input file exists

            if (!File.Exists(inputPath))

            {

                Console.WriteLine("Input file does not exist.");

                return;

            }



            Presentation presentation = null;

            try

            {

                // Load the presentation

                presentation = new Presentation(inputPath);

            }

            catch (Exception ex)

            {

                // Handle unsupported format or loading errors

                Console.WriteLine("Failed to load presentation: " + ex.Message);

                // Format not supported

                return;

            }



            // Iterate through all slides and shapes to update hyperlink URLs to HTTPS

            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)

            {

                ISlide slide = presentation.Slides[slideIndex];

                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)

                {

                    IShape shape = slide.Shapes[shapeIndex];

                    if (shape is IAutoShape)

                    {

                        IAutoShape autoShape = (IAutoShape)shape;

                        if (autoShape.TextFrame != null)

                        {

                            for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)

                            {

                                IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                                for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)

                                {

                                    IPortion portion = paragraph.Portions[portionIndex];

                                    IHyperlink existingLink = portion.PortionFormat.HyperlinkClick;

                                    if (existingLink != null && !string.IsNullOrEmpty(existingLink.ExternalUrl))

                                    {

                                        string url = existingLink.ExternalUrl;

                                        if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))

                                        {

                                            string httpsUrl = "https://" + url.Substring(7);

                                            try

                                            {

                                                IHyperlinkManager manager = portion.PortionFormat.HyperlinkManager;

                                                manager.SetExternalHyperlinkClick(httpsUrl);

                                            }

                                            catch (Exception linkEx)

                                            {

                                                // Handle external URL setting exception

                                                Console.WriteLine("Failed to set HTTPS hyperlink: " + linkEx.Message);

                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }



            // Save the updated presentation

            try

            {

                presentation.Save(outputPath, SaveFormat.Pptx);

            }

            catch (Exception saveEx)

            {

                // Handle save errors

                Console.WriteLine("Failed to save presentation: " + saveEx.Message);

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

