using System;
using UnityEngine;

namespace SecondGame
{
    public class RebootActiveCardParent : MonoBehaviour
    {
        public static event Action NewActiveCardAssigned;

        protected void ActivateAction()
        {
            NewActiveCardAssigned?.Invoke();
        }
    }
}