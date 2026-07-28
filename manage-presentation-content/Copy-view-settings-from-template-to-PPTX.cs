// -----------------------------------------------------------------------------
// Example: Copy view settings from template to PPTX using C#
//
// Description:
// Demonstrates how to copy view settings from template to PPTX using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Copy, View, Settings, Template, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate copy view settings from template to PPTX.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CopyViewSettings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string templatePath = "template.pptx";
            string[] targetPaths = new string[] { "target1.pptx", "target2.pptx" };

            // Verify template exists
            if (!File.Exists(templatePath))
            {
                Console.WriteLine($"Template file not found: {templatePath}");
                return;
            }

            try
            {
                // Load template presentation
                using (Presentation templatePres = new Presentation(templatePath))
                {
                    IViewProperties templateView = templatePres.ViewProperties;

                    foreach (string targetPath in targetPaths)
                    {
                        // Verify target file exists
                        if (!File.Exists(targetPath))
                        {
                            Console.WriteLine($"Target file not found, skipping: {targetPath}");
                            continue;
                        }

                        try
                        {
                            // Load target presentation
                            using (Presentation targetPres = new Presentation(targetPath))
                            {
                                IViewProperties targetView = targetPres.ViewProperties;

                                // Copy view settings
                                targetView.LastView = templateView.LastView;
                                targetView.ShowComments = templateView.ShowComments;
                                targetView.GridSpacing = templateView.GridSpacing;

                                // Slide view properties
                                targetView.SlideViewProperties.Scale = templateView.SlideViewProperties.Scale;
                                targetView.SlideViewProperties.VariableScale = templateView.SlideViewProperties.VariableScale;

                                // Notes view properties
                                targetView.NotesViewProperties.Scale = templateView.NotesViewProperties.Scale;
                                targetView.NotesViewProperties.VariableScale = templateView.NotesViewProperties.VariableScale;

                                // Save the modified presentation
                                targetPres.Save(targetPath, SaveFormat.Pptx);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle unsupported format or other errors for this target file
                            Console.WriteLine($"Error processing {targetPath}: {ex.Message}");
                            // Format not supported comment:
                            // The file format may not be supported by Aspose.Slides.
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors related to loading the template or other unexpected issues
                Console.WriteLine($"Error loading template: {ex.Message}");
            }
        }
    }
}
