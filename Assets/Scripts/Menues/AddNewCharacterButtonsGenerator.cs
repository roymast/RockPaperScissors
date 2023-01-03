using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AddNewCharacterButtonsGenerator : MonoBehaviour
{
    [SerializeField] private CharactersGenerator charactersGenerator;
    [SerializeField] private GameObject buttonTemplate;
    // Start is called before the first frame update
    void Start()
    {
        CharacterFightScriptableObject[] characters = charactersGenerator.GetCharactersSciptableObjects();
        foreach (CharacterFightScriptableObject current in characters)        
            CreateButton(current);        
    }   
    
    void CreateButton(CharacterFightScriptableObject character)
    {
        GameObject gameObject = Instantiate(buttonTemplate, transform);
        gameObject.GetComponent<Image>().sprite = character.sprite;
        gameObject.GetComponent<Button>().onClick.AddListener(() => charactersGenerator.AddCharacter(character));
        gameObject.name = "CreateNew_"+character.characterName;
    }
}
