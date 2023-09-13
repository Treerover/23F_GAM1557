using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyInterfaces
{
    public interface IMove
    {
        void Move();
        void Jump();
    }
    public interface IColor
    {
        public void ResetColor();
        public void SetColor(Color color);
    }


}
