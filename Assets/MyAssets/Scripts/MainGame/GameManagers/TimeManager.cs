using System.Collections;
using UnityEngine;
using UniRx;

namespace Assets.MyAssets.Scripts.MainGame.GameManagers
{
    public class TimeManager : MonoBehaviour
    {
        private const int DefaultTurnSecond = 30;
        private ReactiveProperty<float> _turnSecond = new ReactiveProperty<float>(DefaultTurnSecond);
        public IReadOnlyReactiveProperty<float> TurnSecond { get { return _turnSecond; } }

        private bool _canCountDown = true;
        
        public void RestartTimer()
        {
            StartCoroutine(RestartTimerCoroutine());
        }

        IEnumerator RestartTimerCoroutine()
        {
            _canCountDown = true;
            _turnSecond.Value = DefaultTurnSecond;
            while (_turnSecond.Value > 0 && _canCountDown)
            {
                yield return new WaitForSeconds(0.1f);
                _turnSecond.Value -= 0.1f;
                Debug.Log(TurnSecond.Value);
            }
        }
        
        public void StopTimer()
        {
            _canCountDown = false;
        }
    }
}

