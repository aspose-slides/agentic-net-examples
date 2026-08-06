// -----------------------------------------------------------------------------
// Example: Assign unique tag to smartart node using C#
//
// Description:
// Demonstrates how to assign a unique tag to each SmartArt node in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds an Organization Chart SmartArt diagram, assigns a distinct
// tag (stored in the shape's AlternativeText) to every node, builds a mapping
// of tags to node indices, serializes this mapping to a JSON file, and saves the
// presentation. This pattern can be used to embed metadata within SmartArt
// elements and export it for downstream processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Tag, AlternativeText,
// JSON, Mapping, Presentation Processing, Office Automation
//
// Use Cases:
// - Embed and export custom metadata for SmartArt nodes.
// - Automate tagging of SmartArt elements in bulk PowerPoint files.
// - Generate JSON mappings for integration with external systems.
// - Validate and track SmartArt node identities during presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtTagExporter
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPptx = "SmartArtWithTags.pptx";
            string outputJson = "SmartArtTagMapping.json";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

                // Dictionary to hold tag mapping
                Dictionary<string, int> tagMapping = new Dictionary<string, int>();

                // Assign unique tags to each node
                int nodeIndex = 0;
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    // Each node may have multiple shapes; use the first shape
                    if (node.Shapes.Count > 0)
                    {
                        // Set AlternativeText as a tag
                        node.Shapes[0].AlternativeText = "Tag" + nodeIndex;
                        tagMapping.Add("Tag" + nodeIndex, nodeIndex);
                    }
                    nodeIndex++;
                }

                // Serialize mapping to JSON
                string json = JsonSerializer.Serialize(tagMapping, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputJson, json);

                // Save the presentation
                presentation.Save(outputPptx, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
