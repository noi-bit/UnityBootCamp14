using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SliderControler _sliderControler;
    [SerializeField] private Button _createMazeButton;
    [SerializeField] private Text _text;

    [SerializeField] private Board _board;
    [SerializeField] private Player _player;

    private void Start()
    {
        _sliderControler.SliderValueChange += SetSlideValue;
        _createMazeButton.onClick.AddListener(CreateMaze);
    }

    private void SetSlideValue(float val)
    {
        _text.text = val.ToString();
        _board.Size = (int)val;
    }

    private void CreateMaze()
    {
        _board.initialze();
        _board.Spawn();

        _player.Initialze(1,1,_board);
        //_player.RightHand();
        
    }

    
}
