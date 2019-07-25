using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class SelectUI : MonoBehaviour
{
    public TMP_Dropdown selectRace;
    public TMP_Dropdown selectStyle;
    void Start()
    {
        List<string> races = new List<string>(Data.Singleton.raceDictionary.Keys);
        selectRace.AddOptions(races);

        List<string> styles = new List<string>(Data.Singleton.styleDictionary.Keys);
        selectStyle.AddOptions(styles);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void Play(){
       string t = selectRace.options[selectRace.value].text;
       Data.Singleton.selectedRace = Data.Singleton.raceDictionary[t];
       string s = selectStyle.options[selectStyle.value].text;
       Data.Singleton.selectedStyle = Data.Singleton.styleDictionary[s];
        SceneManager.LoadScene("SampleScene");
    }
}
