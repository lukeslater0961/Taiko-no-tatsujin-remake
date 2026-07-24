using UnityEngine;

public class SongButton : MonoBehaviour
{
    public void SelectSong(int index)
    {
        LevelManager.instance.SetCurrentSong(index);
    }
}
