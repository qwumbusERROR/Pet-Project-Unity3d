using UnityEngine;
using VContainer.Unity;
using System;

public class PlayerLookInputRead : ILookReadInput, IStartable, IDisposable
{
    private readonly PlayerInputReader _reader;
    private Vector2 _currentInput;

    public PlayerLookInputRead(PlayerInputReader reader)
    {
        _reader = reader;
    }

    public void Start()   => _reader.LookEvent += OnLookRead;
    public void Dispose() => _reader.LookEvent -= OnLookRead;

    private void OnLookRead(Vector2 value)
    {
        _currentInput = value;
    }

    public Vector2 ReadValue => _currentInput;
}
