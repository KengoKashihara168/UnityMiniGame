using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private Player player = null;

    public void Initialize()
    {

    }

    public void OnHandButton(int handNum)
    {
        player.SetHand(handNum);
    }
}
