// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.Out.WriteLine("Expected: E, Actual: " + PhoneUtil.OldPhonePad("33#"));
Console.Out.WriteLine("Expected: B, Actual: " + PhoneUtil.OldPhonePad("227*#"));
Console.Out.WriteLine("Expected: HELLO, Actual: " + PhoneUtil.OldPhonePad("4433555 555666#"));
Console.Out.WriteLine("Expected: TURING, Actual: " + PhoneUtil.OldPhonePad("8 88777444666*664#"));
Console.Out.WriteLine("Expected: 'ADWM, Actual: " + PhoneUtil.OldPhonePad("1123 5* 96#"));
Console.Out.WriteLine("Expected: , Actual: " + PhoneUtil.OldPhonePad("        #"));
Console.Out.WriteLine("Expected: , Actual: " + PhoneUtil.OldPhonePad("*****#"));