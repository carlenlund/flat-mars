using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
  public Rover Rover;
  
  private void Start() {
  }

  public void Update() {
  }

  public void OnButtonDown(GameObject gameObject) {
    String buttonName = gameObject.name;
    Debug.Log("Button down: " + buttonName);
    switch (buttonName) {
      case "ButtonShoot":
        Rover.Shooting = true;
        break;
      case "ButtonForward":
        Rover.MoveDirection = Rover.FORWARD;
        break;
      case "ButtonBackward":
        Rover.MoveDirection = Rover.BACKWARD;
        break;
      case "ButtonLeft":
        Rover.RotateDirection = Rover.LEFT;
        break;
      case "ButtonRight":
        Rover.RotateDirection = Rover.RIGHT;
        break;
      default:
        Debug.LogError("Invalid button name: " + buttonName);
        break;
    }
  }

  public void OnButtonUp(GameObject gameObject) {
    String buttonName = gameObject.name;
    Debug.Log("Button up: " + buttonName);
    switch (buttonName) {
      case "ButtonShoot":
        Rover.Shooting = false;
        break;
      case "ButtonForward":
        Rover.MoveDirection = Rover.NO_MOVE;
        break;
      case "ButtonBackward":
        Rover.MoveDirection = Rover.NO_MOVE;
        break;
      case "ButtonLeft":
        Rover.RotateDirection = Rover.NO_ROTATE;
        break;
      case "ButtonRight":
        Rover.RotateDirection = Rover.NO_ROTATE;
        break;
      default:
        Debug.LogError("Invalid button name: " + buttonName);
        break;
    }
  }
}
