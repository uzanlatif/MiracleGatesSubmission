using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public PlayerController player;
    public ColorBoots colorBoots = new ColorBoots();
    public ColorGlass colorGlass = new ColorGlass();

    public void SaveToJsonGlass(){
        string colorData = JsonUtility.ToJson(colorGlass);
        string filePath = Application.persistentDataPath + "/colorGlass.json";

        System.IO.File.WriteAllText(filePath,colorData);

        Debug.Log(filePath);

    }

    public void SaveToJsonBoots(){
        string colorData = JsonUtility.ToJson(colorBoots);
        string filePath = Application.persistentDataPath + "/colorBoots.json";

        System.IO.File.WriteAllText(filePath,colorData);

        Debug.Log(filePath);

    }

    public void GetDataColorGlass(byte x, byte y, byte z, byte a){
        colorGlass.x = x;
        colorGlass.y = y;
        colorGlass.z = z;
        colorGlass.j = a;
    }
    public void GetDataColorBoots(byte x, byte y, byte z, byte a){
        colorBoots.x = x;
        colorBoots.y = y;
        colorBoots.z = z;
        colorBoots.j = a;
    }

    public void LoadGlass(){
        string filePath = Application.persistentDataPath + "/colorGlass.json";
        string colorGlassData = System.IO.File.ReadAllText(filePath);

        colorGlass = JsonUtility.FromJson<ColorGlass>(colorGlassData);
        player.ChangeGlass(colorGlass.x,colorGlass.y,colorGlass.z,colorGlass.j);
    }

    public void LoadBoots(){
        string filePath = Application.persistentDataPath + "/colorBoots.json";
        string colorBootsData = System.IO.File.ReadAllText(filePath);

        colorBoots = JsonUtility.FromJson<ColorBoots>(colorBootsData);
        player.ChangeBoots(colorBoots.x,colorBoots.y,colorBoots.z,colorBoots.j);

    }

}

[System.Serializable]
public class ColorBoots{
    public byte x,y,z,j;
}

[System.Serializable]
public class ColorGlass{
    public byte x,y,z,j;
}
