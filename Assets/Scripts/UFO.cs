using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Transform StartMarker;
    public Transform Endmarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeylength;
    // Start is called before the first frame update
    void Start()
    {
        startTime =Time.time;
        journeylength = Vector3.Distance(StartMarker.position, Endmarker.position);
    
    }

    // Update is called once per frame
    void Update()
    {
        float distCovered = (Time.time -startTime) * speed;
        float fracjourney = distCovered / journeylength;
        transform.position= Vector2.Lerp(StartMarker.position, Endmarker.position, Mathf.PingPong (fracjourney, 1));
    }
}
