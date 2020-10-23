// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Helpers;
using Markdig.Syntax;
using System.Diagnostics;

namespace Markdig.Parsers
{
    /// <summary>
    /// A block parser for a <see cref="QuoteBlock"/>.
    /// </summary>
    /// <seealso cref="BlockParser" />
    public class QuoteBlockParser : BlockParser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuoteBlockParser"/> class.
        /// </summary>
        public QuoteBlockParser()
        {
            OpeningCharacters = new[] {'>'};
        }

        public override BlockState TryOpen(BlockProcessor processor)
        {
            if (processor.IsCodeIndent)
            {
                return BlockState.None;
            }

            var sourcePosition = processor.Start;

            // 5.1 Block quotes 
            // A block quote marker consists of 0-3 spaces of initial indent, plus (a) the character > together with a following space, or (b) a single character > not followed by a space.
            var quoteChar = processor.CurrentChar;
            var column = processor.Column;
            var c = processor.NextChar();

            var quoteBlock = new QuoteBlock(this)
            {
                QuoteChar = quoteChar,
                Column = column,
                Span = new SourceSpan(sourcePosition, processor.Line.End),
                LinesBefore = processor.UseLinesBefore()
            };
            StringSlice afterWhitespace = StringSlice.Empty;
            if (processor.Line.IsEmptyOrWhitespace())
            {
                processor.Line.TrimStart();
                afterWhitespace = new StringSlice(processor.Line.Text, sourcePosition + 1, processor.Line.End);
            }
            quoteBlock.QuoteLines.Add(new QuoteBlock.QuoteLine
            {
                BeforeWhitespace = processor.PopBeforeWhitespace(sourcePosition - 1),
                AfterWhitespace = afterWhitespace,
                QuoteChar = true,
                Newline = processor.Line.Newline,
            });
            processor.NewBlocks.Push(quoteBlock);
            processor.WhitespaceStart = sourcePosition + 1;
            return BlockState.Continue;
        }

        public override BlockState TryContinue(BlockProcessor processor, Block block)
        {
            if (processor.IsCodeIndent)
            {
                return BlockState.None;
            }

            var quote = (QuoteBlock) block;
            var sourcePosition = processor.Start;

            // 5.1 Block quotes 
            // A block quote marker consists of 0-3 spaces of initial indent, plus (a) the character > together with a following space, or (b) a single character > not followed by a space.
            var c = processor.CurrentChar;
            if (c != quote.QuoteChar)
            {
                if (processor.IsBlankLine)
                {
                    return BlockState.BreakDiscard;
                }
                else
                {
                    quote.QuoteLines.Add(new QuoteBlock.QuoteLine
                    {
                        QuoteChar = false,
                        BeforeWhitespace = processor.PopBeforeWhitespace(sourcePosition - 1),
                        Newline = processor.Line.Newline,
                    });
                    return BlockState.None;
                }
            }
            processor.NextChar(); // Skip quote marker char
            StringSlice afterWhitespace = StringSlice.Empty;
            if (processor.Line.IsEmptyOrWhitespace())
            {
                processor.Line.TrimStart();
                afterWhitespace = new StringSlice(processor.Line.Text, sourcePosition + 1, processor.Line.End);
            }
            quote.QuoteLines.Add(new QuoteBlock.QuoteLine
            {
                QuoteChar = true,
                BeforeWhitespace = processor.PopBeforeWhitespace(sourcePosition - 1),
                AfterWhitespace = afterWhitespace,
                Newline = processor.Line.Newline,
            });

            processor.WhitespaceStart = processor.Start;
            block.UpdateSpanEnd(processor.Line.End);
            return BlockState.Continue;
        }
    }
}