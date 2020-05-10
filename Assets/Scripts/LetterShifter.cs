using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LetterShifter : MonoBehaviour
{
    private System.Random rng = new System.Random();
    private List<Vector2> Coordinates = new List<Vector2>();

    public void StartShuffleTiles(List<Tile> tilesList)
    {
        RandomizePosition(tilesList); 
    }

    public void ClearData() { Coordinates.Clear(); }

    public void RandomizePosition(List<Tile> tilesList)
    {
        UpdateCoodnates(tilesList);
        Shuffle(Coordinates);
        for (int i = 0; i < tilesList.Count; i++)
        {
            tilesList[i].SetNewPosition(Coordinates[i]);
        }
    }

    private void Shuffle<Vector2>(IList<Vector2> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Vector2 value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void UpdateCoodnates(List<Tile> tilesList)
    {
        Coordinates.Clear();
        for (int i = 0; i < tilesList.Count; i++)
        {
            Coordinates.Add(tilesList[i].GetPosition());
        }
    }
}
