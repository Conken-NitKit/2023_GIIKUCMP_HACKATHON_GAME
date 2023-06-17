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
        /// 適切な名前かを返すメソッド
        /// </summary>
        /// <param name="name">チェックする文字列</param>
        /// <param name="error">適切な場合空文字、適切でない場合エラーテキスト</param>
        /// <returns></returns>
        public bool IsValidName(string name,out string error)
        {
            error = IsNullOrBlank(name) ? "名前が入力されていません" :
                !IsValidNameLength(name) ? "名前が長すぎます。10文字以内にしてください" : "";
                
            return IsValidNameLength(name) && !IsNullOrBlank(name);
        }
        /// <summary>
        /// 適切な名前かを返すメソッド
        /// </summary>
        /// <param name="name">チェックする文字列</param>
        /// <param name="error">適切な場合空文字、適切でない場合エラーテキスト</param>
        /// <returns></returns>
        public bool IsValidRoomNum(string num,out string error)
        {
            error = !CanParseInt(num) ? "部屋番号は数字で入力してください" :
                !IsValidRoomNumLength(num) ? "部屋番号は5桁の数字で入力してください" : "";
                
            return CanParseInt(num) && IsValidRoomNumLength(num);
        }
        
        
        /// <summary>
        /// 文字数が規定値内かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>文字数が規定値以内であればtrue、超過でfalse</returns>
        private bool IsValidNameLength(string str)
        {
            return (str.Length <= maxLength);
        }

        /// <summary>
        /// Null、空白、空文字かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>Null、空白、空文字の時true、それ以外でfalse</returns>
        private bool IsNullOrBlank(string str)
        {
            return (str.IsNullOrEmpty() || Regex.IsMatch(str, "^ +?$"));
        }

        /// <summary>
        /// 数値として有効かを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>数値として認識できる時true、それ以外でfalse</returns>
        private bool CanParseInt(string str)
        {
            return int.TryParse(str,out int _);
        }
        /// <summary>
        /// 部屋番号の桁数があっているかを返すメソッド
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>部屋番号の桁数として適正でtrue、それ以外でfalse</returns>
        private bool IsValidRoomNumLength(string str)
        {
            return str.Length == roomNumLength;
        }
        
    }
}
