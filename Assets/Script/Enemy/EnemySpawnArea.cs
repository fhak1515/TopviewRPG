using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArea : MonoBehaviour
{
    [SerializeField] float size = 0;
    [SerializeField] string enemyName;
    bool enemySpawn = false;
    GameObject enemy;

    private void Start()
    {
        EnemySpawn();
    }
    void EnemySpawn()
    {
        
        GameObject enemyObject = Resources.Load<GameObject>("Prefab/Enemy/"+ enemyName);
        enemy=Instantiate(enemyObject, this.transform);
        enemy.transform.position += new Vector3(Random.Range(-size/2,size/2),0,Random.Range(-size/2,size/2));
        
    }
    private void OnDestroy()
    {
        Destroy(enemy);
    }
    public void EnemyDie()
    {
        StartCoroutine(EnemySpawnCheck());
    }
    IEnumerator EnemySpawnCheck()
    {
        yield return new WaitForSeconds(3f);
        EnemySpawn();
    }
}
