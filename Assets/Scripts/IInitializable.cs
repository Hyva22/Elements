using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInitializable
{
    public bool IsInitialized { get; set; }

    public void Initialize();
}
