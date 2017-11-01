using System;
using System.Collections.Generic;
using System.Text;

namespace number2textlib
{
    public class num2text
    {
        public string convert2text(string num2convert)
        {
            string result1 = "";
            string result2 = "";
            
            string[] _ks = {"χίλια ", "χιλιάδες "};
            string[] _hs = {"εκατόν ", "διακόσια ", "τριακόσια ", "τετρακόσια ", "πεντακόσια ", "εξακόσια ", "εφτακόσια ", "οχτακόσια ", "εννιακόσια "};
            string[] _hsk = { "εκατόν ", "διακόσιες ", "τριακόσιες ", "τετρακόσιες ", "πεντακόσιες ", "εξακόσιες ", "εφτακόσιες ", "οχτακόσιες ", "εννιακόσιες " };
            
            string[] _ds = {"δέκα ", "είκοσι ", "τριάντα ", "σαράντα ", "πενήντα ", "εξήντα ", "εβδομήντα ", "ογδόντα ", "ενενήντα "};
            string[] _1 = { "μηδέν ","ένα ", "δύο ", "τρία ", "τέσσερα ", "πέντε ", "έξη ", "επτά ", "οκτώ ", "εννιά " };
            string[] _1k = { "μηδέν ", "ένα ", "δύο ", "τρεις ", "τέσσερις ", "πέντε ", "έξη ", "επτά ", "οκτώ ", "εννιά " };


            string euro = "ευρώ ";
            string cent = "λεπτά ";

            //if (Convert.ToInt32(num2convert) > 999999)
            //{
            //    return "ERROR";
            //}

            string num2c = num2convert.ToString();
            string euroval = "";
            string centval = "";
           
            Boolean hascents = false;

            char[] delimiterChars = {',', '.'};
            string[] inpt = num2c.Split(delimiterChars);
            euroval = inpt[0];
            if (inpt.Length == 2)
            {
                centval = inpt[1];
                hascents = true;
            }

            
            //Euro Calculation
            switch (euroval.Length)
            {
                case 6: //100 000
                    if (euroval.Substring(0, 1) == "0")
                    {
                        euroval = euroval.Substring(1, 5);
                        goto case 5;
                    }

                    if (euroval.Substring(0,3) == "100")
                    {
                        result1 += "εκατό ";
                        result1 += _ks[1];
                        euroval = euroval.Substring(3, 3);
                        if (euroval == "000")
                        {
                            goto PosEnd;
                        }
                        else
                        {
                            goto case 3;
                        }
                    } 
                    
                    result1 += _hsk[Convert.ToInt16(euroval.Substring(0, 1)) - 1];

                    euroval = euroval.Substring(1,5);
                    goto case 5;
                    
                case 5: // 10 000
                    if (euroval.Substring(0, 1) == "0")
                    {
                        euroval = euroval.Substring(1, 4);
                        goto case 4;
                    }

                    if (euroval.Substring(0,2) == "11")
                    {
                        result1 += "έντεκα ";
                    }
                    else if (euroval.Substring(0, 2) == "12")
                    {
                        result1 += "δώδεκα ";
                    }
                    else
                    {
                        result1 += _ds[Convert.ToInt16(euroval.Substring(0, 1)) - 1];
                        if (euroval.Substring(1, 1) != "0")
                        {
                            result1 += _1k[Convert.ToInt16(euroval.Substring(1,1))];
                        }
                    }

                    result1 += _ks[1];
                    euroval = euroval.Substring(2, 3);
                    if (euroval == "000")
                    {
                        goto PosEnd;
                    }
                    else
                    {
                        goto case 3;
                    }

                case 4: // 1000
                    if (euroval.Substring(0, 1) == "0")
                    {
                        euroval = euroval.Substring(1, 3);
                        goto case 3;
                    }
                    
                    if (euroval.Substring(0, 1) == "1")
                    {
                        if (euroval.Substring(1, 3) == "000")
                        {
                            result1 += _ks[0];
                            goto PosEnd;
                        }
                        else
                        {
                            result1 += _ks[0];
                            euroval = euroval.Substring(1, 3);
                            goto case 3;
                        }
                    }
                    else
                    {
                        result1 += _1[Convert.ToInt16(euroval.Substring(0, 1))] + _ks[1];
                        if (euroval.Substring(1, 3) == "000")
                        {
                            goto PosEnd;
                        }
                        else
                        {
                            euroval = euroval.Substring(1, 3);
                            goto case 3;
                        }
                    }                

                case 3: //100
                    if (euroval.Substring(0, 1) == "0")
                    {
                        euroval = euroval.Substring(1, 2);
                        goto case 2;
                    }
                    
                    if (euroval == "100")
                    {
                        result1 += "εκατό";
                        goto PosEnd;
                    } 
                    
                    result1 += _hs[Convert.ToInt16(euroval.Substring(0, 1)) - 1];

                    if (euroval.Substring(1, 1) == "0")
                    {
                        euroval = euroval.Substring(2, 1);
                        goto PosMon;
                    }
                    euroval = euroval.Substring(1,2);
                    goto case 2;

                case 2: //10
                    if (euroval.Substring(0, 1) == "0")
                    {
                        euroval = euroval.Substring(1, 1);
                        goto PosMon;
                    }

                    if (euroval == "11")
                    {
                        result1 += "έντεκα ";
                        goto PosEnd;
                    }
                    else if (euroval == "12")
                    {
                        result1 += "δώδεκα ";
                        goto PosEnd;
                    }
                    else
                    {
                        result1 += _ds[Convert.ToInt16(euroval.Substring(0, 1)) - 1];
                        if (euroval.Substring(1, 1) == "0")
                        {
                            goto PosEnd;
                        }
                    }

                    euroval = euroval.Substring(euroval.Length-1,1);
                    break;
            }
            
PosMon: 
            //monades
            result1 += _1[Convert.ToInt16(euroval)];
PosEnd:
            result1 += euro;

            string result = result1;
          
            if (hascents) {

                if (centval.Substring(0, 1) == "0")
                {
                    centval = centval.Substring(1, 1);
                    goto PosMonCent;
                }

                if (centval == "11")
                {
                    result2 += "έντεκα ";
                    goto PosEndCent;
                }
                else if (centval == "12")
                {
                    result2 += "δώδεκα ";
                    goto PosEndCent;
                }
                else
                {
                    result2 += _ds[Convert.ToInt16(centval.Substring(0, 1)) - 1];
                    if (centval.Substring(1, 1) == "0")
                    {
                        goto PosEndCent;
                    }
                    centval = centval.Substring(1, 1);
                }

PosMonCent:
                //monades
                result2 += _1[Convert.ToInt16(centval)];
PosEndCent:

            result2 += cent;
                
            result = result1 + "και " + result2;
            
            }
            
            
                return result;
        }

    }
}
