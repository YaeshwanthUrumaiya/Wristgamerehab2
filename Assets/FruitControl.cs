using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitControl : MonoBehaviour
{
    public float speed = 1f;
    public float KillYValue = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

        if (transform.position.y < KillYValue)
        { // Adjusted comparison operator
            Destroy(gameObject);
        }
    }
}
