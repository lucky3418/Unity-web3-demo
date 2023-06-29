using UnityEngine;
using Nethereum.ABI;

public static class Encode
{
    public static string ABIEncodeUintArray(uint[] args) {
        var abiEncode = new ABIEncode();
        byte[] result = abiEncode.GetABIEncoded(new ABIValue("uint[]", args));
        return System.BitConverter.ToString(result).Replace("-","");
    }

    public static string EncodeUintArray(uint[] args) {
        var abiEncode = new ABIEncode();
        string encoded = "0x";
        for (int i = 0; i < args.Length; i ++) {
            byte[] result = abiEncode.GetABIEncoded(new ABIValue("uint", args[i]));
            encoded += System.BitConverter.ToString(result).Replace("-","");
        }
        return encoded;
    }

    public static byte[] ConvertHexstrToBytes(string input) {
        if (input[..2].Equals("0x")) {
            input = input[2..];
        }
        var result = new byte[(input.Length + 1) / 2];
        var offset = 0;
        if (input.Length % 2 == 1) {
            // If length of input is odd, the first character has an implicit 0 prepended.
            result[0] = (byte)System.Convert.ToUInt32(input[0] + "", 16);
            offset = 1;
        }
        for (int i = 0; i < input.Length / 2; i++) {
            result[i + offset] = (byte)System.Convert.ToUInt32(input.Substring(i * 2 + offset, 2), 16);
        }
        return result;
    }
}
