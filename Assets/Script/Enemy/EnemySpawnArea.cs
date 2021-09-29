using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnArea : MonoBehaviour
{
    [SerializeField] float size = 0;
    [SerializeField] string enemyName;
    [SerializeField] float respawnTime = 1f;
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
        enemy.GetComponent<Enemy>().SetEnemySpawnArea(this);
        
    }
    private void OnDestroy()
    {
        if (enemy != null)
        {
            Destroy(enemy);
        }
    }
    public void EnemyDie()
    {
        StartCoroutine(EnemySpawnCheck());
    }
    IEnumerator EnemySpawnCheck()
    {
        yield return new WaitForSeconds(respawnTime);
        EnemySpawn();
    }
}
