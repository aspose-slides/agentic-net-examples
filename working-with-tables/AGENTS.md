---
name: working-with-tables
description: C# examples for working-with-tables using Aspose.Slides for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - working-with-tables

## Persona

You are a C# developer specializing in PowerPoint processing using Aspose.Slides for .NET,
working within the **working-with-tables** category.

## Scope

- This folder contains examples for **working-with-tables**
- Files are standalone `.cs` examples stored directly in this folder.

## Required Namespaces

- `using System;` (31/31 files)
- `using Aspose.Slides.Export;` (31/31 files)
- `using Aspose.Slides;` (29/31 files)
- `using System.IO;` (17/31 files)
- `using System.Drawing;` (5/31 files)
- `using System.Collections.Generic;` (2/31 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [Add-comment-to-table-cell-and-retrieve](./Add-comment-to-table-cell-and-retrieve.cs) |  | Add comment to table cell and retrieve |
| [Add-hyperlink-to-table-cell-open-webpage](./Add-hyperlink-to-table-cell-open-webpage.cs) |  | Add hyperlink to table cell open webpage |
| [Adjust-table-row-heights-based-on-content](./Adjust-table-row-heights-based-on-content.cs) |  | Adjust table row heights based on content |
| [Align-paragraphs-center-first-row-table](./Align-paragraphs-center-first-row-table.cs) |  | Align paragraphs center first row table |
| [Apply-table-style-and-verify-properties](./Apply-table-style-and-verify-properties.cs) |  | Apply table style and verify properties |
| [Autoadjust-table-columns-to-longest-text](./Autoadjust-table-columns-to-longest-text.cs) |  | Autoadjust table columns to longest text |
| [Copy-table-to-another-slide-preserve-formatting](./Copy-table-to-another-slide-preserve-formatting.cs) |  | Copy table to another slide preserve formatting |
| [Create-presentation-add-slide-and-insert-table](./Create-presentation-add-slide-and-insert-table.cs) |  | Create presentation add slide and insert table |
| [Detect-empty-cells-fill-with-placeholder](./Detect-empty-cells-fill-with-placeholder.cs) |  | Detect empty cells fill with placeholder |
| [Export-presentation-to-PDF-preserve-table-format](./Export-presentation-to-PDF-preserve-table-format.cs) |  | Export presentation to PDF preserve table format |
| [Export-presentation-to-XPS-preserve-borders-shading](./Export-presentation-to-XPS-preserve-borders-shading.cs) |  | Export presentation to XPS preserve borders shading |
| [Handle-out-of-range-column-removal](./Handle-out-of-range-column-removal.cs) |  | Handle out of range column removal |
| [Highlight-cells-with-conditional-formatting](./Highlight-cells-with-conditional-formatting.cs) |  | Highlight cells with conditional formatting |
| [Identify-merged-cells-rowspan-colspan-log](./Identify-merged-cells-rowspan-colspan-log.cs) |  | Identify merged cells rowspan colspan log |
| [Insert-chart-image-into-table-cell](./Insert-chart-image-into-table-cell.cs) |  | Insert chart image into table cell |
| [Insert-png-image-into-cell-keep-ratio](./Insert-png-image-into-cell-keep-ratio.cs) |  | Insert png image into cell keep ratio |
| [Lock-table-aspect-ratio-before-scaling](./Lock-table-aspect-ratio-before-scaling.cs) |  | Lock table aspect ratio before scaling |
| [Merge-cells-two-columns-fourth-row-alignright](./Merge-cells-two-columns-fourth-row-alignright.cs) |  | Merge cells two columns fourth row alignright |
| [Remove-fifth-column-first-slide-adjust-widths](./Remove-fifth-column-first-slide-adjust-widths.cs) |  | Remove fifth column first slide adjust widths |
| [Reorder-table-columns-alphabetically-by-header](./Reorder-table-columns-alphabetically-by-header.cs) |  | Reorder table columns alphabetically by header |
| [Report-table-rows-columns-count-per-slide](./Report-table-rows-columns-count-per-slide.cs) |  | Report table rows columns count per slide |
| [Resize-table-proportionally-to-fit-rectangle](./Resize-table-proportionally-to-fit-rectangle.cs) |  | Resize table proportionally to fit rectangle |
| [Set-all-table-cells-font-size-twelve](./Set-all-table-cells-font-size-twelve.cs) |  | Set all table cells font size twelve |
| [Set-first-row-header-bold-text](./Set-first-row-header-bold-text.cs) |  | Set first row header bold text |
| [Set-header-row-background-gray-export](./Set-header-row-background-gray-export.cs) |  | Set header row background gray export |
| [Set-table-border-style-thickness-dash](./Set-table-border-style-thickness-dash.cs) |  | Set table border style thickness dash |
| [Set-table-cell-padding-five-points](./Set-table-cell-padding-five-points.cs) |  | Set table cell padding five points |
| [Set-table-cell-text-direction-RTL](./Set-table-cell-text-direction-RTL.cs) |  | Set table cell text direction RTL |
| [Set-table-cell-vertical-alignment-middle](./Set-table-cell-vertical-alignment-middle.cs) |  | Set table cell vertical alignment middle |
| [Update-PPTX-modify-cell-at-second-slide](./Update-PPTX-modify-cell-at-second-slide.cs) |  | Update PPTX modify cell at second slide |
| [Validate-all-tables-header-row-before-save](./Validate-all-tables-header-row-before-save.cs) |  | Validate all tables header row before save |

## Category Statistics

- Total examples: 31

## Key API Surface

- `Aspose.Slides.Presentation`
- `Aspose.Slides.Export`
- `Aspose.Slides`
- `Aspose.Slides.ITable`
- `Aspose.Slides.ISlide`
- `Aspose.Slides.Export.SaveFormat.Pptx`
- `Aspose.Slides.PptxUnsupportedFormatException`
- `Aspose.Slides.PptUnsupportedFormatException`
- `Aspose.Slides.ICell`
- `Aspose.Slides.PortionFormat`
- `Aspose.Slides.FillType.Solid`
- `Aspose.Slides.IShape`
- `Aspose.Slides.Hyperlink`
- `Aspose.Slides.ParagraphFormat`
- `Aspose.Slides.IImage`

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
Updated: 2026-04-16
<!-- AUTOGENERATED:END -->