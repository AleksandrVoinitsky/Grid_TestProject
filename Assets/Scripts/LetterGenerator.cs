using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterGenerator : MonoBehaviour
{
    [SerializeField] private List<Sprite> characters = new List<Sprite>();
    [SerializeField] private GameObject tile;
    [SerializeField] private Slider AreaSlider;

    private int xSize;
    private int ySize;
    private Vector2 areaForLetters;
    private Vector2 GridCenter;
    private GameObject[,] tiles;
    private List<Tile> tilesList = new List<Tile>();

    public List<Tile> GetTilesList() { return tilesList; }

    public void CreateBoard(InputFieldValues values)
    {
        SetAreaSize();
        tilesList.Clear();
        if (tiles != null) RemoveBoard(tiles);
        tile.transform.localScale = new Vector3(1, 1, 1);
        xSize = values.Width;
        ySize = values.Height;
        if (xSize == 0 || ySize == 0) return;
        tile.transform.localScale /= Mathf.Max(xSize, ySize);
        Vector2 offset = new Vector2(areaForLetters.x / xSize, areaForLetters.y / ySize);
        tiles = new GameObject[xSize, ySize];
        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (offset.x * x),
                    startY + (offset.y * y), 0), tile.transform.rotation, this.transform); tiles[x, y] = newTile;
                Sprite newSprite = characters[Random.Range(0, characters.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;
                tilesList.Add(newTile.GetComponent<Tile>());
            }
        }
        MoveToCenter(offset.x, offset.y);
    }

    private void MoveToCenter(float offst_x, float offst_y)
    {
        GridCenter = new Vector2(-((float)xSize / 2) * offst_x + offst_x / 2, -((float)ySize / 2) * offst_y + offst_y / 2);
        transform.position = new Vector3(GridCenter.x, GridCenter.y, 0);
    }

    private void RemoveBoard(GameObject[,] tiles)
    {
        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Destroy(tiles[x, y]);
            }
        }
    }

    private void SetAreaSize() { areaForLetters = new Vector2(AreaSlider.value, AreaSlider.value); }
}
