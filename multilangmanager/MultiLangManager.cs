using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.Threading;

/*

    This system does not work in mobile and WebGL.
    for detailed information: https://docs.unity3d.com/ScriptReference/Application-streamingAssetsPath.html

*/

public enum FileLocationType
{
    StreamingAssets
    // Custom :TODO
}
public class MultiLangManager : MonoBehaviour
{

    private static MultiLangManager instance;
    public static MultiLangManager Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("Settings")]
    [SerializeField] FileLocationType FileLocationType = FileLocationType.StreamingAssets;
    [Tooltip("Specifies the folder path in Streaming Assets.")]
    [SerializeField] string Location = "i18n";
    [Space]
    [Tooltip("Selects the language of the system when the game starts.")]
    [SerializeField] public bool GetSystemLanguage = true;
    [SerializeField] public MultiLangManagerUtils.LanguageCode DefaultLanguage = MultiLangManagerUtils.LanguageCode.EN_uk;
    [SerializeField] public MultiLangManagerUtils.LanguageCode ActiveLanguage = MultiLangManagerUtils.LanguageCode.EN_uk;
    [SerializeField] public MultiLangManagerUtils.LanguageCode[] Languages = new MultiLangManagerUtils.LanguageCode[3]{ MultiLangManagerUtils.LanguageCode.EN_us, MultiLangManagerUtils.LanguageCode.EN_uk, MultiLangManagerUtils.LanguageCode.TR_tr };

    public Dictionary<string, string>AllText = new Dictionary<string, string>();

    private string FolderLocation = "";
    private string FileLocation = "";

    private Action UpdateCallback = null;

    private bool loopCheck = false;
    public int error = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
            Destroy(gameObject);
    }

    void Start()
    {
        this.PrepareVariables();
        this.PrepareFiles();
    }

    private void PrepareVariables()
    {
        this.FolderLocation = Path.Combine(Application.streamingAssetsPath, Location);
        this.UpdateLanguageSettings(MultiLangManagerUtils.ConvertToLanguageCode(Application.systemLanguage));
    }

    private void PrepareFiles()
    {
        if(!Directory.Exists(this.FolderLocation)) Directory.CreateDirectory(this.FolderLocation);
    }

    private void UpdateLanguageSettings(MultiLangManagerUtils.LanguageCode languageCode)
    {
        this.ActiveLanguage = (GetSystemLanguage) ? languageCode : this.ActiveLanguage;
        this.CheckActiveLanguage();
        ReadAllValues();
    }

    private void UpdateFileLocation()
    {
        FileLocation = Path.Combine(FolderLocation, this.ActiveLanguage.ToString() + ".json");
    }

    private void CheckActiveLanguage()
    {
        if (!this.Languages.Any((lang => lang == this.ActiveLanguage))) this.ActiveLanguage = this.DefaultLanguage;
        UpdateFileLocation();

        if (!File.Exists(FileLocation))
        {
            File.Create(FileLocation);
            this.ActiveLanguage = this.DefaultLanguage;
            if (!loopCheck)
            {
                CheckActiveLanguage();
                loopCheck = true;
                error = 0;
            }
            else
            {
                error = 1;
            }
        }
    }

    private void ReadAllValues()
    {
        if (!File.Exists(FileLocation)) return;
        AllText.Clear();

        string AllTextString = File.ReadAllText(FileLocation);
        List<Tuple<string, string>> buffTuple = MultiLangManagerUtils.JSONtoList(AllTextString);
        
        foreach(var item in buffTuple) AllText.Add(item.Item1, item.Item2);

        if (UpdateCallback != null) UpdateCallback();
    }

    public string GetText(string textCode)
    {
        if (AllText.ContainsKey(textCode))
            return AllText[textCode];
        else
            return textCode;
    }

    public string GetText(string textCode, string[] variables)
    {
        List<string> buffL = new List<string>();
        
        foreach(var item in variables)
            buffL.Add(item.ToString());

        return GetText(textCode, buffL);
    }

    public string GetText(string textCode, List<string> variables)
    {
        if (!AllText.ContainsKey(textCode)) return textCode;

        if (AllText[textCode].IndexOf("%s") > -1)
        {
            string buff = AllText[textCode];
            string[] buffs = buff.Split("%s");

            buff = "";

            for(int i = 0; i > buffs.Length; i++)
            {
                buff += buffs[i];
                if (variables[i] != null)
                    buff += variables[i];
            }

            return buff;

        }else return AllText[textCode];
    }

    public void SetUpdateCallback(Action callback)
    {
        UpdateCallback = callback;
    }
}
