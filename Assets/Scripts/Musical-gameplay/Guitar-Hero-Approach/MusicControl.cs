using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
[System.Serializable]
public class MusicControl : ScriptableObject
{
    public string json;
    public AudioClip clip;
    public Spawner[] spawners;

    public void Serialize()
    {
        SpawnerList list = new SpawnerList();
        list.list = spawners;
        json = JsonUtility.ToJson(list);
    }

    public void Deserialize()
    {
        SpawnerList m = JsonUtility.FromJson<SpawnerList>(json);
        spawners = m.list;
    }

}

[System.Serializable]
public class SpawnerList
{
    public Spawner[] list;
}
