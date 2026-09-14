---
name: math-equations
description: C# examples for math-equations using Aspose.Slides for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - math-equations

## Persona

You are a C# developer specializing in PowerPoint processing using Aspose.Slides for .NET,
working within the **math-equations** category.

## Scope

- This folder contains examples for **math-equations**
- Files are standalone `.cs` examples stored directly in this folder.

## Required Namespaces

- `using System;` (27/27 files)
- `using System.IO;` (26/27 files)
- `using System.Text;` (3/27 files)
- `using System.Reflection;` (2/27 files)
- `using System.Collections.Generic;` (2/27 files)
- `using System.Threading;` (1/27 files)
- `using System.Diagnostics;` (1/27 files)
- `using System.Linq;` (1/27 files)
- `using System.Security.Cryptography;` (1/27 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [Add-commandline-arguments-for-mathexport](./Add-commandline-arguments-for-mathexport.cs) |  | Add commandline arguments for mathexport |
| [Check-shapes-for-mathparagraphs-in-PPTX](./Check-shapes-for-mathparagraphs-in-PPTX.cs) |  | Check shapes for mathparagraphs in PPTX |
| [Clone-presentation-in-memory-for-mathml-export](./Clone-presentation-in-memory-for-mathml-export.cs) |  | Clone presentation in memory for mathml export |
| [Confirm-PPTX-mathparagraph-unchanged-after-writeasmathml](./Confirm-PPTX-mathparagraph-unchanged-after-writeasmathml.cs) |  | Confirm PPTX mathparagraph unchanged after writeasmathml |
| [Convert-memorystream-to-utf8-string](./Convert-memorystream-to-utf8-string.cs) |  | Convert memorystream to utf8 string |
| [Ensure-filestream-closed-with-tryfinally](./Ensure-filestream-closed-with-tryfinally.cs) |  | Ensure filestream closed with tryfinally |
| [Export-mathblock-to-mathml-using-memorystream](./Export-mathblock-to-mathml-using-memorystream.cs) |  | Export mathblock to mathml using memorystream |
| [Export-mathml-from-shapes-with-alttext](./Export-mathml-from-shapes-with-alttext.cs) |  | Export mathml from shapes with alttext |
| [Export-mathml-to-UNC-share](./Export-mathml-to-UNC-share.cs) |  | Export mathml to UNC share |
| [Export-mathparagraph-to-mathml-with-filestream](./Export-mathparagraph-to-mathml-with-filestream.cs) |  | Export mathparagraph to mathml with filestream |
| [Generate-mathml-from-PPTX-slides](./Generate-mathml-from-PPTX-slides.cs) |  | Generate mathml from PPTX slides |
| [Get-mathparagraph-from-detected-mathportion](./Get-mathparagraph-from-detected-mathportion.cs) |  | Get mathparagraph from detected mathportion |
| [Implement-retry-logic-for-writeasmathml](./Implement-retry-logic-for-writeasmathml.cs) |  | Implement retry logic for writeasmathml |
| [Iterate-slides-for-mathportion-shapes](./Iterate-slides-for-mathportion-shapes.cs) |  | Iterate slides for mathportion shapes |
| [Load-PPTX-presentation-and-extract-math](./Load-PPTX-presentation-and-extract-math.cs) |  | Load PPTX presentation and extract math |
| [Log-exported-mathml-to-console](./Log-exported-mathml-to-console.cs) |  | Log exported mathml to console |
| [Log-slide-index-shape-and-mathml-path](./Log-slide-index-shape-and-mathml-path.cs) |  | Log slide index shape and mathml path |
| [Log-writeasmathml-exception-for-unsupported-mathblock](./Log-writeasmathml-exception-for-unsupported-mathblock.cs) |  | Log writeasmathml exception for unsupported mathblock |
| [Map-slide-numbers-to-mathml-strings](./Map-slide-numbers-to-mathml-strings.cs) |  | Map slide numbers to mathml strings |
| [Measure-writeasmathml-execution-time](./Measure-writeasmathml-execution-time.cs) |  | Measure writeasmathml execution time |
| [Save-mathml-bytearray-to-XML-with-filestream](./Save-mathml-bytearray-to-XML-with-filestream.cs) |  | Save mathml bytearray to XML with filestream |
| [Select-mathportion-by-variable-using-LINQ](./Select-mathportion-by-variable-using-LINQ.cs) |  | Select mathportion by variable using LINQ |
| [Skip-hidden-slides-during-mathml-export](./Skip-hidden-slides-during-mathml-export.cs) |  | Skip hidden slides during mathml export |
| [Skip-mathblock-on-notsupportedexception](./Skip-mathblock-on-notsupportedexception.cs) |  | Skip mathblock on notsupportedexception |
| [Summarize-slide-mathparagraph-counts-report](./Summarize-slide-mathparagraph-counts-report.cs) |  | Summarize slide mathparagraph counts report |
| [Validate-exported-mathml-against-expected-XML](./Validate-exported-mathml-against-expected-XML.cs) |  | Validate exported mathml against expected XML |
| [Verify-presentation-size-and-checksum-after-export](./Verify-presentation-size-and-checksum-after-export.cs) |  | Verify presentation size and checksum after export |

## Category Statistics

- Total examples: 27

## Key API Surface

- `Aspose.Slides.MathText.MathematicalText`
- `Aspose.Slides`
- `Aspose.Slides.Presentation`
- `Aspose.Slides.IAutoShape`
- `Aspose.Slides.MathText.MathPortion`
- `Aspose.Slides.Export.SaveFormat.Pptx`
- `Aspose.Slides.MathText.IMathParagraph`
- `Aspose.Slides.ISlide`
- `Aspose.Slides.IShape`
- `Aspose.Slides.IParagraph`
- `Aspose.Slides.IPortion`
- `Aspose.Slides.PptxUnsupportedFormatException`
- `Aspose.Slides.MathText.IMathPortion`
- `Aspose.Slides.AutoShape`
- `Aspose.Slides.Export.MathMlExportOptions`

## Common Code Pattern

Most examples follow a pattern similar to:

```csharp
using (Presentation pres = new Presentation("input.pptx"))
{
    // operations
    pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## Category-Specific Tips

- Load presentations using `new Presentation("file.pptx")`.
- Modify slides through the `Slides` collection.
- Save the presentation using `Presentation.Save(...)`.

<!-- AUTOGENERATED:START -->
Updated: 2026-09-14
<!-- AUTOGENERATED:END -->