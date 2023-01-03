using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrajectoryManager : MonoBehaviour
{
    [SerializeField] private Image trajButton;
    [SerializeField] private Sprite trajOn;
    [SerializeField] private Sprite trajOff;
    private List<Character> allCharacters;
    
    // Start is called before the first frame update
    void Start()
    {
        allCharacters = GameManagement.Instance.allCharacters;
        trajButton.sprite = trajOn;
    }

    public void ChangeTraj()
    {
        CharacterControl.IsTrajectory = !CharacterControl.IsTrajectory;
        bool isTraj = CharacterControl.IsTrajectory;        
        foreach (Character character in allCharacters)
            character.gameObject.GetComponent<LineRenderer>().enabled = isTraj;
        trajButton.sprite = isTraj ? trajOff : trajOn;
    }
}
