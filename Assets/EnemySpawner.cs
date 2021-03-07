using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
  public const float SPAWN_INTERVAL = 5.0f;

  public GameObject Prefab;
  public GameObject Target;

  float _lastSpawnTime;
  float _startTime;

  void Start() {
    _lastSpawnTime = 0.0f;

    _startTime = Time.time;
  }

  void Update() {
    bool shouldSpawn = Time.time - _lastSpawnTime >= SPAWN_INTERVAL &&
        Time.time - _startTime >= 20.0f;
    if (shouldSpawn) {
      Spawn();
    }
  }

  private void Spawn() {
    _lastSpawnTime = Time.time;
    float spawnRadius = 5.0f;
    float angle = Random.value * 360.0f;
    Vector3 position = new Vector3(
        spawnRadius * Mathf.Cos(angle),
        0.0f,
        spawnRadius * Mathf.Sin(angle));
    position += gameObject.transform.position;
    GameObject enemyObject = Instantiate(Prefab, position, Quaternion.identity);

    Enemy enemy = enemyObject.GetComponent<Enemy>();
    enemy.Target = Target;
  }

}
