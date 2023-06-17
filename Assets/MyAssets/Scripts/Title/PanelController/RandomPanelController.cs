using UnityEngine;
using MyAssets.Scripts.Title.Match;
using TMPro;
public class RandomPanelController : PanelController
{
    
    [SerializeField] private TMP_InputField _playerNameInput;
    [SerializeField] private TMP_Text _nameErrorText;
    [SerializeField] private DataValidator _dataValidator;
    public void TryMoveMatching()
    {
        bool isValidName = _dataValidator.IsValidName(_playerNameInput.text,out string nameError);
        _nameErrorText.text = nameError;

        if(isValidName) _sceneProgressManager.LoadMatchScene(_playerNameInput.text);
    }
}
