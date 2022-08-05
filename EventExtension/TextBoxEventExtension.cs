using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ChanWooLib.EventExtension
{
    public static class TextBoxEventExtension
    {


        /// <summary>
        /// name         : 텍스트박스 영문,숫자만 가능하게끔 하는 메소드
        /// desc         : 텍스트박스 영문,숫자만 가능하게끔 하는 메소드
        /// </summary>
        public static void TextBoxOnlyAlphaNumeric(object sender, TextChangedEventArgs e)
        {

            //util_textbox_alpha_numeric

            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9a-zA-Z ]", "");
            textboxSender.SelectionStart = cursorPosition;
        }


        /// <summary>
        /// name         : 텍스트박스 영문,숫자만 가능하게끔 하는 메소드
        /// desc         : 텍스트박스 영문,숫자만 가능하게끔 하는 메소드
        /// </summary>
        public static void TextBoxOnlyNumeric(object sender, TextChangedEventArgs e)
        {

            //util_textbox_alpha_numeric
            var textboxSender = (TextBox)sender;
            var cursorPosition = textboxSender.SelectionStart;
            textboxSender.Text = Regex.Replace(textboxSender.Text, "[^0-9.-]+", "");
        }

    }
}