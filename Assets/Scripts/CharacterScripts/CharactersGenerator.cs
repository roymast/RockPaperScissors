using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersGenerator : MonoBehaviour
{
    public event Action<Character> OnNewCharacter;
    [SerializeField] private GameObject characterTemplate;
    [SerializeField] private GameObject charactersContainer;

    [SerializeField] private CharacterFightScriptableObject[] characters;    
    [SerializeField] private int amountForEveryCharacter; //if we want them all to be equal amount
    public List<Character> allCharacters;
    [SerializeField] private int ringSize;

    // Start is called before the first frame update
    void Start()
    {
        allCharacters = GameManagement.Instance.allCharacters;
        GameManagement g = GameManagement.Instance;
        StartCoroutine(CreateNewCharacter());
    }    
    IEnumerator CreateNewCharacter()
    {             
        foreach (CharacterFightScriptableObject character in characters)
        {
            for (int i = 0; i < amountForEveryCharacter; i++)
            {
                AddCharacter(character);
                yield return null;
            }            
        }        
    }    
    public void AddCharacter(CharacterFightScriptableObject characterToCreate)
    {
        ArenaSize arenaSize = ArenaSize.Instance;
        Vector2 startingPoint = new Vector2(UnityEngine.Random.Range(arenaSize.Left * 0.9f, arenaSize.Right * 0.9f), UnityEngine.Random.Range(arenaSize.Down * 0.9f, arenaSize.Up * 0.9f));
        characterToCreate.pos = startingPoint;

        GameObject newCharacter = Instantiate(characterTemplate, charactersContainer.transform);
        newCharacter.GetComponent<Character>().selfCharacter = characterToCreate;
        newCharacter.gameObject.transform.position = startingPoint;
        newCharacter.gameObject.name = characterToCreate.characterName;
        allCharacters.Add(newCharacter.GetComponent<Character>());        

        OnNewCharacter?.Invoke(newCharacter.GetComponent<Character>());
    }
    public CharacterFightScriptableObject[] GetCharactersSciptableObjects()
    {
        return characters;
    }
}
