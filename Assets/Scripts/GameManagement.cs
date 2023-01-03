using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance { get; private set; }
    public List<Character> allCharacters;
    [SerializeField] private GameOverMenu gameOverMenu;    
    [SerializeField] private CharactersGenerator charactersGenerator;
    [SerializeField] private Dictionary<string, int> AmountPerCharacter;    
    private void Awake()
    {                
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        AmountPerCharacter = new Dictionary<string, int>();

        charactersGenerator.OnNewCharacter += NewCharacterJoined;
        foreach (Character character in charactersGenerator.allCharacters)        
            NewCharacterJoined(character);                            
    }    

    public void NewCharacterJoined(Character newCharacter)
    {
        newCharacter.OnChangeSprite += SomeoneChangedSprite;
        if (AmountPerCharacter.ContainsKey(newCharacter.selfCharacter.characterName))
            AmountPerCharacter[newCharacter.selfCharacter.characterName]++;
        else
            AmountPerCharacter[newCharacter.selfCharacter.characterName] = 1;
    }

    private void SomeoneChangedSprite(string current, string switchTo)
    {
        AmountPerCharacter[current]--;
        AmountPerCharacter[switchTo]++;
        if (IsHasWinner())
            GameOver();
    }        
    private bool IsHasWinner()
    {
        int countLeft = 0;
        foreach (KeyValuePair<string, int> item in AmountPerCharacter)
        {
            if (countLeft > 1)
                return false;
            if (item.Value > 0)
                countLeft++;
        }
        return countLeft == 1;
    }
    public void GameOver()
    {
        Character winner = charactersGenerator.allCharacters[0];        
        gameOverMenu.GameOver(winner.selfCharacter.characterName, winner.selfCharacter.sprite);
    }    
}
