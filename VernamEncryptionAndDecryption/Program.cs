char[] alphabet = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZXWQ".ToCharArray();   //Enter the letters of the alphabet in this field. The counts of letters in the alphabet must be a power of 2.
char[] plainText = "AçıkMetin".ToUpper().ToCharArray();   //Enter the plain-cipher text in this field.
char[] key = "Anahtar".ToUpper().ToCharArray();   //Enter the key in this field.

int exponent = Convert.ToInt32(Math.Log(alphabet.Length, 2));

string[] keyBinary = new string[key.Length]; 
for (int i = 0; i < key.Length; i++)
{
    keyBinary[i] = Convert.ToString(Array.IndexOf(alphabet, key[i]), 2).PadLeft(exponent, '0');
}

string cipherText = string.Empty;
for (int i = 0; i < plainText.Length; i++)
{
    string binary = Convert.ToString(Array.IndexOf(alphabet, plainText[i]), 2).PadLeft(exponent, '0');
    string cipherChar = string.Empty;
    for (int j = 0; j < exponent; j++)
    {
        int cipherBit = binary[j] ^ keyBinary[i % key.Length][j];
        cipherChar += cipherBit.ToString();
    }
    int cipherIndex = Convert.ToInt32(cipherChar, 2);
    cipherText += alphabet[cipherIndex];
}
Console.WriteLine(cipherText);