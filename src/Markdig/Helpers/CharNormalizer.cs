// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System.Collections.Generic;

namespace Markdig.Helpers;

/// <summary>
/// Class used to simplify a unicode char to a simple ASCII string
/// </summary>
public static class CharNormalizer
{
    /// <summary>
    /// Converts a unicode char to a simple ASCII string.
    /// </summary>
    /// <param name="c">The input char.</param>
    /// <returns>The simple ASCII string or null if the char itself cannot be simplified</returns>
    public static string? ConvertToAscii(char c)
    {
        return c >= 160 && CodeToAscii.TryGetValue(c, out string? str) ? str : null;
    }

    // This table was generated by the app UnicodeNormDApp
    private static readonly Dictionary<char, string> CodeToAscii = new(1269)
    {
        {'Ḋ', "D"},
        {'Ḍ', "D"},
        {'È', "E"},
        {'Ē', "E"},
        {'Ḕ', "E"},
        {'ª', "a"},
        {'²', "2"},
        {'³', "3"},
        {'¹', "1"},
        {'º', "o"},
        {'¼', "14"},
        {'½', "12"},
        {'¾', "34"},
        {'À', "A"},
        {'Á', "A"},
        {'Â', "A"},
        {'Ã', "A"},
        {'Ä', "A"},
        {'Å', "A"},
        {'Ç', "C"},
        {'É', "E"},
        {'Ê', "E"},
        {'Ë', "E"},
        {'Ì', "I"},
        {'Í', "I"},
        {'Î', "I"},
        {'Ï', "I"},
        {'Ñ', "N"},
        {'Ò', "O"},
        {'Ó', "O"},
        {'Ô', "O"},
        {'Õ', "O"},
        {'Ö', "O"},
        {'Ù', "U"},
        {'Ú', "U"},
        {'Û', "U"},
        {'Ü', "U"},
        {'Ý', "Y"},
        {'à', "a"},
        {'á', "a"},
        {'â', "a"},
        {'ã', "a"},
        {'ä', "a"},
        {'å', "a"},
        {'ç', "c"},
        {'è', "e"},
        {'é', "e"},
        {'ê', "e"},
        {'ë', "e"},
        {'ì', "i"},
        {'í', "i"},
        {'î', "i"},
        {'ï', "i"},
        {'ñ', "n"},
        {'ò', "o"},
        {'ó', "o"},
        {'ô', "o"},
        {'õ', "o"},
        {'ö', "o"},
        {'ù', "u"},
        {'ú', "u"},
        {'û', "u"},
        {'ü', "u"},
        {'ý', "y"},
        {'ÿ', "y"},
        {'Ā', "A"},
        {'ā', "a"},
        {'Ă', "A"},
        {'ă', "a"},
        {'Ą', "A"},
        {'ą', "a"},
        {'Ć', "C"},
        {'ć', "c"},
        {'Ĉ', "C"},
        {'ĉ', "c"},
        {'Ċ', "C"},
        {'ċ', "c"},
        {'Č', "C"},
        {'č', "c"},
        {'Ď', "D"},
        {'ď', "d"},
        {'ē', "e"},
        {'Ĕ', "E"},
        {'ĕ', "e"},
        {'Ė', "E"},
        {'ė', "e"},
        {'Ę', "E"},
        {'ę', "e"},
        {'Ě', "E"},
        {'ě', "e"},
        {'Ĝ', "G"},
        {'ĝ', "g"},
        {'Ğ', "G"},
        {'ğ', "g"},
        {'Ġ', "G"},
        {'ġ', "g"},
        {'Ģ', "G"},
        {'ģ', "g"},
        {'Ĥ', "H"},
        {'ĥ', "h"},
        {'Ĩ', "I"},
        {'ĩ', "i"},
        {'Ī', "I"},
        {'ī', "i"},
        {'Ĭ', "I"},
        {'ĭ', "i"},
        {'Į', "I"},
        {'į', "i"},
        {'İ', "I"},
        {'Ĳ', "IJ"},
        {'ĳ', "ij"},
        {'Ĵ', "J"},
        {'ĵ', "j"},
        {'Ķ', "K"},
        {'ķ', "k"},
        {'Ĺ', "L"},
        {'ĺ', "l"},
        {'Ļ', "L"},
        {'ļ', "l"},
        {'Ľ', "L"},
        {'ľ', "l"},
        {'Ŀ', "L"},
        {'ŀ', "l"},
        {'Ń', "N"},
        {'ń', "n"},
        {'Ņ', "N"},
        {'ņ', "n"},
        {'Ň', "N"},
        {'ň', "n"},
        {'ŉ', "n"},
        {'Ō', "O"},
        {'ō', "o"},
        {'Ŏ', "O"},
        {'ŏ', "o"},
        {'Ő', "O"},
        {'ő', "o"},
        {'Ŕ', "R"},
        {'ŕ', "r"},
        {'Ŗ', "R"},
        {'ŗ', "r"},
        {'Ř', "R"},
        {'ř', "r"},
        {'Ś', "S"},
        {'ś', "s"},
        {'Ŝ', "S"},
        {'ŝ', "s"},
        {'Ş', "S"},
        {'ş', "s"},
        {'Š', "S"},
        {'š', "s"},
        {'Ţ', "T"},
        {'ţ', "t"},
        {'Ť', "T"},
        {'ť', "t"},
        {'Ũ', "U"},
        {'ũ', "u"},
        {'Ū', "U"},
        {'ū', "u"},
        {'Ŭ', "U"},
        {'ŭ', "u"},
        {'Ů', "U"},
        {'ů', "u"},
        {'Ű', "U"},
        {'ű', "u"},
        {'Ų', "U"},
        {'ų', "u"},
        {'Ŵ', "W"},
        {'ŵ', "w"},
        {'Ŷ', "Y"},
        {'ŷ', "y"},
        {'Ÿ', "Y"},
        {'Ź', "Z"},
        {'ź', "z"},
        {'Ż', "Z"},
        {'ż', "z"},
        {'Ž', "Z"},
        {'ž', "z"},
        {'ſ', "s"},
        {'Ơ', "O"},
        {'ơ', "o"},
        {'Ư', "U"},
        {'ư', "u"},
        {'Ǆ', "DZ"},
        {'ǅ', "Dz"},
        {'ǆ', "dz"},
        {'Ǉ', "LJ"},
        {'ǈ', "Lj"},
        {'ǉ', "lj"},
        {'Ǌ', "NJ"},
        {'ǋ', "Nj"},
        {'ǌ', "nj"},
        {'Ǎ', "A"},
        {'ǎ', "a"},
        {'Ǐ', "I"},
        {'ǐ', "i"},
        {'Ǒ', "O"},
        {'ǒ', "o"},
        {'Ǔ', "U"},
        {'ǔ', "u"},
        {'Ǖ', "U"},
        {'ǖ', "u"},
        {'Ǘ', "U"},
        {'ǘ', "u"},
        {'Ǚ', "U"},
        {'ǚ', "u"},
        {'Ǜ', "U"},
        {'ǜ', "u"},
        {'Ǟ', "A"},
        {'ǟ', "a"},
        {'Ǡ', "A"},
        {'ǡ', "a"},
        {'Ǧ', "G"},
        {'ǧ', "g"},
        {'Ǩ', "K"},
        {'ǩ', "k"},
        {'Ǫ', "O"},
        {'ǫ', "o"},
        {'Ǭ', "O"},
        {'ǭ', "o"},
        {'ǰ', "j"},
        {'Ǳ', "DZ"},
        {'ǲ', "Dz"},
        {'ǳ', "dz"},
        {'Ǵ', "G"},
        {'ǵ', "g"},
        {'Ǹ', "N"},
        {'ǹ', "n"},
        {'Ǻ', "A"},
        {'ǻ', "a"},
        {'Ȁ', "A"},
        {'ȁ', "a"},
        {'Ȃ', "A"},
        {'ȃ', "a"},
        {'Ȅ', "E"},
        {'ȅ', "e"},
        {'Ȇ', "E"},
        {'ȇ', "e"},
        {'Ȉ', "I"},
        {'ȉ', "i"},
        {'Ȋ', "I"},
        {'ȋ', "i"},
        {'Ȍ', "O"},
        {'ȍ', "o"},
        {'Ȏ', "O"},
        {'ȏ', "o"},
        {'Ȑ', "R"},
        {'ȑ', "r"},
        {'Ȓ', "R"},
        {'ȓ', "r"},
        {'Ȕ', "U"},
        {'ȕ', "u"},
        {'Ȗ', "U"},
        {'ȗ', "u"},
        {'Ș', "S"},
        {'ș', "s"},
        {'Ț', "T"},
        {'ț', "t"},
        {'Ȟ', "H"},
        {'ȟ', "h"},
        {'Ȧ', "A"},
        {'ȧ', "a"},
        {'Ȩ', "E"},
        {'ȩ', "e"},
        {'Ȫ', "O"},
        {'ȫ', "o"},
        {'Ȭ', "O"},
        {'ȭ', "o"},
        {'Ȯ', "O"},
        {'ȯ', "o"},
        {'Ȱ', "O"},
        {'ȱ', "o"},
        {'Ȳ', "Y"},
        {'ȳ', "y"},
        {'ʰ', "h"},
        {'ʲ', "j"},
        {'ʳ', "r"},
        {'ʷ', "w"},
        {'ʸ', "y"},
        {'ˡ', "l"},
        {'ˢ', "s"},
        {'ˣ', "x"},
        {';', ";"},
        {'ᴬ', "A"},
        {'ᴮ', "B"},
        {'ᴰ', "D"},
        {'ᴱ', "E"},
        {'ᴳ', "G"},
        {'ᴴ', "H"},
        {'ᴵ', "I"},
        {'ᴶ', "J"},
        {'ᴷ', "K"},
        {'ᴸ', "L"},
        {'ᴹ', "M"},
        {'ᴺ', "N"},
        {'ᴼ', "O"},
        {'ᴾ', "P"},
        {'ᴿ', "R"},
        {'ᵀ', "T"},
        {'ᵁ', "U"},
        {'ᵂ', "W"},
        {'ᵃ', "a"},
        {'ᵇ', "b"},
        {'ᵈ', "d"},
        {'ᵉ', "e"},
        {'ᵍ', "g"},
        {'ᵏ', "k"},
        {'ᵐ', "m"},
        {'ᵒ', "o"},
        {'ᵖ', "p"},
        {'ᵗ', "t"},
        {'ᵘ', "u"},
        {'ᵛ', "v"},
        {'ᵢ', "i"},
        {'ᵣ', "r"},
        {'ᵤ', "u"},
        {'ᵥ', "v"},
        {'ᶜ', "c"},
        {'ᶠ', "f"},
        {'ᶻ', "z"},
        {'Ḁ', "A"},
        {'ḁ', "a"},
        {'Ḃ', "B"},
        {'ḃ', "b"},
        {'Ḅ', "B"},
        {'ḅ', "b"},
        {'Ḇ', "B"},
        {'ḇ', "b"},
        {'Ḉ', "C"},
        {'ḉ', "c"},
        {'ḋ', "d"},
        {'ḍ', "d"},
        {'Ḏ', "D"},
        {'ḏ', "d"},
        {'Ḑ', "D"},
        {'ḑ', "d"},
        {'Ḓ', "D"},
        {'ḓ', "d"},
        {'ḕ', "e"},
        {'Ḗ', "E"},
        {'ḗ', "e"},
        {'Ḙ', "E"},
        {'ḙ', "e"},
        {'Ḛ', "E"},
        {'ḛ', "e"},
        {'Ḝ', "E"},
        {'ḝ', "e"},
        {'Ḟ', "F"},
        {'ḟ', "f"},
        {'Ḡ', "G"},
        {'ḡ', "g"},
        {'Ḣ', "H"},
        {'ḣ', "h"},
        {'Ḥ', "H"},
        {'ḥ', "h"},
        {'Ḧ', "H"},
        {'ḧ', "h"},
        {'Ḩ', "H"},
        {'ḩ', "h"},
        {'Ḫ', "H"},
        {'ḫ', "h"},
        {'Ḭ', "I"},
        {'ḭ', "i"},
        {'Ḯ', "I"},
        {'ḯ', "i"},
        {'Ḱ', "K"},
        {'ḱ', "k"},
        {'Ḳ', "K"},
        {'ḳ', "k"},
        {'Ḵ', "K"},
        {'ḵ', "k"},
        {'Ḷ', "L"},
        {'ḷ', "l"},
        {'Ḹ', "L"},
        {'ḹ', "l"},
        {'Ḻ', "L"},
        {'ḻ', "l"},
        {'Ḽ', "L"},
        {'ḽ', "l"},
        {'Ḿ', "M"},
        {'ḿ', "m"},
        {'Ṁ', "M"},
        {'ṁ', "m"},
        {'Ṃ', "M"},
        {'ṃ', "m"},
        {'Ṅ', "N"},
        {'ṅ', "n"},
        {'Ṇ', "N"},
        {'ṇ', "n"},
        {'Ṉ', "N"},
        {'ṉ', "n"},
        {'Ṋ', "N"},
        {'ṋ', "n"},
        {'Ṍ', "O"},
        {'ṍ', "o"},
        {'Ṏ', "O"},
        {'ṏ', "o"},
        {'Ṑ', "O"},
        {'ṑ', "o"},
        {'Ṓ', "O"},
        {'ṓ', "o"},
        {'Ṕ', "P"},
        {'ṕ', "p"},
        {'Ṗ', "P"},
        {'ṗ', "p"},
        {'Ṙ', "R"},
        {'ṙ', "r"},
        {'Ṛ', "R"},
        {'ṛ', "r"},
        {'Ṝ', "R"},
        {'ṝ', "r"},
        {'Ṟ', "R"},
        {'ṟ', "r"},
        {'Ṡ', "S"},
        {'ṡ', "s"},
        {'Ṣ', "S"},
        {'ṣ', "s"},
        {'Ṥ', "S"},
        {'ṥ', "s"},
        {'Ṧ', "S"},
        {'ṧ', "s"},
        {'Ṩ', "S"},
        {'ṩ', "s"},
        {'Ṫ', "T"},
        {'ṫ', "t"},
        {'Ṭ', "T"},
        {'ṭ', "t"},
        {'Ṯ', "T"},
        {'ṯ', "t"},
        {'Ṱ', "T"},
        {'ṱ', "t"},
        {'Ṳ', "U"},
        {'ṳ', "u"},
        {'Ṵ', "U"},
        {'ṵ', "u"},
        {'Ṷ', "U"},
        {'ṷ', "u"},
        {'Ṹ', "U"},
        {'ṹ', "u"},
        {'Ṻ', "U"},
        {'ṻ', "u"},
        {'Ṽ', "V"},
        {'ṽ', "v"},
        {'Ṿ', "V"},
        {'ṿ', "v"},
        {'Ẁ', "W"},
        {'ẁ', "w"},
        {'Ẃ', "W"},
        {'ẃ', "w"},
        {'Ẅ', "W"},
        {'ẅ', "w"},
        {'Ẇ', "W"},
        {'ẇ', "w"},
        {'Ẉ', "W"},
        {'ẉ', "w"},
        {'Ẋ', "X"},
        {'ẋ', "x"},
        {'Ẍ', "X"},
        {'ẍ', "x"},
        {'Ẏ', "Y"},
        {'ẏ', "y"},
        {'Ẑ', "Z"},
        {'ẑ', "z"},
        {'Ẓ', "Z"},
        {'ẓ', "z"},
        {'Ẕ', "Z"},
        {'ẕ', "z"},
        {'ẖ', "h"},
        {'ẗ', "t"},
        {'ẘ', "w"},
        {'ẙ', "y"},
        {'ẚ', "a"},
        {'ẛ', "s"},
        {'Ạ', "A"},
        {'ạ', "a"},
        {'Ả', "A"},
        {'ả', "a"},
        {'Ấ', "A"},
        {'ấ', "a"},
        {'Ầ', "A"},
        {'ầ', "a"},
        {'Ẩ', "A"},
        {'ẩ', "a"},
        {'Ẫ', "A"},
        {'ẫ', "a"},
        {'Ậ', "A"},
        {'ậ', "a"},
        {'Ắ', "A"},
        {'ắ', "a"},
        {'Ằ', "A"},
        {'ằ', "a"},
        {'Ẳ', "A"},
        {'ẳ', "a"},
        {'Ẵ', "A"},
        {'ẵ', "a"},
        {'Ặ', "A"},
        {'ặ', "a"},
        {'Ẹ', "E"},
        {'ẹ', "e"},
        {'Ẻ', "E"},
        {'ẻ', "e"},
        {'Ẽ', "E"},
        {'ẽ', "e"},
        {'Ế', "E"},
        {'ế', "e"},
        {'Ề', "E"},
        {'ề', "e"},
        {'Ể', "E"},
        {'ể', "e"},
        {'Ễ', "E"},
        {'ễ', "e"},
        {'Ệ', "E"},
        {'ệ', "e"},
        {'Ỉ', "I"},
        {'ỉ', "i"},
        {'Ị', "I"},
        {'ị', "i"},
        {'Ọ', "O"},
        {'ọ', "o"},
        {'Ỏ', "O"},
        {'ỏ', "o"},
        {'Ố', "O"},
        {'ố', "o"},
        {'Ồ', "O"},
        {'ồ', "o"},
        {'Ổ', "O"},
        {'ổ', "o"},
        {'Ỗ', "O"},
        {'ỗ', "o"},
        {'Ộ', "O"},
        {'ộ', "o"},
        {'Ớ', "O"},
        {'ớ', "o"},
        {'Ờ', "O"},
        {'ờ', "o"},
        {'Ở', "O"},
        {'ở', "o"},
        {'Ỡ', "O"},
        {'ỡ', "o"},
        {'Ợ', "O"},
        {'ợ', "o"},
        {'Ụ', "U"},
        {'ụ', "u"},
        {'Ủ', "U"},
        {'ủ', "u"},
        {'Ứ', "U"},
        {'ứ', "u"},
        {'Ừ', "U"},
        {'ừ', "u"},
        {'Ử', "U"},
        {'ử', "u"},
        {'Ữ', "U"},
        {'ữ', "u"},
        {'Ự', "U"},
        {'ự', "u"},
        {'Ỳ', "Y"},
        {'ỳ', "y"},
        {'Ỵ', "Y"},
        {'ỵ', "y"},
        {'Ỷ', "Y"},
        {'ỷ', "y"},
        {'Ỹ', "Y"},
        {'ỹ', "y"},
        {'`', "`"},
        {'․', "."},
        {'‥', ".."},
        {'…', "..."},
        {'‼', "!!"},
        {'⁇', "??"},
        {'⁈', "?!"},
        {'⁉', "!?"},
        {'⁰', "0"},
        {'ⁱ', "i"},
        {'⁴', "4"},
        {'⁵', "5"},
        {'⁶', "6"},
        {'⁷', "7"},
        {'⁸', "8"},
        {'⁹', "9"},
        {'⁺', "+"},
        {'⁼', "="},
        {'⁽', "("},
        {'⁾', ")"},
        {'ⁿ', "n"},
        {'₀', "0"},
        {'₁', "1"},
        {'₂', "2"},
        {'₃', "3"},
        {'₄', "4"},
        {'₅', "5"},
        {'₆', "6"},
        {'₇', "7"},
        {'₈', "8"},
        {'₉', "9"},
        {'₊', "+"},
        {'₌', "="},
        {'₍', "("},
        {'₎', ")"},
        {'ₐ', "a"},
        {'ₑ', "e"},
        {'ₒ', "o"},
        {'ₓ', "x"},
        {'ₕ', "h"},
        {'ₖ', "k"},
        {'ₗ', "l"},
        {'ₘ', "m"},
        {'ₙ', "n"},
        {'ₚ', "p"},
        {'ₛ', "s"},
        {'ₜ', "t"},
        {'₨', "Rs"},
        {'℀', "a/c"},
        {'℁', "a/s"},
        {'ℂ', "C"},
        {'℃', "C"},
        {'℅', "c/o"},
        {'℆', "c/u"},
        {'℉', "F"},
        {'ℊ', "g"},
        {'ℋ', "H"},
        {'ℌ', "H"},
        {'ℍ', "H"},
        {'ℎ', "h"},
        {'ℐ', "I"},
        {'ℑ', "I"},
        {'ℒ', "L"},
        {'ℓ', "l"},
        {'ℕ', "N"},
        {'№', "No"},
        {'ℙ', "P"},
        {'ℚ', "Q"},
        {'ℛ', "R"},
        {'ℜ', "R"},
        {'ℝ', "R"},
        {'℠', "SM"},
        {'℡', "TEL"},
        {'™', "TM"},
        {'ℤ', "Z"},
        {'ℨ', "Z"},
        {'K', "K"},
        {'Å', "A"},
        {'ℬ', "B"},
        {'ℭ', "C"},
        {'ℯ', "e"},
        {'ℰ', "E"},
        {'ℱ', "F"},
        {'ℳ', "M"},
        {'ℴ', "o"},
        {'ℹ', "i"},
        {'℻', "FAX"},
        {'ⅅ', "D"},
        {'ⅆ', "d"},
        {'ⅇ', "e"},
        {'ⅈ', "i"},
        {'ⅉ', "j"},
        {'⅐', "17"},
        {'⅑', "19"},
        {'⅒', "110"},
        {'⅓', "13"},
        {'⅔', "23"},
        {'⅕', "15"},
        {'⅖', "25"},
        {'⅗', "35"},
        {'⅘', "45"},
        {'⅙', "16"},
        {'⅚', "56"},
        {'⅛', "18"},
        {'⅜', "38"},
        {'⅝', "58"},
        {'⅞', "78"},
        {'⅟', "1"},
        {'Ⅰ', "I"},
        {'Ⅱ', "II"},
        {'Ⅲ', "III"},
        {'Ⅳ', "IV"},
        {'Ⅴ', "V"},
        {'Ⅵ', "VI"},
        {'Ⅶ', "VII"},
        {'Ⅷ', "VIII"},
        {'Ⅸ', "IX"},
        {'Ⅹ', "X"},
        {'Ⅺ', "XI"},
        {'Ⅻ', "XII"},
        {'Ⅼ', "L"},
        {'Ⅽ', "C"},
        {'Ⅾ', "D"},
        {'Ⅿ', "M"},
        {'ⅰ', "i"},
        {'ⅱ', "ii"},
        {'ⅲ', "iii"},
        {'ⅳ', "iv"},
        {'ⅴ', "v"},
        {'ⅵ', "vi"},
        {'ⅶ', "vii"},
        {'ⅷ', "viii"},
        {'ⅸ', "ix"},
        {'ⅹ', "x"},
        {'ⅺ', "xi"},
        {'ⅻ', "xii"},
        {'ⅼ', "l"},
        {'ⅽ', "c"},
        {'ⅾ', "d"},
        {'ⅿ', "m"},
        {'↉', "03"},
        {'≠', "="},
        {'≮', "<"},
        {'≯', ">"},
        {'①', "1"},
        {'②', "2"},
        {'③', "3"},
        {'④', "4"},
        {'⑤', "5"},
        {'⑥', "6"},
        {'⑦', "7"},
        {'⑧', "8"},
        {'⑨', "9"},
        {'⑩', "10"},
        {'⑪', "11"},
        {'⑫', "12"},
        {'⑬', "13"},
        {'⑭', "14"},
        {'⑮', "15"},
        {'⑯', "16"},
        {'⑰', "17"},
        {'⑱', "18"},
        {'⑲', "19"},
        {'⑳', "20"},
        {'⑴', "(1)"},
        {'⑵', "(2)"},
        {'⑶', "(3)"},
        {'⑷', "(4)"},
        {'⑸', "(5)"},
        {'⑹', "(6)"},
        {'⑺', "(7)"},
        {'⑻', "(8)"},
        {'⑼', "(9)"},
        {'⑽', "(10)"},
        {'⑾', "(11)"},
        {'⑿', "(12)"},
        {'⒀', "(13)"},
        {'⒁', "(14)"},
        {'⒂', "(15)"},
        {'⒃', "(16)"},
        {'⒄', "(17)"},
        {'⒅', "(18)"},
        {'⒆', "(19)"},
        {'⒇', "(20)"},
        {'⒈', "1."},
        {'⒉', "2."},
        {'⒊', "3."},
        {'⒋', "4."},
        {'⒌', "5."},
        {'⒍', "6."},
        {'⒎', "7."},
        {'⒏', "8."},
        {'⒐', "9."},
        {'⒑', "10."},
        {'⒒', "11."},
        {'⒓', "12."},
        {'⒔', "13."},
        {'⒕', "14."},
        {'⒖', "15."},
        {'⒗', "16."},
        {'⒘', "17."},
        {'⒙', "18."},
        {'⒚', "19."},
        {'⒛', "20."},
        {'⒜', "(a)"},
        {'⒝', "(b)"},
        {'⒞', "(c)"},
        {'⒟', "(d)"},
        {'⒠', "(e)"},
        {'⒡', "(f)"},
        {'⒢', "(g)"},
        {'⒣', "(h)"},
        {'⒤', "(i)"},
        {'⒥', "(j)"},
        {'⒦', "(k)"},
        {'⒧', "(l)"},
        {'⒨', "(m)"},
        {'⒩', "(n)"},
        {'⒪', "(o)"},
        {'⒫', "(p)"},
        {'⒬', "(q)"},
        {'⒭', "(r)"},
        {'⒮', "(s)"},
        {'⒯', "(t)"},
        {'⒰', "(u)"},
        {'⒱', "(v)"},
        {'⒲', "(w)"},
        {'⒳', "(x)"},
        {'⒴', "(y)"},
        {'⒵', "(z)"},
        {'Ⓐ', "A"},
        {'Ⓑ', "B"},
        {'Ⓒ', "C"},
        {'Ⓓ', "D"},
        {'Ⓔ', "E"},
        {'Ⓕ', "F"},
        {'Ⓖ', "G"},
        {'Ⓗ', "H"},
        {'Ⓘ', "I"},
        {'Ⓙ', "J"},
        {'Ⓚ', "K"},
        {'Ⓛ', "L"},
        {'Ⓜ', "M"},
        {'Ⓝ', "N"},
        {'Ⓞ', "O"},
        {'Ⓟ', "P"},
        {'Ⓠ', "Q"},
        {'Ⓡ', "R"},
        {'Ⓢ', "S"},
        {'Ⓣ', "T"},
        {'Ⓤ', "U"},
        {'Ⓥ', "V"},
        {'Ⓦ', "W"},
        {'Ⓧ', "X"},
        {'Ⓨ', "Y"},
        {'Ⓩ', "Z"},
        {'ⓐ', "a"},
        {'ⓑ', "b"},
        {'ⓒ', "c"},
        {'ⓓ', "d"},
        {'ⓔ', "e"},
        {'ⓕ', "f"},
        {'ⓖ', "g"},
        {'ⓗ', "h"},
        {'ⓘ', "i"},
        {'ⓙ', "j"},
        {'ⓚ', "k"},
        {'ⓛ', "l"},
        {'ⓜ', "m"},
        {'ⓝ', "n"},
        {'ⓞ', "o"},
        {'ⓟ', "p"},
        {'ⓠ', "q"},
        {'ⓡ', "r"},
        {'ⓢ', "s"},
        {'ⓣ', "t"},
        {'ⓤ', "u"},
        {'ⓥ', "v"},
        {'ⓦ', "w"},
        {'ⓧ', "x"},
        {'ⓨ', "y"},
        {'ⓩ', "z"},
        {'⓪', "0"},
        {'⩴', "::="},
        {'⩵', "=="},
        {'⩶', "==="},
        {'ⱼ', "j"},
        {'ⱽ', "V"},
        {'㈀', "()"},
        {'㈁', "()"},
        {'㈂', "()"},
        {'㈃', "()"},
        {'㈄', "()"},
        {'㈅', "()"},
        {'㈆', "()"},
        {'㈇', "()"},
        {'㈈', "()"},
        {'㈉', "()"},
        {'㈊', "()"},
        {'㈋', "()"},
        {'㈌', "()"},
        {'㈍', "()"},
        {'㈎', "()"},
        {'㈏', "()"},
        {'㈐', "()"},
        {'㈑', "()"},
        {'㈒', "()"},
        {'㈓', "()"},
        {'㈔', "()"},
        {'㈕', "()"},
        {'㈖', "()"},
        {'㈗', "()"},
        {'㈘', "()"},
        {'㈙', "()"},
        {'㈚', "()"},
        {'㈛', "()"},
        {'㈜', "()"},
        {'㈝', "()"},
        {'㈞', "()"},
        {'㈠', "()"},
        {'㈡', "()"},
        {'㈢', "()"},
        {'㈣', "()"},
        {'㈤', "()"},
        {'㈥', "()"},
        {'㈦', "()"},
        {'㈧', "()"},
        {'㈨', "()"},
        {'㈩', "()"},
        {'㈪', "()"},
        {'㈫', "()"},
        {'㈬', "()"},
        {'㈭', "()"},
        {'㈮', "()"},
        {'㈯', "()"},
        {'㈰', "()"},
        {'㈱', "()"},
        {'㈲', "()"},
        {'㈳', "()"},
        {'㈴', "()"},
        {'㈵', "()"},
        {'㈶', "()"},
        {'㈷', "()"},
        {'㈸', "()"},
        {'㈹', "()"},
        {'㈺', "()"},
        {'㈻', "()"},
        {'㈼', "()"},
        {'㈽', "()"},
        {'㈾', "()"},
        {'㈿', "()"},
        {'㉀', "()"},
        {'㉁', "()"},
        {'㉂', "()"},
        {'㉃', "()"},
        {'㉐', "PTE"},
        {'㉑', "21"},
        {'㉒', "22"},
        {'㉓', "23"},
        {'㉔', "24"},
        {'㉕', "25"},
        {'㉖', "26"},
        {'㉗', "27"},
        {'㉘', "28"},
        {'㉙', "29"},
        {'㉚', "30"},
        {'㉛', "31"},
        {'㉜', "32"},
        {'㉝', "33"},
        {'㉞', "34"},
        {'㉟', "35"},
        {'㊱', "36"},
        {'㊲', "37"},
        {'㊳', "38"},
        {'㊴', "39"},
        {'㊵', "40"},
        {'㊶', "41"},
        {'㊷', "42"},
        {'㊸', "43"},
        {'㊹', "44"},
        {'㊺', "45"},
        {'㊻', "46"},
        {'㊼', "47"},
        {'㊽', "48"},
        {'㊾', "49"},
        {'㊿', "50"},
        {'㋀', "1"},
        {'㋁', "2"},
        {'㋂', "3"},
        {'㋃', "4"},
        {'㋄', "5"},
        {'㋅', "6"},
        {'㋆', "7"},
        {'㋇', "8"},
        {'㋈', "9"},
        {'㋉', "10"},
        {'㋊', "11"},
        {'㋋', "12"},
        {'㋌', "Hg"},
        {'㋍', "erg"},
        {'㋎', "eV"},
        {'㋏', "LTD"},
        {'㍘', "0"},
        {'㍙', "1"},
        {'㍚', "2"},
        {'㍛', "3"},
        {'㍜', "4"},
        {'㍝', "5"},
        {'㍞', "6"},
        {'㍟', "7"},
        {'㍠', "8"},
        {'㍡', "9"},
        {'㍢', "10"},
        {'㍣', "11"},
        {'㍤', "12"},
        {'㍥', "13"},
        {'㍦', "14"},
        {'㍧', "15"},
        {'㍨', "16"},
        {'㍩', "17"},
        {'㍪', "18"},
        {'㍫', "19"},
        {'㍬', "20"},
        {'㍭', "21"},
        {'㍮', "22"},
        {'㍯', "23"},
        {'㍰', "24"},
        {'㍱', "hPa"},
        {'㍲', "da"},
        {'㍳', "AU"},
        {'㍴', "bar"},
        {'㍵', "oV"},
        {'㍶', "pc"},
        {'㍷', "dm"},
        {'㍸', "dm2"},
        {'㍹', "dm3"},
        {'㍺', "IU"},
        {'㎀', "pA"},
        {'㎁', "nA"},
        {'㎂', "A"},
        {'㎃', "mA"},
        {'㎄', "kA"},
        {'㎅', "KB"},
        {'㎆', "MB"},
        {'㎇', "GB"},
        {'㎈', "cal"},
        {'㎉', "kcal"},
        {'㎊', "pF"},
        {'㎋', "nF"},
        {'㎌', "F"},
        {'㎍', "g"},
        {'㎎', "mg"},
        {'㎏', "kg"},
        {'㎐', "Hz"},
        {'㎑', "kHz"},
        {'㎒', "MHz"},
        {'㎓', "GHz"},
        {'㎔', "THz"},
        {'㎕', "l"},
        {'㎖', "ml"},
        {'㎗', "dl"},
        {'㎘', "kl"},
        {'㎙', "fm"},
        {'㎚', "nm"},
        {'㎛', "m"},
        {'㎜', "mm"},
        {'㎝', "cm"},
        {'㎞', "km"},
        {'㎟', "mm2"},
        {'㎠', "cm2"},
        {'㎡', "m2"},
        {'㎢', "km2"},
        {'㎣', "mm3"},
        {'㎤', "cm3"},
        {'㎥', "m3"},
        {'㎦', "km3"},
        {'㎧', "ms"},
        {'㎨', "ms2"},
        {'㎩', "Pa"},
        {'㎪', "kPa"},
        {'㎫', "MPa"},
        {'㎬', "GPa"},
        {'㎭', "rad"},
        {'㎮', "rads"},
        {'㎯', "rads2"},
        {'㎰', "ps"},
        {'㎱', "ns"},
        {'㎲', "s"},
        {'㎳', "ms"},
        {'㎴', "pV"},
        {'㎵', "nV"},
        {'㎶', "V"},
        {'㎷', "mV"},
        {'㎸', "kV"},
        {'㎹', "MV"},
        {'㎺', "pW"},
        {'㎻', "nW"},
        {'㎼', "W"},
        {'㎽', "mW"},
        {'㎾', "kW"},
        {'㎿', "MW"},
        {'㏀', "k"},
        {'㏁', "M"},
        {'㏂', "a.m."},
        {'㏃', "Bq"},
        {'㏄', "cc"},
        {'㏅', "cd"},
        {'㏆', "Ckg"},
        {'㏇', "Co."},
        {'㏈', "dB"},
        {'㏉', "Gy"},
        {'㏊', "ha"},
        {'㏋', "HP"},
        {'㏌', "in"},
        {'㏍', "KK"},
        {'㏎', "KM"},
        {'㏏', "kt"},
        {'㏐', "lm"},
        {'㏑', "ln"},
        {'㏒', "log"},
        {'㏓', "lx"},
        {'㏔', "mb"},
        {'㏕', "mil"},
        {'㏖', "mol"},
        {'㏗', "PH"},
        {'㏘', "p.m."},
        {'㏙', "PPM"},
        {'㏚', "PR"},
        {'㏛', "sr"},
        {'㏜', "Sv"},
        {'㏝', "Wb"},
        {'㏞', "Vm"},
        {'㏟', "Am"},
        {'㏠', "1"},
        {'㏡', "2"},
        {'㏢', "3"},
        {'㏣', "4"},
        {'㏤', "5"},
        {'㏥', "6"},
        {'㏦', "7"},
        {'㏧', "8"},
        {'㏨', "9"},
        {'㏩', "10"},
        {'㏪', "11"},
        {'㏫', "12"},
        {'㏬', "13"},
        {'㏭', "14"},
        {'㏮', "15"},
        {'㏯', "16"},
        {'㏰', "17"},
        {'㏱', "18"},
        {'㏲', "19"},
        {'㏳', "20"},
        {'㏴', "21"},
        {'㏵', "22"},
        {'㏶', "23"},
        {'㏷', "24"},
        {'㏸', "25"},
        {'㏹', "26"},
        {'㏺', "27"},
        {'㏻', "28"},
        {'㏼', "29"},
        {'㏽', "30"},
        {'㏾', "31"},
        {'㏿', "gal"},
        {'ﬀ', "ff"},
        {'ﬁ', "fi"},
        {'ﬂ', "fl"},
        {'ﬃ', "ffi"},
        {'ﬄ', "ffl"},
        {'ﬅ', "st"},
        {'ﬆ', "st"},
        {'﬩', "+"},
        {'︐', ","},
        {'︓', ":"},
        {'︔', ";"},
        {'︕', "!"},
        {'︖', "?"},
        {'︙', "..."},
        {'︰', ".."},
        {'︳', "_"},
        {'︴', "_"},
        {'︵', "("},
        {'︶', ")"},
        {'︷', "{"},
        {'︸', "}"},
        {'﹇', "["},
        {'﹈', "]"},
        {'﹍', "_"},
        {'﹎', "_"},
        {'﹏', "_"},
        {'﹐', ","},
        {'﹒', "."},
        {'﹔', ";"},
        {'﹕', ":"},
        {'﹖', "?"},
        {'﹗', "!"},
        {'﹙', "("},
        {'﹚', ")"},
        {'﹛', "{"},
        {'﹜', "}"},
        {'﹟', "#"},
        {'﹠', "&"},
        {'﹡', "*"},
        {'﹢', "+"},
        {'﹣', "-"},
        {'﹤', "<"},
        {'﹥', ">"},
        {'﹦', "="},
        {'﹨', "\\"},
        {'﹩', "$"},
        {'﹪', "%"},
        {'﹫', "@"},
        {'！', "!"},
        {'＂', "\""},
        {'＃', "#"},
        {'＄', "$"},
        {'％', "%"},
        {'＆', "&"},
        {'＇', "'"},
        {'（', "("},
        {'）', ")"},
        {'＊', "*"},
        {'＋', "+"},
        {'，', ","},
        {'－', "-"},
        {'．', "."},
        {'／', "/"},
        {'０', "0"},
        {'１', "1"},
        {'２', "2"},
        {'３', "3"},
        {'４', "4"},
        {'５', "5"},
        {'６', "6"},
        {'７', "7"},
        {'８', "8"},
        {'９', "9"},
        {'：', ":"},
        {'；', ";"},
        {'＜', "<"},
        {'＝', "="},
        {'＞', ">"},
        {'？', "?"},
        {'＠', "@"},
        {'Ａ', "A"},
        {'Ｂ', "B"},
        {'Ｃ', "C"},
        {'Ｄ', "D"},
        {'Ｅ', "E"},
        {'Ｆ', "F"},
        {'Ｇ', "G"},
        {'Ｈ', "H"},
        {'Ｉ', "I"},
        {'Ｊ', "J"},
        {'Ｋ', "K"},
        {'Ｌ', "L"},
        {'Ｍ', "M"},
        {'Ｎ', "N"},
        {'Ｏ', "O"},
        {'Ｐ', "P"},
        {'Ｑ', "Q"},
        {'Ｒ', "R"},
        {'Ｓ', "S"},
        {'Ｔ', "T"},
        {'Ｕ', "U"},
        {'Ｖ', "V"},
        {'Ｗ', "W"},
        {'Ｘ', "X"},
        {'Ｙ', "Y"},
        {'Ｚ', "Z"},
        {'［', "["},
        {'＼', "\\"},
        {'］', "]"},
        {'＾', "^"},
        {'＿', "_"},
        {'｀', "`"},
        {'ａ', "a"},
        {'ｂ', "b"},
        {'ｃ', "c"},
        {'ｄ', "d"},
        {'ｅ', "e"},
        {'ｆ', "f"},
        {'ｇ', "g"},
        {'ｈ', "h"},
        {'ｉ', "i"},
        {'ｊ', "j"},
        {'ｋ', "k"},
        {'ｌ', "l"},
        {'ｍ', "m"},
        {'ｎ', "n"},
        {'ｏ', "o"},
        {'ｐ', "p"},
        {'ｑ', "q"},
        {'ｒ', "r"},
        {'ｓ', "s"},
        {'ｔ', "t"},
        {'ｕ', "u"},
        {'ｖ', "v"},
        {'ｗ', "w"},
        {'ｘ', "x"},
        {'ｙ', "y"},
        {'ｚ', "z"},
        {'｛', "{"},
        {'｜', "|"},
        {'｝', "}"},
        {'～', "~"},
    };
}