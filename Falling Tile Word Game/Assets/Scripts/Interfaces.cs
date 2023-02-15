using UnityEngine;
using System;

public interface ICanBeHeld
{
    bool BeingHeld { get; }
    void MoveTo(Vector3 position);
    void Clear();
}

public interface ICanHold
{
    void Hold(GameObject g);
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