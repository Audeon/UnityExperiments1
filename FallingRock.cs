using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class FallingRock : MonoBehaviour
{

    public Vector2 fallSpeedMinMax = new Vector2(7, 13);
    private float fallSpeed;
    
    // Update is called once per frame
    private void Start()
    {
        fallSpeed = (Mathf.Lerp(fallSpeedMinMax.x, fallSpeedMinMax.y, DifficultyManager.GetDifficultyPercent())) + Random.Range(1.5f, -1.5f);
        print($"Fall Speed: {fallSpeed}");
    }

    void Update()
    {
        transform.Translate(Vector2.down * (fallSpeed * Time.deltaTime));
        if (transform.position.y < (-Camera.main.orthographicSize + -2))
        {
            Destroy(transform.gameObject);
        }
    }
}
