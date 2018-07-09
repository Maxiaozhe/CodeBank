/*
 * <summary>
 * 指定した文字列の前後の半角スペースを取り除いて返します。
 * </summary>
 * <param name="target" type="string">スペースを取り除く文字列を指定します。</param>
 * <returns type="string">前後の半角スペースを取り除いた文字列を返します。</returns>
 */
function Trim(target) {
    return target.replace(/(^\s+)|(\s+$)/g, "");
}

/*
 * <summary>
 * hhmmss形式の時刻をhh:mm:ss形式の文字列にフォーマットします。
 * 指定したエレメントに入力されている値が時刻として認識できない場合は空白に置換します。
 * </summary>
 * <param name="element" type="object">テキストボックス形式のエレメントを指定します。</param>
 * <returns type="bool"></returns>
 */
function FormatTime(element) {
    var value = element.value;
    if (value.length != 6 || !value.match(/^[0-9]*$/)) {
        element.value = "";
    } else if (value < "000000" || value > "235959") {
        element.value = "";
    } else {
        var h = value.substring(0, 2);
        var m = value.substring(2, 4);
        var s = value.substring(4, 6);
        element.value = h + ":" + m + ":" + s;
    }
}

/*
 * <summary>
 * hh:mm:ss形式の時刻をhhmmss形式の文字列にフォーマットします。
 * </summary>
 * <param name="target" type="object">テキストボックス形式のエレメントを指定します。</param>
 * <returns type="bool"></returns>
 */
function UnformattedTime(element) {
    var value = element.value.replace(/:/g, "");
    element.value = value;
    element.select();
}

/*
 * <summary>
 * yyyyMMdd形式の日付をyyyy/MM/dd形式の文字列にフォーマットします。
 * 指定したエレメントに入力されている値が日付として認識できない場合は空白に置換します。
 * </summary>
 * <param name="element" type="object">テキストボックス形式のエレメントを指定します。</param>
 * <returns type="bool"></returns>
 */
function FormatDate(element) {
    var value = element.value;
    if (value.length != 8 || !value.match(/^[0-9]*$/)) {
        element.value = "";
    } else {
        var y = value.substring(0, 4);
        var m = value.substring(4, 6);
        var d = value.substring(6, 8);

        try {
            var date = parseInt(y, 10) + "/" + parseInt(m, 10) + "/" + parseInt(d, 10);
            var testValue = new Date(y, parseInt(parseInt(m, 10)) - 1, parseInt(d, 10));
            var compareDate = testValue.getYear() + "/" + (testValue.getMonth() + 1) + "/" + testValue.getDate();

            if (date == compareDate)
                element.value = y + "/" + m + "/" + d;
            else
                eleme.value = "";
        } catch (e) {
            element.value = "";
        }
    }
}

/*
 * <summary>
 * yyyy/MM/dd形式の日付をyyyyMMdd形式の文字列にフォーマットします。
 * </summary>
 * <param name="target" type="object">テキストボックス形式のエレメントを指定します。</param>
 * <returns type="bool"></returns>
 */
function UnformattedDate(element) {
    var value = element.value.replace(/\//g, "");
    element.value = value;
    element.select();
}

/*
 * <summary>
 * 指定したエレメントの値が数値かどうかを判断し、非数値の場合は空白または0に置換します。
 * </summary>
 * <param name="element" type="object">テキストボックス形式のエレメントを指定します。</param>
 * <param name="zeroFormat" type="bool">trueを指定すると、テキストボックスに入力された値が非数値の場合に0で置換します。</param>
 * <returns type="bool"></returns>
 */
function FormatNumeric(element, zeroFormat) {
    if (!element.value.match(/^[0-9]*$/))
        element.value = "";

    if (zeroFormat == true && element.value == "")
        element.value = "0";
    else
        element.value = parseInt(element.value, 10).toString();
}

/*
 * <summary>
 * 指定したエレメントの値がメールアドレスの形式かどうかを判断します。
 * </summary>
 * <param name="element" type="object">メールアドレス形式かどうかを判断するテキスト形式のエレメントを指定します。</param>
 * <returns type="bool"></returns>
 */
function IsMailAddress(element) {
    return element.value.match(/^[A-Za-z0-9]+[\w-]+@[\w\.-]+\.\w{2,}$/);
}