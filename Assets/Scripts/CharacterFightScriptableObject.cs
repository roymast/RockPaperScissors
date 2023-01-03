using UnityEngine;

[CreateAssetMenu(fileName ="Characters", menuName ="ScriptableObjects/Characters")]
public class CharacterFightScriptableObject : ScriptableObject
{
    public string characterName;
    public Sprite sprite;
    public string characterIWin;
    public Vector2 pos;
}
