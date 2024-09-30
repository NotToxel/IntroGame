using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour {

    public Vector2 moveValue;
    public float speed;
    private int countPickUps;

    private UIDocument _document;

    private Label _score;
    private Label _win;
    private int numPickUps = 7;

    void Start() {
        countPickUps = 0;
        _document = GetComponent<UIDocument>();
        _score = _document.rootVisualElement.Q<Label>("Score");
        _score.text = "Score: " + countPickUps.ToString();
        _win = _document.rootVisualElement.Q<Label>("Win");
    }


    void OnMove (InputValue value) {
        moveValue = value.Get <Vector2>();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3 (moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce (movement * speed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter (Collider other) {
        if( other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            countPickUps++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        _score.text = "Score: " + countPickUps.ToString();
        if (countPickUps >= numPickUps)
        {
            _win.text = "You Win!";
        }
    }
}