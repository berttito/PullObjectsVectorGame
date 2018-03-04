using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour {

    [SerializeField] List<Vector3> positions;

    public static SpawnerEnemies instance;

    [SerializeField]
    float frequence;

    public float Multiplier { get; set; }

    void Awake()
    {
        instance = this;
    }

    void Start ()
    {
        Multiplier = 1;
        Invoke("SpawnObject", 1);
	}

    void SpawnObject()
    {
        PullController.instance.GetList()[0].SpawnObject();
        Invoke("SpawnObject", frequence * Multiplier);
    }

    public List<Vector3> GetPosition()
    {
        return positions;
    }
}
