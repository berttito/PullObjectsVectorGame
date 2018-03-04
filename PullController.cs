using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullController : MonoBehaviour {

    [SerializeField]
    List<EnemyObject> pullList;

    public static PullController instance;

	void Start ()
    {
        instance = this;
	}
	
	void Update ()
    {
		
	}

    public List<EnemyObject> GetList()
    {
        return pullList;
    }
}
