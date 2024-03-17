using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    [SerializeField]
    Vector2 topLeft = Vector2.zero;

    [SerializeField]
    Vector2 bottomRight = Vector2.zero;

    [SerializeField]
    GameObject coffee;

    private int coffeeCount = 0;

    private void Start()
    {
        InvokeRepeating("SpawnCoffee", 3, 10);
    }

    private void SpawnCoffee()
    {
        if (coffeeCount > 3)
            return;

        Instantiate(coffee, new Vector3(Random.Range(topLeft.x, bottomRight.x), Random.Range(topLeft.y, bottomRight.y), transform.position.z), Quaternion.identity, this.transform);
    }

}
