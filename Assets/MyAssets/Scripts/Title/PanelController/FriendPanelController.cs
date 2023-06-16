using UnityEngine;
using MyAssets.Scripts.Title.Match;
using TMPro;

public class FriendPanelController : PanelController
{
    [SerializeField] private TMP_InputField _playerNameInput;
    [SerializeField] private TMP_Text _nameErrorText;
    [SerializeField] private TMP_InputField _roomNumInput;
    [SerializeField] private TMP_Text _roomErrorText;
    [SerializeField] private DataValidator _dataValidator;
    public void TryMoveMatching()
    {
        bool isValidName = _dataValidator.IsValidName(_playerNameInput.text,out string nameError);
        _nameErrorText.text = nameError;
        
        bool isValidRoomNum = _dataValidator.IsValidRoomNum(_roomNumInput.text,out string roomNumError);
        _roomErrorText.text = roomNumError;
        
        
        if(isValidName && isValidRoomNum) _sceneProgressManager.LoadMatchScene();
    }
}
