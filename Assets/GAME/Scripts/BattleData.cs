using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class BattleData : MonoBehaviour
{
  public static Action<int> OnLivesUpdated;
  public static Action<int> OnTurnsUpdated;
  public static Action<int> OnVictoriesUpdated;

  private static int _lives = 3;
  private static int _turns = 0;
  private static int _victories = 0;

  public static List<Character> _playerCharacters = new List<Character>();
  public static List<Character> _enemyCharacters = new List<Character>();
  [SerializeField] private GameData _gameData;

  public static int Lives
  {
    get { return _lives; }
    set
    {
      _lives = value;
      OnLivesUpdated?.Invoke(_lives);
    }
  }

  public static int Turns
  {
    get { return _turns; }
    set
    {
      _turns = value;
      OnTurnsUpdated?.Invoke(_turns);
    }
  }

  public static int Victories
  {
    get { return _victories; }
    set
    {
      _victories = value;
      OnVictoriesUpdated?.Invoke(_victories);
    }
  }


  public void Test()
  {
    BattleData.Turns++;
    string[] names = new string[] { "Spider", "Toad", "Bug" };
    //_playerCharacters = new Character[names.Length];
    for (int i = 0; i < names.Length; i++)
    {
      Character character = _gameData.characters.Find(x => x.name == names[i]);
      Character newCharacter = character.Clone() as Character;
      _playerCharacters.Add(newCharacter);
    }

    // names = new string[] { "Toad", "Bug", "Boar" };
    // for (int i = 0; i < names.Length; i++)
    // {
    //   Character character = _gameData.characters.Find(x => x.name == names[i]);
    //   Character newCharacter = character.Clone() as Character;
    //   _enemyCharacters.Add(newCharacter);
    // }
  }


  public void PopulateEnemies()
  {
    Debug.Log("PopulateEnemies: " + Turns);
    _enemyCharacters.Clear();
    // int maxGroupInTurn = _gameData.enemies.Where(x => x.turn == Turns).Max(x => x.group);
    //int maxGroup = _gameData.enemies.Max(x => x.group);
    Debug.Log("PopulateEnemies: " + Turns);

    //int randomGroup = UnityEngine.Random.Range(1, maxGroup + 1);

    List<Enemy> enemies = _gameData.enemies.Where(x => x.turn == Turns && x.group == 1).ToList();
    for (int i = 0; i < enemies.Count; i++)
    {
      Enemy enemy = enemies[i];
      Character character = _gameData.characters.Find(x => x.name == enemy.name);
      Character newCharacter = character.Clone() as Character;
      _enemyCharacters.Add(newCharacter);
    }
  }


}
