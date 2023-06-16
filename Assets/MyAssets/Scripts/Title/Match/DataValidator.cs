using System;
using System.Text.RegularExpressions;
using UnityEngine;
using WebSocketSharp;

namespace MyAssets.Scripts.Title.Match
{
    /// <summary>
    /// マッチングに必要なプレイヤー情報が正しく入力されているかをチェックするクラス
    /// </summary>
    public class DataValidator : MonoBehaviour
    {
        [SerializeField] private int maxLength = 10;
        [SerializeField] private int roomNumLength = 5;
        /// <summary>
        /// 文字数が規定値内かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>文字数が規定値以内であればtrue、超過でfalse</returns>
        public bool IsValidNameLength(string str)
        {
            return (str.Length <= maxLength);
        }

        /// <summary>
        /// Null、空白、空文字かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>Null、空白、空文字の時true、それ以外でfalse</returns>
        public bool IsNullOrBlank(string str)
        {
            return (str.IsNullOrEmpty() || Regex.IsMatch(str, "^ +?$"));
        }

        /// <summary>
        /// 数値として有効かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>数値として認識できる時true、それ以外でfalse</returns>
        public bool IsValidRoomNum(string str)
        {
            return int.TryParse(str,out int _);
        }
        /// <summary>
        /// 部屋番号の桁数があっているかを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>部屋番号の桁数として適正でtrue、それ以外でfalse</returns>
        public bool IsValidRoomNumLength(string str)
        {
            return str.Length == roomNumLength;
        }
        
    }
}
