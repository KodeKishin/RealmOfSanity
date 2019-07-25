using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;

public class Data : MonoBehaviour
{
    public Dictionary<string, Race> raceDictionary = new Dictionary<string, Race>();
    public Dictionary<string, Style> styleDictionary = new Dictionary<string, Style>();
    public List<RenderMesh> renderMeshes;

    public Race selectedRace;
    public Style selectedStyle;
    
    public static Data Singleton;
    void Awake(){
        Singleton = this;
        
        var raceC = Resources.LoadAll<TextAsset>("Races");
        var styleC = Resources.LoadAll<TextAsset>("Styles");
        foreach(var race in raceC)
            raceDictionary.Add(race.name, UnpackRace(race.text));
        foreach(var style in styleC)
            styleDictionary.Add(style.name, UnpackStyle(style.text));






        DontDestroyOnLoad(gameObject);
    }


    private Race UnpackRace(string text){
        string[] t = text.Split(new[] {"\n"}, System.StringSplitOptions.None);
        Race r = new Race();
        r.health = float.Parse(t[0]);
        r.energy = float.Parse(t[1]);
        r.speed = float.Parse(t[2]);
        r.size = float.Parse(t[3]);
        return r;
    }


    private Style UnpackStyle(string text){
        string[] t = text.Split(new[] {"\n"}, System.StringSplitOptions.None);
        Style s = new Style();
        s.armor = float.Parse(t[0]);
        return s;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
