

//Warn : Don't change this code.
//Generated By MrHue.SimpleDataConverter


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO; 
using System;
using System.Linq;
using System.Security.Cryptography;

public class TableManager
{
    //[RuntimeInitializeOnLoadMethod]
    //Must Be Static If You want "RuntimeInitializeOnLoadMethod"
    public static void InIt()
    {
        Debug.LogError("MrHue Table InIt");
        
		 TableSample.InIt(GetDicByFile("TableSample"));


    }

    static Dictionary<string, string[][]> GetDicByFile(string tableName)
    {
        Dictionary<string, string[][]> _outDic = new Dictionary<string, string[][]>();
        var text_asset = Resources.Load("BinaryData/" + tableName) as TextAsset;
        string getBytestring = System.Text.Encoding.UTF8.GetString(text_asset.bytes); //U2gi
        byte[] byte1 = Convert.FromBase64String(getBytestring);
        string final_str = System.Text.Encoding.UTF8.GetString(byte1);
        
        //SheetName / Sheet_Content / SheetName
        string[] strs = final_str.Split(new string[] {"		"} ,StringSplitOptions.None);
        for (int i = 0; i < strs.Length - 1; i+=2)
        {
            //
            string sheet_name = strs[i];
            
            //
            string[] strsSplit = strs[i+1].Split('	');
            int _column = Array.FindIndex(strsSplit, val => val.Equals("id"));
            int _row = strsSplit.Length / _column;
            string[][] sheet_contents = new string[_row-2][];

            // int strsplindex;
            for (int idx_row = 2; idx_row < _row; idx_row++)
            {
                sheet_contents[idx_row-2] = new string[_column];
                for (int idx_column = 0; idx_column < _column; idx_column++)
                {
                    sheet_contents[idx_row-2][idx_column] = strsSplit[idx_row * _column + idx_column];
                }
            }
            _outDic.Add(sheet_name , sheet_contents);
        }

        return _outDic;
    }
}
