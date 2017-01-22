using UnityEngine;
using System.Collections;

public class Invisibility : MonoBehaviour {
    private SpriteRenderer mySprite;
	// Use this for initialization
	void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        mySprite.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
