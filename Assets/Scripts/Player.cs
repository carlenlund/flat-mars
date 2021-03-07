using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public const float MOVEMENT_SPEED = 2.0f;

  public event EventHandler<DartThrowEventArgs> DartThrowEvent;

  public class DartThrowEventArgs : EventArgs {
    public Vector3 Position { get; private set; }
    public Vector3 Direction { get; private set; }

    public DartThrowEventArgs(Vector3 position, Vector3 direction) {
      Position = position;
      Direction = direction;
    }
  }

  void Start() {
  }

  void Update() {
  }

  void ThrowDart() {
    Vector3 position = transform.position;
    position.y += 2.0f;
    Vector3 direction = transform.forward;
    DartThrowEventArgs eventArgs =
        new DartThrowEventArgs(position, direction);
    DartThrowEvent?.Invoke(this, eventArgs);
  }
}
