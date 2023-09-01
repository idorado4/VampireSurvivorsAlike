using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterInstaller : MonoBehaviour
{
    [SerializeField] private PlayableCharacterMediator _characterMediator;


    private IInputSystem _input;

    private void Awake()
    {
        _input = new UnityInputAdapter();
        _characterMediator.Config(_input);
    }
}
