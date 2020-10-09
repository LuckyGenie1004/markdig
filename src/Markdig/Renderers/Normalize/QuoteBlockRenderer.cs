// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;
using System.Collections.Generic;

namespace Markdig.Renderers.Normalize
{
    /// <summary>
    /// A Normalize renderer for a <see cref="QuoteBlock"/>.
    /// </summary>
    /// <seealso cref="NormalizeObjectRenderer{QuoteBlock}" />
    public class QuoteBlockRenderer : NormalizeObjectRenderer<QuoteBlock>
    {
        protected override void Write(NormalizeRenderer renderer, QuoteBlock quoteBlock)
        {
            renderer.RenderLinesBefore(quoteBlock);
            renderer.Write(quoteBlock.BeforeWhitespace);

            var indents = new List<string>();
            foreach (var quoteLine in quoteBlock.QuoteLines)
            {
                indents.Add(quoteLine.BeforeWhitespace.ToString() + (quoteLine.QuoteChar ? ">" : "") + quoteLine.AfterWhitespace.ToString());
            }

            renderer.PushIndent(indents);
            renderer.WriteChildren(quoteBlock); 
            renderer.PopIndent();

            renderer.FinishBlock();
            renderer.RenderLinesAfter(quoteBlock);
        }
    }
}