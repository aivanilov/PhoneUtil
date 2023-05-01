namespace ConsoleApp1;

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// This is a utility class containing a single static method called OldPhonePad().
/// </summary>
public class PhoneUtil
{
    private const char Default = '%';
    private const char Star = '*';
    private const char Space = ' ';

    private static readonly char[][] Dict = {
            new [] {' ','0'},
            new [] {'&', '\'', '(', '1'},
            new [] {'A', 'B', 'C', '2'},
            new [] {'D', 'E', 'F', '3'},
            new [] {'G', 'H', 'I', '4'},
            new [] {'J', 'K', 'L', '5'},
            new [] {'M', 'N', 'O', '6'},
            new [] {'P', 'Q', 'R', 'S', '7'},
            new [] {'T', 'U', 'V', '8'},
            new [] {'W', 'X', 'Y', 'Z', '9'}
    };
    
    /// <summary>
    /// The method is used to convert a phone number input string into a readable string. 
    /// </summary>
    /// <remarks>
    /// The input string should only contain digits 0-9, and special characters "*", " ", and "#".
    /// The "#" symbol is always located at the end of the input.
    /// If there are any issues with the input, the method will throw an ArgumentException.
    /// </remarks>
    public static string OldPhonePad(string input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(input);
        }

        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input) || input.Length == 1)
        {
            throw new ArgumentException("The input is empty.");
        }

        var inputCorrected = input.Substring(0, input.Length - 1);
        var parts = ExtractParts(inputCorrected);
        var sb = ReadParts(parts);

        return sb.ToString();
    }

    private static StringBuilder ReadParts(List<string> parts)
    {
        var sb = new StringBuilder();

        foreach (string part in parts)
        {
            if (string.IsNullOrEmpty(part) || string.IsNullOrWhiteSpace(part))
            {
                continue;
            }

            if (part.Equals(Star.ToString()))
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else
            {
                char letter = GetCharFromPart(int.Parse(part.Substring(0, 1)), part.Length);
                sb.Append(letter);
            }
        }

        return sb;
    }

    private static List<string> ExtractParts(string inputCorrected)
    {
        var parts = new List<string>();
        var sb = new StringBuilder();
        var prev = Default;

        foreach (var c in inputCorrected)
        {
            if (c == Star)
            {
                parts.Add(sb.ToString());
                sb = new StringBuilder();
                parts.Add(c.ToString());
            }
            else if (c == Space)
            {
                parts.Add(sb.ToString());
                sb = new StringBuilder();
            }
            else if (prev == Default)
            {
                sb.Append(c);
            }
            else
            {
                if (c == prev)
                {
                    sb.Append(c);
                }
                else
                {
                    parts.Add(sb.ToString());
                    sb = new StringBuilder();
                    sb.Append(c);
                }
            }

            prev = c;
        }

        if (sb.Length > 0)
        {
            parts.Add(sb.ToString());
        }

        return parts;
    }

    private static char GetCharFromPart(int button, int hitCount)
    {
        if (button > 9 || button < 0)
        {
            throw new ArgumentException("button should be in 0 to 9 interval.");
        }

        if (hitCount < 0)
        {
            throw new ArgumentException("hitCount can't be below 0.");
        }

        var length = Dict[button].Length;

        while (hitCount > length)
        {
            hitCount -= length;
        }

        return Dict[button][hitCount - 1];
    }
}