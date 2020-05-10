using UnityEngine;

public class Tile : MonoBehaviour
{

   [SerializeField] private float step = 0.01f;
    private Vector3 CurrentPosition;
    private Vector3 NewPosition;
    private float progress;
    private bool flag = false;

    public Vector2 GetPosition() { return CurrentPosition; }
    public void Start() { SetCurrentPosition(); }
    public void SetCurrentPosition() { CurrentPosition = transform.localPosition; }

    public void SetNewPosition(Vector2 pos)
    {
        progress = 0;
        NewPosition = pos;
        flag = true;
    }

    private void GoNewPosition(Vector3 position)
    {
        if(progress < 1)
        {
            transform.localPosition = Vector2.Lerp(CurrentPosition, NewPosition, progress);
            progress += step;
        }
        else
        {
            flag = false;
            SetCurrentPosition();
        }
    }
    private void FixedUpdate() 
    {
        if (flag) GoNewPosition(NewPosition);
    }
}
