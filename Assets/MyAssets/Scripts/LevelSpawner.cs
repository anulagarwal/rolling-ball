using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] levelsPrefab;
    public Material[] skybox;

    public void SpawnLevel(int levelNum)
    {
        Instantiate(levelsPrefab[levelNum], Vector3.zero, Quaternion.identity);

        if (levelNum > 20)
        {
            RenderSettings.skybox = skybox[0];
        }
        else if (levelNum > 40)
        {
            RenderSettings.skybox = skybox[1];
        }
        else if (levelNum > 60)
        {
            RenderSettings.skybox = skybox[2];
        }
        else if (levelNum > 80)
        {
            RenderSettings.skybox = skybox[3];
        }
    }
}
