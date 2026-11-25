using UnityEngine;
using VContainer.Unity;
using System;

public class PlayerMoveInputRead : IMoveReadInput, IStartable, IDisposable
{
    private readonly PlayerInputReader _reader;
    private readonly InputSmoothConfig _smoothConfig;

    private Vector2 _rawInput;
    private Vector2 _smoothedInput;

    public PlayerMoveInputRead(PlayerInputReader reader, InputSmoothConfig config)
    {
        _reader = reader;
        _smoothConfig = config;
    }

    public void Start()   => _reader.MoveEvent += OnMoveRead;
    public void Dispose() => _reader.MoveEvent -= OnMoveRead;

    private void OnMoveRead(Vector2 value)
    {
        _rawInput  = value;
    }

    public Vector2 ReadValue
    {
        get
        {
            _smoothedInput = Damping.Exp(_smoothedInput,_rawInput,_smoothConfig.DirectionRate,Time.deltaTime);

            return _smoothedInput;
        }
    }
}
