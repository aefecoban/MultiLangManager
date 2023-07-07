using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class MultiLangManagerUtils
{
    public enum LanguageCode
    {
        AF_af,
        AM_am,
        AR_sa,
        AZ_az,
        BE_by,
        BG_bg,
        BN_bd,
        BS_ba,
        CA_es,
        CS_cz,
        CY_gb,
        DA_dk,
        DE_de,
        EL_gr,
        EN_us,
        EN_uk,
        ES_es,
        ET_ee,
        EU_es,
        FA_ir,
        FI_fi,
        FR_fr,
        GA_ie,
        GL_es,
        HE_il,
        HI_in,
        HR_hr,
        HU_hu,
        HY_am,
        ID_id,
        IS_is,
        IT_it,
        JA_jp,
        KA_ge,
        KK_kz,
        KO_kr,
        LT_lt,
        LV_lv,
        MK_mk,
        MN_mn,
        MS_my,
        MT_mt,
        NB_no,
        NL_nl,
        NO_no,
        PL_pl,
        PT_br,
        RO_ro,
        RU_ru,
        SK_sk,
        SL_si,
        SQ_al,
        SR_rs,
        SV_se,
        TH_th,
        TR_tr,
        UK_ua,
        VI_vn,
        ZH_cn
    }

    public static LanguageCode ConvertToLanguageCode(SystemLanguage systemLanguage)
    {
        switch (systemLanguage)
        {
            case SystemLanguage.Afrikaans:
                return LanguageCode.AF_af;
            case SystemLanguage.Arabic:
                return LanguageCode.AR_sa;
            case SystemLanguage.Basque:
                return LanguageCode.EU_es;
            case SystemLanguage.Belarusian:
                return LanguageCode.BE_by;
            case SystemLanguage.Bulgarian:
                return LanguageCode.BG_bg;
            case SystemLanguage.Catalan:
                return LanguageCode.CA_es;
            case SystemLanguage.Chinese:
                return LanguageCode.ZH_cn;
            case SystemLanguage.Czech:
                return LanguageCode.CS_cz;
            case SystemLanguage.Danish:
                return LanguageCode.DA_dk;
            case SystemLanguage.Dutch:
                return LanguageCode.NL_nl;
            case SystemLanguage.English:
                return LanguageCode.EN_us;
            case SystemLanguage.Estonian:
                return LanguageCode.ET_ee;
            case SystemLanguage.Finnish:
                return LanguageCode.FI_fi;
            case SystemLanguage.French:
                return LanguageCode.FR_fr;
            case SystemLanguage.German:
                return LanguageCode.DE_de;
            case SystemLanguage.Greek:
                return LanguageCode.EL_gr;
            case SystemLanguage.Hebrew:
                return LanguageCode.HE_il;
            case SystemLanguage.Hungarian:
                return LanguageCode.HU_hu;
            case SystemLanguage.Icelandic:
                return LanguageCode.IS_is;
            case SystemLanguage.Indonesian:
                return LanguageCode.ID_id;
            case SystemLanguage.Italian:
                return LanguageCode.IT_it;
            case SystemLanguage.Japanese:
                return LanguageCode.JA_jp;
            case SystemLanguage.Korean:
                return LanguageCode.KO_kr;
            case SystemLanguage.Latvian:
                return LanguageCode.LV_lv;
            case SystemLanguage.Lithuanian:
                return LanguageCode.LT_lt;
            case SystemLanguage.Norwegian:
                return LanguageCode.NO_no;
            case SystemLanguage.Polish:
                return LanguageCode.PL_pl;
            case SystemLanguage.Portuguese:
                return LanguageCode.PT_br;
            case SystemLanguage.Romanian:
                return LanguageCode.RO_ro;
            case SystemLanguage.Russian:
                return LanguageCode.RU_ru;
            case SystemLanguage.SerboCroatian:
                return LanguageCode.SR_rs;
            case SystemLanguage.Slovak:
                return LanguageCode.SK_sk;
            case SystemLanguage.Slovenian:
                return LanguageCode.SL_si;
            case SystemLanguage.Spanish:
                return LanguageCode.ES_es;
            case SystemLanguage.Swedish:
                return LanguageCode.SV_se;
            case SystemLanguage.Thai:
                return LanguageCode.TH_th;
            case SystemLanguage.Turkish:
                return LanguageCode.TR_tr;
            case SystemLanguage.Ukrainian:
                return LanguageCode.UK_ua;
            case SystemLanguage.Vietnamese:
                return LanguageCode.VI_vn;
            default:
                return LanguageCode.EN_us; // Varsayılan olarak İngilizce dönüş yapılabilir.
        }
    }

    public static SystemLanguage ConvertToSystemLanguage(LanguageCode languageCode)
    {
        switch (languageCode)
        {
            case LanguageCode.AF_af:
                return SystemLanguage.Afrikaans;
            case LanguageCode.AR_sa:
                return SystemLanguage.Arabic;
            case LanguageCode.EU_es:
                return SystemLanguage.Basque;
            case LanguageCode.BE_by:
                return SystemLanguage.Belarusian;
            case LanguageCode.BG_bg:
                return SystemLanguage.Bulgarian;
            case LanguageCode.CA_es:
                return SystemLanguage.Catalan;
            case LanguageCode.ZH_cn:
                return SystemLanguage.Chinese;
            case LanguageCode.CS_cz:
                return SystemLanguage.Czech;
            case LanguageCode.DA_dk:
                return SystemLanguage.Danish;
            case LanguageCode.NL_nl:
                return SystemLanguage.Dutch;
            case LanguageCode.EN_us:
                return SystemLanguage.English;
            case LanguageCode.ET_ee:
                return SystemLanguage.Estonian;
            case LanguageCode.FI_fi:
                return SystemLanguage.Finnish;
            case LanguageCode.FR_fr:
                return SystemLanguage.French;
            case LanguageCode.DE_de:
                return SystemLanguage.German;
            case LanguageCode.EL_gr:
                return SystemLanguage.Greek;
            case LanguageCode.HE_il:
                return SystemLanguage.Hebrew;
            case LanguageCode.HU_hu:
                return SystemLanguage.Hungarian;
            case LanguageCode.IS_is:
                return SystemLanguage.Icelandic;
            case LanguageCode.ID_id:
                return SystemLanguage.Indonesian;
            case LanguageCode.IT_it:
                return SystemLanguage.Italian;
            case LanguageCode.JA_jp:
                return SystemLanguage.Japanese;
            case LanguageCode.KO_kr:
                return SystemLanguage.Korean;
            case LanguageCode.LV_lv:
                return SystemLanguage.Latvian;
            case LanguageCode.LT_lt:
                return SystemLanguage.Lithuanian;
            case LanguageCode.NO_no:
                return SystemLanguage.Norwegian;
            case LanguageCode.PL_pl:
                return SystemLanguage.Polish;
            case LanguageCode.PT_br:
                return SystemLanguage.Portuguese;
            case LanguageCode.RO_ro:
                return SystemLanguage.Romanian;
            case LanguageCode.RU_ru:
                return SystemLanguage.Russian;
            case LanguageCode.SR_rs:
                return SystemLanguage.SerboCroatian;
            case LanguageCode.SK_sk:
                return SystemLanguage.Slovak;
            case LanguageCode.SL_si:
                return SystemLanguage.Slovenian;
            case LanguageCode.ES_es:
                return SystemLanguage.Spanish;
            case LanguageCode.SV_se:
                return SystemLanguage.Swedish;
            case LanguageCode.TH_th:
                return SystemLanguage.Thai;
            case LanguageCode.TR_tr:
                return SystemLanguage.Turkish;
            case LanguageCode.UK_ua:
                return SystemLanguage.Ukrainian;
            case LanguageCode.VI_vn:
                return SystemLanguage.Vietnamese;
            default:
                return SystemLanguage.English; // Varsayılan olarak İngilizce dönüş yapılabilir.
        }
    }

    public static List<Tuple<string, string>> JSONtoList(string jsonText)
    {
        List<Tuple<string, string>> buff = new List<Tuple<string, string>>();

        jsonText = jsonText.Trim();
        if (jsonText.StartsWith("{")) jsonText = jsonText.Substring(1);
        if (jsonText.StartsWith("}")) jsonText = jsonText.Substring(0, jsonText.Length - 2);

        Regex regex = new Regex("\"(.*?)\"\\s*:\\s*\"((?:\\\\\"|[^\"])*)\"");
        
        MatchCollection matches = regex.Matches(jsonText);

        foreach(Match match in matches)
        {
            string i1 = match.Groups[1].Value;
            string i2 = match.Groups[2].Value;
            if (i1.IndexOf("\"") > -1) i1 = i1.Replace("\\\"", "\"");
            if (i2.IndexOf("\"") > -1) i2 = i2.Replace("\\\"", "\"");
            buff.Add(new Tuple<string, string>(i1, i2));
        }

        return buff;
    }
}
