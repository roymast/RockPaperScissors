using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public event Action<string, string> OnChangeSprite;

    public CharacterFightScriptableObject selfCharacter;
    private SpriteRenderer spriteRenderer;

    
    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = selfCharacter.sprite;
        gameObject.name = selfCharacter.characterName;                
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(TouchEnemy(collision));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(TouchEnemy(collision));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(TouchEnemy(collision));
    }
    IEnumerator TouchEnemy(Collision2D collision)        
    {
        yield return null;
        Character collisionCharacter = collision.gameObject.GetComponent<Character>();
        if (collisionCharacter == null)
            yield break;

        CharacterFightScriptableObject enemy = collisionCharacter.selfCharacter;
        if (enemy.characterIWin == selfCharacter.characterName)
            SwitchSprite(enemy);
    }
    IEnumerator TouchEnemy(Collider2D collision)        
    {
        yield return null;
        Character collisionCharacter = collision.gameObject.GetComponent<Character>();
        if (collisionCharacter == null)
            yield break;

        CharacterFightScriptableObject enemy = collisionCharacter.selfCharacter;
        if (enemy.characterIWin == selfCharacter.characterName)
            SwitchSprite(enemy);       
    }

    private void SwitchSprite(CharacterFightScriptableObject switchTo)
    {
        OnChangeSprite?.Invoke(selfCharacter.characterName, switchTo.characterName);
        selfCharacter = switchTo;
        spriteRenderer.sprite = selfCharacter.sprite;
        gameObject.name = selfCharacter.characterName;        
    }
}
