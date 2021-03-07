using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using Valve.VR.InteractionSystem;

class Button : MonoBehaviour {
  public Game Game;

  public void OnButtonDown(Hand fromHand) {
    fromHand.TriggerHapticPulse(1000);

    Game.OnButtonDown(gameObject);
  }

  public void OnButtonUp(Hand fromHand) {
    Game.OnButtonUp(gameObject);
  }
}