using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class PanelController : MonoBehaviour
{
    [SerializeField] protected TitleProgressManager _sceneProgressManager;
    [SerializeField] private CanvasGroup _panelCanvasGroup;

    public void Activate()
    {
        _panelCanvasGroup.DOFade(endValue: 1f, duration: 0.3f).SetEase(Ease.InOutQuint);
        _panelCanvasGroup.blocksRaycasts = true;
        _panelCanvasGroup.interactable = true;
    }

    public void Inactivate()
    {
        _panelCanvasGroup.interactable = false;
        _panelCanvasGroup.blocksRaycasts = false;
        _panelCanvasGroup.DOFade(endValue: 0f, duration: 0.3f).SetEase(Ease.InOutQuint);
    }
}
