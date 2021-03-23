using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  public Vector3 Direction = new Vector3(0.0f, 0.0f, 1.0f);
  public float Speed = 50.0f;

  private float _spawnTime;

  void Start() {
    _spawnTime = Time.time;
  }

  void Update() {
    Rigidbody rigidbody = GetComponent<Rigidbody>();
    rigidbody.velocity = Direction * Speed;

    if (Time.time - _spawnTime > 1.0f) {
      gameObject.SetActive(false);
    }
  }
}
