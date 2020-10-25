// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Helpers;
using Markdig.Syntax.Inlines;

namespace Markdig.Parsers.Inlines
{
    /// <summary>
    /// An inline parser for escape characters.
    /// </summary>
    /// <seealso cref="InlineParser" />
    public class EscapeInlineParser : InlineParser
    {
        public EscapeInlineParser()
        {
            OpeningCharacters = new[] {'\\'};
        }

        public override bool Match(InlineProcessor processor, ref StringSlice slice)
        {
            var startPosition = slice.Start;
            // Go to escape character
            var c = slice.NextChar();
            int line;
            int column;
            if (c.IsAsciiPunctuation())
            {
                processor.Inline = new LiteralInline()
                {
                    Content = new StringSlice(slice.Text, slice.Start, slice.Start),
                    Span = { Start = processor.GetSourcePosition(startPosition, out line, out column) },
                    Line = line,
                    Column = column,
                    IsFirstCharacterEscaped = true,
                };
                processor.Inline.Span.End = processor.Inline.Span.Start + 1;
                slice.NextChar();
                return true;
            }

            // A backslash at the end of the line is a [hard line break]:
            if (processor.TrackTrivia)
            {
                if (c == '\n' || c == '\r')
                {
                    var newline = c == '\n' ? Newline.LineFeed : Newline.CarriageReturn;
                    if (c == '\r' && slice.PeekChar() == '\n')
                    {
                        newline = Newline.CarriageReturnLineFeed;
                    }
                    processor.Inline = new LineBreakInline()
                    {
                        IsHard = true,
                        IsBackslash = true,
                        Span = { Start = processor.GetSourcePosition(startPosition, out line, out column) },
                        Line = line,
                        Column = column,
                        Newline = newline
                    };
                    processor.Inline.Span.End = processor.Inline.Span.Start + 1;
                    slice.NextChar();
                    return true;
                }
            }
            else
            {
                if (c == '\n')
                {
                    processor.Inline = new LineBreakInline()
                    {
                        IsHard = true,
                        IsBackslash = true,
                        Span = { Start = processor.GetSourcePosition(startPosition, out line, out column) },
                        Line = line,
                        Column = column
                    };
                    processor.Inline.Span.End = processor.Inline.Span.Start + 1;
                    slice.NextChar();
                    return true;
                }
            }

            return false;
        }
    }
}