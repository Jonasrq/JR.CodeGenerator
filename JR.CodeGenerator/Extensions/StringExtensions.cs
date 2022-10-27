﻿namespace JR.CodeGenerator.Extensions;

/// <summary>
/// Uppers the first character.
/// </summary>
/// <autogeneratedoc />
public static class StringExtensions
{
    /// <summary>
    /// Uppers the first character.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    /// <autogeneratedoc />
    public static string UpperFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return null;
        }

        char[] chars = input.ToCharArray();
        chars[0] = char.ToUpper(chars[0]);
        return new string(chars);
    }
}
