using UnityEngine;
using System;

public interface ICanBeHeld
{
    bool BeingHeld { get; }
    void MoveTo(Vector3 position);
    void BeHeldBy(GameObject holder);
    void Clear();
}

public interface ICanHold
{
    void Hold(GameObject holdee);
}

public interface IHaveLetter
{
    char GetLetter();
}

public interface IQueuable
{
    bool Busy { get; }
    void QueuableClear();
}