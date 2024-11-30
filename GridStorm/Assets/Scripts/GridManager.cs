using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridManager : MonoBehaviour
{
    public Sprite sprite;
    public float[,] Grid;
    private int Horizontal, Vertical;
    public int Column, Row;

    private void Awake()
    {   /*
        Vertical = (int)Camera.main.orthographicSize; //how tall//prolly not used along with horizontal
        Horizontal = Vertical * (Screen.width / Screen.height); // how wide
        Column = 3; //how many cells vertically
        Row = 3; //how many cells horizontaly
        */

        Column =  PlayerPrefs.GetInt("x");
        Row = PlayerPrefs.GetInt("y");

        Grid = new float[(int)Column, (int)Row];




        for (int i = 0; i < Column; i++)
        {
            for (int j = 0; j < Row; j++)
            {
                Grid[i, j] = (i * 0.1f + j * 0.1f) / 2;
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    private void SpawnTile(float x,float y, float value)
    {
        GameObject g = new GameObject("X: " + x + "Y: " + y);
        g.transform.position = new Vector3(             x-((Column-1)/2)           ,             y-((Row-1)/2)            )                                                            ;
        if (Column%2==0)
        {
            g.transform.position = new Vector2(g.transform.position.x - 0.5f, g.transform.position.y);
        }
        if (Row%2==0)
        {
            g.transform.position = new Vector2(g.transform.position.x, g.transform.position.y - 0.5f);
        }
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value%255, value%255, value%255);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("x", Column);
            PlayerPrefs.SetInt("y",Row);
            SceneManager.LoadScene(0);
        }
    }



}
