using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR;

namespace FarmGame.Agent
{
    public class AgentMover : MonoBehaviour
    {
        public Transform _testTransform;
        //This a delegate which means it saves a reference to a method that we want to call whenever
        //we want to send the message to other scripts from our object.
        public event Action<bool> OnMove;
        [SerializeField]
        private float speed = 2;

        public Vector2 MovementInput { get; set; }

        private void Update()
        {
            _testTransform.position += (Vector3)MovementInput * Time.deltaTime * speed;
        }

        internal void SetMovementInput(Vector2 input) 
        {
            MovementInput = input;
            OnMove?.Invoke(input.magnitude > 0.1f);
        }
    }
}
