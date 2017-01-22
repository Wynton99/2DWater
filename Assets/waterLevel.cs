using UnityEngine;
using System.Collections;

public class waterLevel : MonoBehaviour {
    public BuoyancyEffector2D dynamicWater;
    int counter = 0;
    bool isTime = true;
    public float High;
    public float Low;
    public float startTime;
    // Use this for initialization
    void Start () {
        dynamicWater = GetComponent<BuoyancyEffector2D>();
        transform.localScale = new Vector3(transform.localScale.x, Low, transform.localScale.z);
        
    }
	
	// Update is called once per frame
	void Update () {
        int countTo = (int)startTime;
        if (counter == countTo)
        {
            if (isTime)
            {
                transform.localScale = new Vector3(transform.localScale.x, High, transform.localScale.z);
            }
        } else if (counter == countTo + 50)
        {
            transform.localScale = new Vector3(transform.localScale.x, Low, transform.localScale.z);
            counter = 0;
        }
        counter++;
	}
}