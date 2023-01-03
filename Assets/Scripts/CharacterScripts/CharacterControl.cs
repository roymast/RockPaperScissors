using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Character selfCharacter;
    private List<Character> allCharacters;

    private Vector3 posToFollow;
    [SerializeField] private float speed = 0.05f;

    [SerializeField] private LineRenderer lineRenderer;
    public static bool IsTrajectory;
    // Start is called before the first frame update
    void Start()
    {
        allCharacters = GameManagement.Instance.allCharacters;
        lineRenderer.enabled = IsTrajectory;
        selfCharacter = GetComponent<Character>();
        StartCoroutine(FollowClosestWinableEnemy());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, posToFollow, speed);
        selfCharacter.selfCharacter.pos = transform.position;
    }

    IEnumerator FollowClosestWinableEnemy()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            posToFollow = FindPosToGo();
            DrawWantedDirection(posToFollow);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void DrawWantedDirection(Vector3 posToFollow)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, posToFollow);
    }

    private Vector3 FindPosToGo()
    {
        List<Character> winableEnemys = GetAllWinableEnemys();

        if (winableEnemys.Count == 0)
            return PickRandomPos();

        return GetClosestEnemyFromCollection(winableEnemys);
    }

    private List<Character> GetAllWinableEnemys()
    {
        List<Character> winableEnemys = new List<Character>();
        foreach (Character character in allCharacters)
        {
            if (character == null)
                continue;
            if (selfCharacter.selfCharacter.characterIWin == character.selfCharacter.characterName)
                winableEnemys.Add(character);
        }
        return winableEnemys;
    }

    private Vector3 GetClosestEnemyFromCollection(List<Character> winableEnemys)
    {
        Vector3 closest = winableEnemys[0].selfCharacter.pos;
        for (int i = 1; i < winableEnemys.Count; i++)
        {
            Vector3 current = winableEnemys[i].selfCharacter.pos;
            if (Vector3.Distance(transform.position, closest) > Vector3.Distance(transform.position, current))
                closest = current;
        }
        return closest;
    }
    private Vector3 PickRandomPos()
    {
        ArenaSize arenaSize = ArenaSize.Instance;
        return new Vector3(UnityEngine.Random.Range(arenaSize.Left * 0.5f, arenaSize.Right * .5f), UnityEngine.Random.Range(arenaSize.Down * 0.5f, arenaSize.Up * 0.5f), 0);
    }
    public void SetAllCharacters(List<Character> gameObjects)
    {
        allCharacters = gameObjects;
    }
}
