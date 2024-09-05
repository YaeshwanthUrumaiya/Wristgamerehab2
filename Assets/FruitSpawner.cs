using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public GameObject Bomb; 
    public float BombChance = 0.2f;
    public float fixedYPosition = 0f;
    public float minX = -10f;
    public float maxX = 10f;
    public float spawnInterval = 2f;
    public UserMoveScript User;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), spawnInterval, spawnInterval);
    }

    void SpawnObject()
    {
        if(User.isGameOver == false){
            if (Random.value > BombChance){
                int index = Random.Range(0, prefabs.Count);
                GameObject selectedPrefab = prefabs[index];

                GameObject instance = Instantiate(selectedPrefab);
                float randomX = Random.Range(minX, maxX);
                instance.transform.position = new Vector3(randomX, fixedYPosition, 0);
            }
            else{
                GameObject instance = Instantiate(Bomb);
                float randomX = Random.Range(minX, maxX);
                instance.transform.position = new Vector3(randomX, fixedYPosition, 0);
            }
        }
    }
}
