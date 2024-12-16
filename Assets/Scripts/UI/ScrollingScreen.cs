using System;
using UnityEngine;
using UnityEngine.UI;

namespace Catch.UI
{
    public class ScrollingScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private RawImage _img;
        [SerializeField] private float _x, _y;
        [SerializeField] private Color[] _myColors;

        [SerializeField] [Range(0f, 1f)] float lerpTime;
        
        private int _colorIndex = 0;
        private float _t = 0f;
        private int len;
        

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            len = _myColors.Length;
        }

        private void Update()
        {
            _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
            _img.color = Color.Lerp(_img.color, _myColors[_colorIndex], lerpTime * Time.deltaTime);
            _t = Mathf.Lerp(_t, 1f, lerpTime * Time.deltaTime);
            if (_t > .9f)
            {
                _t = 0f;
                _colorIndex++;
                _colorIndex = (_colorIndex >= len) ? 0 : _colorIndex;
            }
            
        }

        #endregion
    }
}