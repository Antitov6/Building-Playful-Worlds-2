using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRandomColor : MonoBehaviour
{
    Text text;
    [SerializeField] List<Color> colors;
    Color color;

    float time;
    int randomTime;

    private void Start()
    {
        text = GetComponent<Text>();
        randomTime = Random.Range(1, 6);
        text.color = colors[Random.Range(0, colors.Count)];
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= randomTime)
        {
            color = colors[Random.Range(0, colors.Count)];
            text.color = color;
            time = 0;
            randomTime = Random.Range(1, 6);
        }
    }
}
