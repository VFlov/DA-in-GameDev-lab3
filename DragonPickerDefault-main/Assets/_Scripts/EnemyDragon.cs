using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    public GameObject dragonEggPrefab;
    public float speed = 1;
    public float timeBetweenEggDrops = 0.5f;
    public float leftRightDistance = 10f;
    public float chanceDirection = 0.1f;

    [SerializeField] private bool _useSpeedUp;

    [SerializeField] [Range(0, 10)] private float eggSpeed = 1f;
    void Start()
    {
        Invoke("DropEgg", 2f);
    }

    void DropEgg(){
        Vector3 myVector = new Vector3(0.0f, eggSpeed, 0.0f);
        GameObject egg1 = Instantiate<GameObject>(dragonEggPrefab);
        egg1.transform.localScale = new Vector3(dragonEggPrefab.transform.localScale.x,
                                               dragonEggPrefab.transform.localScale.y,
                                               dragonEggPrefab.transform.localScale.z);

        egg1.transform.position = transform.position + myVector;
        Invoke("DropEgg", timeBetweenEggDrops);
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;    
        transform.position = pos;

        if (pos.x < -leftRightDistance){
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftRightDistance){
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate() {
        if (Mathf.Abs(speed) >= 12) return;
        if (Random.value < chanceDirection)
        {
            if (_useSpeedUp) speed *= -1.05f;
            else speed *= -1;
        }
    }
}
