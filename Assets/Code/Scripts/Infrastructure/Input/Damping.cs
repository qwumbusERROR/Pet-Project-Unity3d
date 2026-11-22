using UnityEngine;

namespace Infrastructure.Input
{
    public static class Damping
    {
        public static float Exp(float current, float target, float rate, float dt)
            => target + (current - target) * Mathf.Exp(-rate * dt);

        public static Vector2 Exp(Vector2 current, Vector2 target, float rate, float dt)
            => target + (current - target) * Mathf.Exp(-rate * dt);
    }
}