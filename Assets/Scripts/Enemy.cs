using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  public GameObject Target;
  public float Speed = 1.0f;

  void Start() {
  }

  void Update() {
    transform.LookAt(Target.transform);

    transform.position += transform.forward * Speed * Time.deltaTime;
  }
}
