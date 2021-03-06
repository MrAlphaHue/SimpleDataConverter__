
//Warn : Don't change this code.
//Generated By MrHue.SimpleDataConverter


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MrHue;


public static class TableSample
{
    
    #region SheetName_Struct
    public class Character_Struct
    {
        public int struct_index;
		public int id;
		public string chr_name;
		public int icon_index;
		public int chr_level;
		public int chr_atk;
		public float chr_rate;


    public string GetAllVars(){
        string str = "";
		str += string.Format("{0} : {1}\n", "id", id.ToString());
		str += string.Format("{0} : {1}\n", "chr_name", chr_name.ToString());
		str += string.Format("{0} : {1}\n", "icon_index", icon_index.ToString());
		str += string.Format("{0} : {1}\n", "chr_level", chr_level.ToString());
		str += string.Format("{0} : {1}\n", "chr_atk", chr_atk.ToString());
		str += string.Format("{0} : {1}\n", "chr_rate", chr_rate.ToString());

        return str;
        }
    }
    //int, long, double, float, 
    public class Character_Holder : TableSheet_Holder
    {
        private Dictionary<int, Character_Struct> _dic = new Dictionary<int, Character_Struct>();
        public readonly Dictionary<int, Character_Struct> pDic = new Dictionary<int, Character_Struct>();
        
        public int Count
        {
            get 
            {
                return _dic.Count; 
            }
        }

        public void DebugAllEls()
        {
            Debug.LogError("Character : DebugAll Els");
            foreach (var pair in _dic)
            {
                Debug.LogError(pair.Key + " : " + pair.Value.GetAllVars());
            }
        }

        public Character_Struct GetStruct(int index)
        {
            if (_dic.ContainsKey(index))
                return _dic[index];
            return null;
        }
        public Character_Holder(string[][] strs) : base(strs)
        {
            this.SheetName = GetType().Name;
            for (int i = 0; i < strs.Length; i++)
            {
                string[] data_string = strs[i];
                var data = new Character_Struct() 
                {     
                
                };
                data.struct_index = i;
				data.id = int.Parse(data_string[0]);
				data.chr_name = data_string[1].Replace("\\n", "\n");
				data.icon_index = int.Parse(data_string[2]);
				data.chr_level = int.Parse(data_string[3]);
				data.chr_atk = int.Parse(data_string[4]);
				data.chr_rate = float.Parse(data_string[5]);


                _dic.Add(data.struct_index , data);
            }
            pDic = _dic;
        }
    }
    #endregion
    
    #region Common

    private static bool isInIt = false;

    
        public static Character_Holder Character;

    
    public static void InIt(Dictionary<string,string[][]> strDic)
    {
        if(isInIt)
            return;
        
        
        string strCharacter = "Character";
        if (strDic.ContainsKey(strCharacter))
        {
            Character = new Character_Holder(strDic[strCharacter]);
        }


        isInIt = true;
    }
    
    #endregion

}
