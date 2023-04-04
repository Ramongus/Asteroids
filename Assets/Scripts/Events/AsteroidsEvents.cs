using System;
using Enums;

namespace Events
{
    public static class AsteroidsEvents
    {
        public static Action<AsteroidsSize> OnAsteroidDestroyed;
    }
}