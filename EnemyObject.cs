using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField]
    float speed;

    SpriteRenderer spriteRenderer;

    float HeightPosition { get; set; }
    Transform myTransform;

    Vector3 startPosition;

    bool isActive;

    CameraShaker cs;

	void Start ()
    {
        myTransform = transform;
        isActive = false;

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        cs = GameObject.Find("Main Camera").GetComponent<CameraShaker>();
	}

	void Update ()
    {
        if(isActive)
        {
            myTransform.position = new Vector3(myTransform.position.x + (speed * Time.deltaTime), HeightPosition);
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            enabled = false;
            PuntuationController.instance.SetMaxScore();
            BehaviourController.instance.gameOver = true;
            cs.shouldShake = true;
        }
        else if(collider.tag == "Trigger")
        {
            Repositionate();
        }
        else if(collider.tag == "Puntuation")
        {
            PuntuationController.score++;
            PuntuationController.instance.UpdateScore();
        }
    }

    public void SpawnObject()
    {
        isActive = true;
        PullController.instance.GetList().Remove(this);

        if (Random.Range(1, -1) > 0)
        {
            myTransform.position = SpawnerEnemies.instance.GetPosition()[0];
            HeightPosition = SpawnerEnemies.instance.GetPosition()[0].y;
            spriteRenderer.sortingOrder = 2;
        }
        else
        {
            myTransform.position = SpawnerEnemies.instance.GetPosition()[1];
            HeightPosition = SpawnerEnemies.instance.GetPosition()[1].y;
            spriteRenderer.sortingOrder = 4;
        }
    }

    void Repositionate()
    {
        isActive = false;
        PullController.instance.GetList().Add(this);
        myTransform.position = new Vector3(0, 100);
    }

    
}
