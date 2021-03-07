using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rover : MonoBehaviour {
  public GameObject[] Tyres;

  public static int NO_MOVE = 0;
  public static int FORWARD = 1;
  public static int BACKWARD = -1;

  public static int NO_ROTATE = 0;
  public static int LEFT = -1;
  public static int RIGHT = 1;

  // Either ROVER.NO_MOVE, Rover.FORWARD or Rover.BACKWARD
  public int MoveDirection = 0;
  // Either ROVER.NO_ROTATE, Rover.LEFT or Rover.RIGHT
  public int RotateDirection = 0;
  public bool Shooting = false;

  public GameObject BulletPrefab;

  private Rigidbody _rigidbody;
  private float _tyreRotation = 0.0f;
  private bool _shooting = false;
  private bool _dead = false;

  void Start() {
    _rigidbody = GetComponent<Rigidbody>();
  }

  void Update() {
    float roverThrust = 1000.0f;

    if (MoveDirection == FORWARD) {
      _rigidbody.AddForce(transform.forward * roverThrust * Time.deltaTime);
    } else if (MoveDirection == BACKWARD) {
      _rigidbody.AddForce(-transform.forward * roverThrust * Time.deltaTime);
    }

    float maxSpeed = 2.0f;

    if (_rigidbody.velocity.magnitude > maxSpeed) {
      _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
    }

    float tyreAngle = _rigidbody.velocity.magnitude * 360.0f;
    _tyreRotation += MoveDirection * tyreAngle * Time.deltaTime;

    foreach (GameObject tyre in Tyres) {
      tyre.transform.localRotation = Quaternion.Euler(_tyreRotation, 0.0f, 90.0f);
    }

    float rotationThrust = 9.0f;

    if (RotateDirection == LEFT) {
      Vector3 rotation = new Vector3(0.0f, -rotationThrust * Time.deltaTime, 0.0f);
      _rigidbody.AddRelativeTorque(rotation, ForceMode.Impulse);
    } else if (RotateDirection == RIGHT) {
      Vector3 rotation = new Vector3(0.0f, rotationThrust * Time.deltaTime, 0.0f);
      _rigidbody.AddRelativeTorque(rotation, ForceMode.Impulse);
    }

    float maxRotationSpeed = 3.0f;

    if (Mathf.Abs(_rigidbody.angularVelocity.y) > maxRotationSpeed) {
      _rigidbody.angularVelocity = new Vector3(
          0.0f,
          Mathf.Sign(_rigidbody.angularVelocity.y) * maxRotationSpeed,
          0.0f);
    }

    if (Shooting) {
      if (!_shooting) {
        _shooting = true;
        Shoot();
      }
    } else {
      _shooting = false;
    }
  }

  private void Shoot() {
    Vector3 position = transform.position + transform.forward * 1.074f;
    GameObject bulletObject = Instantiate(BulletPrefab, position, Quaternion.identity);
    Bullet bullet = bulletObject.GetComponent<Bullet>();
    bullet.Direction = transform.forward;
  }
}
