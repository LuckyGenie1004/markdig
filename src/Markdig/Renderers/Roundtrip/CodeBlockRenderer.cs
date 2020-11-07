// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;
using System.Collections.Generic;

namespace Markdig.Renderers.Roundtrip
{
    /// <summary>
    /// An Normalize renderer for a <see cref="CodeBlock"/> and <see cref="FencedCodeBlock"/>.
    /// </summary>
    /// <seealso cref="NormalizeObjectRenderer{CodeBlock}" />
    public class CodeBlockRenderer : RoundtripObjectRenderer<CodeBlock>
    {
        public bool OutputAttributesOnPre { get; set; }

        protected override void Write(RoundtripRenderer renderer, CodeBlock obj)
        {
            renderer.RenderLinesBefore(obj);
            if (obj is FencedCodeBlock fencedCodeBlock)
            {
                renderer.Write(obj.WhitespaceBefore);
                var opening = new string(fencedCodeBlock.FencedChar, fencedCodeBlock.OpeningFencedCharCount);
                renderer.Write(opening);

                if (!fencedCodeBlock.WhitespaceAfterFencedChar.IsEmpty)
                {
                    renderer.Write(fencedCodeBlock.WhitespaceAfterFencedChar);
                }
                if (fencedCodeBlock.Info != null)
                {
                    renderer.Write(fencedCodeBlock.UnescapedInfo);
                }
                if (!fencedCodeBlock.WhitespaceAfterInfo.IsEmpty)
                {
                    renderer.Write(fencedCodeBlock.WhitespaceAfterInfo);
                }
                if (!string.IsNullOrEmpty(fencedCodeBlock.Arguments))
                {
                    renderer.Write(fencedCodeBlock.UnescapedArguments);
                }
                if (!fencedCodeBlock.WhitespaceAfterArguments.IsEmpty)
                {
                    renderer.Write(fencedCodeBlock.WhitespaceAfterArguments);
                }

                /* TODO do we need this causes a empty space and would render html attributes to markdown.
                var attributes = obj.TryGetAttributes();
                if (attributes != null)
                {
                    renderer.Write(" ");
                    renderer.Write(attributes);
                }
                */
                renderer.WriteLine(fencedCodeBlock.InfoNewline);

                renderer.WriteLeafRawLines(obj);

                renderer.Write(fencedCodeBlock.WhitespaceBeforeClosingFence);
                var closing = new string(fencedCodeBlock.FencedChar, fencedCodeBlock.ClosingFencedCharCount);
                renderer.Write(closing);
                if (!string.IsNullOrEmpty(closing))
                {
                    // See example 207: "> ```\nfoo\n```"
                    renderer.WriteLine(obj.Newline);
                }
                renderer.Write(obj.WhitespaceAfter);
            }
            else
            {
                var indents = new List<string>();
                foreach (var cbl in obj.CodeBlockLines)
                {
                    indents.Add(cbl.BeforeWhitespace.ToString());
                }
                renderer.PushIndent(indents);
                WriteLeafRawLines(renderer, obj);
                renderer.PopIndent();
                
                // ignore block newline, as last line references it
            }

            renderer.RenderLinesAfter(obj);
        }

        public void WriteLeafRawLines(RoundtripRenderer renderer, LeafBlock leafBlock)
        {
            if (leafBlock.Lines.Lines != null)
            {
                var lines = leafBlock.Lines;
                var slices = lines.Lines;
                for (int i = 0; i < lines.Count; i++)
                {
                    var slice = slices[i].Slice;
                    renderer.Write(ref slices[i].Slice);
                    renderer.WriteLine(slice.Newline);
                }
            }
        }
    }
}