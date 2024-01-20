using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] Birds;
    [SerializeField] float spawnTime,YPosition;
    [SerializeField] GameObject Eggs;

    public static GameManager instance;
    public int target=15;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(SpawnWait());
    }


    void Spawn()
    {
        
        Vector3 position =new Vector3(Birds[Random.Range(0,Birds.Length)].transform.position.x,YPosition,0f);
        Instantiate(Eggs, position, Quaternion.identity);
    }

    IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(spawnTime);
        Spawn();
        StartCoroutine(SpawnWait());
    }
}
