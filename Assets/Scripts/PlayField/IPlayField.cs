using System;
using RoundSystems.Interfaces;
using UnityEngine;

namespace PlayField
{
    public interface IPlayField
    {
        event Action OnGameEnd;

        void Initialize(IMatchSystem matchSystem, Mesh[] cardReferences);
        void DirectUpdate();
        void Reset();
    }
}