using UnityEngine;
using UnityEngine.InputSystem;
using Infrastructure.Input;

namespace Game.Input
{   
    public sealed class MoveSmoothReader : IMoveInput
    {
        private readonly IMoveInput _inner;
        private readonly float _directionRate;
        private readonly float _magnitudeRate;

        private Vector2 _smoothedDir;
        private float   _smoothedMag;

        public MoveSmoothReader(IMoveInput inner, float directionRate = 12f, float magnitudeRate = 15f)
        {
            _inner = inner;
            _directionRate = directionRate;
            _magnitudeRate = magnitudeRate;
        }

        public Vector2 ReadValue()
        {
            var raw = _inner.ReadValue();
            float rawMag = Mathf.Clamp01(raw.magnitude);

            Vector2 rawDir = rawMag > 0.01f ? raw / rawMag : Vector2.zero;
            _smoothedDir = Damping.Exp(_smoothedDir, rawDir, _directionRate, Time.deltaTime);

            _smoothedMag = Damping.Exp(_smoothedMag, rawMag, _magnitudeRate, Time.deltaTime);

            return _smoothedDir * _smoothedMag;
        }
    }
}

