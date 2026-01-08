using UnityEngine;

public class BasicClass : SingletonCore<BasicClass>
{
    public int level;

    public void LevelUp()
    {
        level++;
    }
}
