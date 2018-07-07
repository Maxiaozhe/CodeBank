using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DenshowBusinessInterface;
using DenshowCommon;
using DenshowDataAccessInterface;
using DenshowDataAccessInterface.Dto;
using Microsoft.VisualBasic;

namespace DenshowBusinessComponent.Control
{
    /// <summary>
    /// CSVファイル出力コントロール
    /// </summary>
    internal class CsvOutputControl
    {
        #region Field
        /// <summary>
        /// アプリケーションロッカー
        /// </summary>
        private static object fileLock = new object();
        /// <summary>
        /// シーケンス番号
        /// </summary>
        private string sequenceNo;

        private ReportDefinitionDto reportDefintionInfo;
        /// <summary>
        /// シーケンス認識結果データ
        /// </summary>
        private GetReportSequenceViewDto ocrSequecneResultDto;

        /// <summary>
        /// 帳票認識結果データ
        /// </summary>
        private List<OcrReportResultDto> ocrReportResultDtoList;

        /// <summary>
        /// 認識項目とグループ結合設定情報を取得する
        /// </summary>
        private List<CreateGroupResultViewDto> groupDetailItemList;

        // ファイル出力関連ビューを取得
        private List<OutputFileCGViewDto> groupItemResultList;
        /// <summary>
        /// ユーザー定義項目リスト
        /// </summary>
        private List<OutputFileOUViewDto> userDefineItems;
        /// <summary>
        /// システム結果項目リスト
        /// </summary>
        private List<OutputFileOSViewDto> systemItemResultList;
        /// <summary>
        /// 出力項目定義リスト
        /// </summary>
        private List<OutputFileViewDto> outputItemList;
        /// <summary>
        /// 出力設計情報
        /// </summary>
        private OutputDesignDto outputDesignInfo;

        /// <summary>
        /// 出力ファイルの
        /// </summary>
        private string delimiter = string.Empty;
        /// <summary>
        /// 出力ファイルの拡張子
        /// </summary>
        private string extension = string.Empty;
        /// <summary>
        /// タイム型へ変換可能フォーマット
        /// </summary>
        private string[] timeFormats = { "HHmm", "HHmmss", "HH:mm", "HH:mm:ss" };//サポート形式拡張は可能
        /// <summary>
        /// 日付型へ変換可能フォーマット
        /// </summary>
        private string[] dateFormats = { "yyyyMMdd", "yyyy-MM-dd", "yyyy/MM/dd", "yyyy/MM/dd HH:mm", "yyyy/MM/dd HH:mm:ss", "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss" };

        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="sequenceNo">シーケンス番号</param>
        /// <param name="reportDfId">帳票番号</param>
        public CsvOutputControl(string sequenceNo, string reportDfId)
        {
            this.sequenceNo = sequenceNo;
            this.getOutputInfo(sequenceNo, reportDfId);
        }
        #endregion

        #region private Method

        #region 出力情報取得
        /// <summary>
        /// 関連設計情報(出力設定情報、認識結果データなど)を取得する
        /// </summary>
        /// <param name="sequenceNo">シーケンス番号</param>
        /// <param name="reportDfId">帳票番号</param>
        private void getOutputInfo(string sequenceNo, string reportDfId)
        {
            try
            {
                // ファイル出力
                using (IDataAccessComponent access = DataAccessFactory.GetDataAccess())
                {
                    // シーケンス結果情報
                    ocrSequecneResultDto = access.GetGetReportSequenceViewDao().Get(sequenceNo);

                    // 認識結果データ
                    this.ocrReportResultDtoList = access.GetOcrReportResultDao().GetList(sequenceNo);

                    //帳票設計情報
                    this.reportDefintionInfo = access.GetReportDefinitionDao().Get(reportDfId);

                    // 出力ファイル情報を取得
                    this.outputDesignInfo = access.GetOutputDesignDao().Get(reportDfId);

                    // ファイル出力ビュー
                    this.outputItemList = access.GetOutputFileViewDao().GetList(outputDesignInfo.OpId);

                    //グループ結果データを取得する
                    this.groupItemResultList = access.GetOutputFileCGViewDao().GetList(sequenceNo);

                    //システム定義項目
                    this.systemItemResultList = access.GetOutputFileOSViewDao().GetList(sequenceNo);

                    //ユーザー定義明細項目
                    this.userDefineItems = access.GetOutputFileOUViewDao().GetList(outputDesignInfo.OpId);

                    //認識項目とグループ結合設定情報を取得する
                    this.groupDetailItemList = access.GetCreateGroupResultViewDao().GetList(this.sequenceNo);
                }
            }
            catch (Exception ex)
            {
                throw new DenshowBusinessException(string.Format(DenshowCommon.Message.EP099, sequenceNo), ex);
            }

        }

        /// <summary>
        /// 結果ページデータごと出力項目情報を取得する
        /// </summary>
        /// <param name="resultPage"></param>
        /// <returns></returns>
        private List<OutputFileViewDto> getOutputItemsByPage(OcrReportResultDto resultPage)
        {
            var outputItems = from x in this.outputItemList
                              where x.TemplateId == resultPage.TemplateId
                                  //ページ指定無しの場合RcPageNo=0ので、テンプレートで特定する
                                  && (x.RcPageNo == 0 || x.RcPageNo == resultPage.PageNo)
                              orderby x.OpOrderNo
                              select x;
            return outputItems.ToList();
        }

        /// <summary>
        /// グループ項目の桁数の合計値を取得する
        /// </summary>
        /// <returns></returns>
        private int getRcDigit(OutputFileViewDto item)
        {
            int rcDigit = (from x in this.groupDetailItemList
                           where x.ClId == item.ClId && x.ClGroupId == item.ClGroupId && x.TemplateId == item.TemplateId
                                && (item.RcPageNo == 0 || x.PageNo == item.RcPageNo)
                           select x.RcDigit).Sum(digit =>
                           {
                               int ret = 0;
                               return int.TryParse(digit, out ret) ? ret : 0;
                           });
            return rcDigit;
        }

        /// <summary>
        /// 出力項目の値を取得する
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pageNo">結果データのページ番号</param>
        /// <returns></returns>
        private string getItemValue(OutputFileViewDto item,int pageNo)
        {
            string value = string.Empty;
            switch (item.OpItemType)
            {
                case Definition.OutputItemType.ViewGroup:
                    value = this.getGroupItemValue(item.TemplateId, item.ClGroupId, pageNo);
                    break;

                case Definition.OutputItemType.System:
                    value = this.getSystemItemValue(item.SystemItemId, pageNo, item.TemplateId);
                    break;
                case Definition.OutputItemType.UserExpression:
                    value = this.getUserExpressItemValue(item,pageNo);
                    break;
            }
            //半角変換(ユーザー定義項目すでに半角修正が入れたので、再度変換しない)
            if (item.HalfCharacterFlag && item.OpItemType!=Definition.OutputItemType.UserExpression)
            {
                value = this.convertToNarrow(value);
            }

            // 日付形式書式設定
            value = setDateFormat(item, value);

            // 時間形式書式設定
            value = setTimeFormat(item, value);

            // カンマ区切り出力
            value = setCommaSeparate(item, value);

            // 金額文字列の生成
            value = setMoneyString(item, value);

            //プレーンファイルの場合、グループ項目の指定桁数まで空白を埋め込む（OMR項目の場合、埋め込む済みためしない）
            if (this.outputDesignInfo.RcResultOpFormat == Definition.OpDesignFileFormat.Plain
                && item.OpItemType == Definition.OutputItemType.ViewGroup
                && item.GroupItemKind != Definition.ItemKind.OMR)
            {
                int digit = this.getRcDigit(item);
                value = this.padValue(value, digit);
            }
            return value;
        }

        /// <summary>
        /// システム項目を取得する
        /// </summary>
        /// <param name="systemItemId"></param>
        /// <param name="rcPageNo"></param>
        /// <param name="templateId"></param>
        /// <returns></returns>
        private string getSystemItemValue(string systemItemId, int rcPageNo, string templateId)
        {
            OutputFileOSViewDto item = (from x in this.systemItemResultList
                                        where (x.TemplateId == templateId && x.ItemId == systemItemId)
                                             && (rcPageNo == 0 || rcPageNo == x.PageNo)
                                        select x).First();
            return item.Data;
        }

        /// <summary>
        /// グループ項目の値を取得する
        /// </summary>
        /// <param name="templateId"></param>
        /// <param name="clGroupId"></param>
        /// <param name="pageNo"></param>
        /// <returns></returns>
        private string getGroupItemValue(string templateId, string clGroupId, int pageNo)
        {
            try
            {
                OutputFileCGViewDto item = (from x in this.groupItemResultList
                                            where (x.ClGroupId == clGroupId && x.TemplateId == templateId && (x.PageNo == pageNo || pageNo == 0))
                                            select x).Single();
                if (item.ItemKind != Definition.ItemKind.OMR)
                {
                    return item.CorrectedString;
                }
                else
                {
                    //OMR項目の場合、OMR出力文字列で変換する
                    return this.getOmrItemValue(item);
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// OMR項目の値を取得する
        /// </summary>
        /// <param name="groupitem"></param>
        /// <returns></returns>
        private string getOmrItemValue(OutputFileCGViewDto groupitem)
        {
            var omrItems = from x in this.groupDetailItemList
                           where x.ClId == groupitem.ClId && x.ClGroupId == groupitem.ClGroupId && x.TemplateId == groupitem.TemplateId
                                 && x.PageNo == groupitem.PageNo
                           orderby x.ItemOrder
                           select x;
            string value = this.convertToNarrow(groupitem.CorrectedString);
            string joinValue = string.Empty;
            int index = 0;
            //OMR未選択時の出力値を取得する
            string notMarkString = Config.GetOmrNotMarkOpString();
            // OMR出力時の区切り文字
            string omrSpliter = Config.GetOmrSplitString();
            
            foreach (var omrItem in omrItems)
            {
                if (index < value.Length)
                {
                    string mark = value.Substring(index, 1);
                    string markString = omrItem.OpString;
                    if (string.IsNullOrEmpty(markString))
                    {
                        markString = mark;
                    }
                    int digit = 0;
                    if (!int.TryParse(omrItem.RcDigit, out digit))
                    {
                        digit = 0;
                    }
                    if (mark.Equals("1"))
                    {
                        joinValue += this.padValue(markString, digit);
                    }
                    else
                    {
                        joinValue += this.padValue(notMarkString, digit);
                    }
                    if (this.outputDesignInfo.RcResultOpFormat != Definition.OpDesignFileFormat.Plain)
                    {
                        if (index < value.Length - 1)
                        {
                            joinValue += omrSpliter;
                        }
                    }
                }
                index++;
            }
            return joinValue;
        }

        /// <summary>
        /// ユーザー定義項目の値を取得する
        /// </summary>
        /// <param name="item">ユーザー定義項目</param>
        /// <param name="pageNo">出力項目のページ番号</param>
        /// <returns></returns>
        private string getUserExpressItemValue(OutputFileViewDto item, int pageNo)
        {
            //ユーザー定義項目を取得する
            var items = (from x in this.userDefineItems
                         where x.UserDefinitionId == item.UserDefinitionId
                            && x.RcPageNo == item.RcPageNo
                            && x.OpOrderNo == item.OpOrderNo
                         select x).OrderBy(x => x.RowNo);

            StringBuilder sb = new StringBuilder();
            foreach (OutputFileOUViewDto userItem in items)
            {
                switch (userItem.ExpressionType)
                {
                    case Definition.UserExpressionType.String:
                        //文字列指定の場合
                        sb.Append(userItem.ExpressionString);
                        break;
                    case Definition.UserExpressionType.ViewGroup:
                        //グループ項目の場合
                        int usePageNo = userItem.ExpressionRcPageNo == 0 ? pageNo : userItem.ExpressionRcPageNo;
                        string groupValue = this.getGroupItemValue(userItem.ExpressionTemplateId, userItem.ExpressionItemId, usePageNo);
                        sb.Append(groupValue);
                        break;
                }
            }
            string value = sb.ToString();
            //半角変換
            if (item.HalfCharacterFlag)
            {
                value = this.convertToNarrow(value);
            }
            //桁数設定
            if (this.outputDesignInfo.RcResultOpFormat == Definition.OpDesignFileFormat.Plain && item.UserDefinitionNo.HasValue)
            {
                value = this.padValue(value, item.UserDefinitionNo.Value);
            }

            return value;
        }

        #endregion

        #region 出力ファイル作成
        /// <summary>
        /// 画像出力
        /// </summary>
        private void outputImg()
        {
            string extName = string.Empty;
            //入力画像を出力時
            if (this.outputDesignInfo.InputImgOpFlag)
            {
                //監視フォルダに入ってくる画像と同一の物
                //入力画像ファイル名IpImgFilePathの値による（シーケンス番号と違う場合がある）
                string ipImgName =System.IO.Path.GetFileName(ocrSequecneResultDto.IpImgFilePath);
                string inputImgPath = System.IO.Path.Combine(outputDesignInfo.OpFolderPath, ipImgName);
                //入力画像すでに存在する場合、コピーしない
                if (!System.IO.File.Exists(inputImgPath))
                {
                    File.Copy(ocrSequecneResultDto.IpImgFilePath, inputImgPath, true);
                }
            }
            // ページ画像を出力時(二値化画像)
            if (this.outputDesignInfo.PageImgOpFlag)
            {
                foreach (var item in this.ocrReportResultDtoList)
                {
                    //シーケンス番号+"_"+ページ番号でリネームする
                    extName = Path.GetExtension(item.BinarizationImgFilePath);
                    string pageImgName = sequenceNo + "_" + item.PageNo.ToString() + extName;
                    string pageImgPath = System.IO.Path.Combine(outputDesignInfo.OpFolderPath, pageImgName);
                    File.Copy(item.BinarizationImgFilePath, pageImgPath, true);
                }
            }
            //認識画像を出力時
            if (this.outputDesignInfo.RecognitionImgOpFlag)
            {
                //二値化画像から定型帳票ライブラリで罫線除去した画像(拡張子はRCG形式)
                foreach (var item in this.ocrReportResultDtoList)
                {
                    if (!string.IsNullOrEmpty(item.RcImgFilePath))
                    {
                        string rcImgPath = System.IO.Path.Combine(outputDesignInfo.OpFolderPath, Path.GetFileName(item.RcImgFilePath));
                        File.Copy(item.RcImgFilePath, rcImgPath, true);
                    }
                }
            }
            //Fax画像出力ありの場合
            if (this.reportDefintionInfo.IpImgFaxOpFlag)
            {
                this.outputFaxImage();
            }
        }
        /// <summary>
        /// Fax画像を出力する
        /// </summary>
        private void outputFaxImage()
        {

            string outputFolder = this.reportDefintionInfo.IpImgFaxOpFolderPath;
            if (!Directory.Exists(outputFolder))
            {
                return;
            }
            //出力画像を取得(１ページ目の画像を取得する)
            string imgPath = this.ocrReportResultDtoList[0].BinarizationImgFilePath;


            float dpi = Config.GetImageResolution();
            int pageWidth = Definition.FaxSetting.WIDTH;
            int pageHeight = Definition.FaxSetting.HEIGHT;
            //予約領域を取得
            int reserveSize = Config.GetFaxImageMargin();
            if (reserveSize > Definition.FaxSetting.MAX_RESERVE_SIZE)
            {
                reserveSize = Definition.FaxSetting.MAX_RESERVE_SIZE;
            }
            //予約領域+上の余白
            int topMargin = reserveSize + Definition.FaxSetting.TOP_MARGIN;
            //右左下の余白
            int margin = Definition.FaxSetting.MARGIN;
            //画像描画する領域
            Rectangle drawRect = convertToPixcel(new Rectangle(
                                                    margin, topMargin,
                                                    pageWidth - margin * 2,
                                                    pageHeight - margin - topMargin));

            using (Image faxImg = Image.FromFile(imgPath))
            using (Bitmap canvas = new Bitmap(toPixel(pageWidth), toPixel(pageHeight)))
            using (Graphics g = Graphics.FromImage(canvas))
            {
                //Bitmapクラス生成時に解像度情報が失われるので元画像の解像度を再設定する
                canvas.SetResolution(faxImg.HorizontalResolution, faxImg.VerticalResolution);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if (faxImg.Width > faxImg.Height)
                {
                    //画像サイズは横になる場合,90度回転する
                    faxImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                Rectangle sourceRect = new Rectangle(0, 0, faxImg.Width, faxImg.Height);
                Rectangle destRect = fitForRange(drawRect, sourceRect);
                //背景をクリア
                g.Clear(Color.White);
                //フォントおよびサイズ、座標を設定
                Font font = new Font(Config.GetDefaultFontName(), Config.GetDefaultPrintFontSize());
                Brush brush = Brushes.Black;
                Point pos1 = new Point(toPixel(Definition.FaxSetting.POS_X), toPixel(Definition.FaxSetting.POS_Y1));
                //印字時間
                string outputDate = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                g.DrawString(outputDate, font, brush, pos1);
                //シーケンス番号
                Point pos2 = new Point(toPixel(Definition.FaxSetting.POS_X), toPixel(Definition.FaxSetting.POS_Y2));
                g.DrawString(this.sequenceNo, font, brush, pos2);
                //Fax画像を描画する
                g.DrawImage(faxImg, destRect, sourceRect, GraphicsUnit.Pixel);
                //画像保存
                string outputPath = Path.Combine(outputFolder, sequenceNo + Definition.FileExtension.TIFExtension);

                canvas.SaveAsTiff(outputPath, System.Windows.Media.Imaging.TiffCompressOption.Lzw);
            }
        }

        /// <summary>
        /// 長さ単位をmmからPixcelへ変換する
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int toPixel(int size)
        {
            return (int)Math.Round((double)size * (double)Definition.FaxSetting.DPI / (double)Definition.FaxSetting.INCH);
        }

        /// <summary>
        /// 矩形の単位をmmからPixcelへ変換する
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Rectangle convertToPixcel(Rectangle rect)
        {
            return new Rectangle(
                toPixel(rect.X),
                toPixel(rect.Y),
                toPixel(rect.Width),
                toPixel(rect.Height));
        }

        /// <summary>
        /// 高さ幅の比率を保持して、指定する領域に描画するための矩形を計算する
        /// </summary>
        /// <param name="OutputRect"></param>
        /// <param name="imgRect"></param>
        /// <returns></returns>
        private Rectangle fitForRange(Rectangle OutputRect, Rectangle imgRect)
        {
            Rectangle targetRect = OutputRect;
            //高さ/幅比率
            double outRangeHW = (double)OutputRect.Height / (double)OutputRect.Width;
            double imgRectHW = (double)imgRect.Height / (double)imgRect.Width;
            if (outRangeHW > imgRectHW)
            {
                targetRect.Width = OutputRect.Width;
                targetRect.Height = (int)Math.Round(OutputRect.Width * imgRectHW);
            }
            else
            {
                targetRect.Height = OutputRect.Height;
                targetRect.Width = (int)Math.Round(OutputRect.Height / imgRectHW);
            }
            return targetRect;
        }

        /// <summary>
        /// CSVファイルのヘッダーを作成する
        /// </summary>
        /// <returns></returns>
        private string createCsvHeader()
        {
            StringBuilder header = new StringBuilder();
            foreach (var item in this.outputItemList)
            {
                if (header.Length > 0)
                {
                    //最初の項目以外区切り文字を追加する
                    header.Append(this.delimiter);
                }
                header.Append(addQuotation(item.Title));
            }
            return header.ToString();
        }

        /// <summary>
        /// CSVファイルを作成する
        /// </summary>
        /// <returns></returns>
        private string createCsvFile()
        {
            if (this.outputDesignInfo.RcResultOpType == Definition.OpDesignOpType.AllOneLine)
            {
                return this.createCsvOneLine();
            }
            else
            {
                return this.createCsvByPage();

            }
        }

        /// <summary>
        ///  認識ページごとに行出力する
        /// </summary>
        private string createCsvByPage()
        {
            StringBuilder csv = new StringBuilder();
            int pageNo = 0;
            foreach (var resultPage in this.ocrReportResultDtoList)
            {
                var pageItems = this.getOutputItemsByPage(resultPage);
                if (pageItems.Count == 0)
                {
                    continue;
                }
                if (pageNo > 0)
                {
                    csv.AppendLine();
                }
                int colummIndex = 0;
                foreach (OutputFileViewDto item in pageItems)
                {
                    if (colummIndex > 0)
                    {
                        //最初の列以外、区切り文字追加
                        csv.Append(this.delimiter);
                    }
                    string itemValue = getItemValue(item,resultPage.PageNo);

                    csv.Append(this.addQuotation(itemValue));
                    colummIndex++;
                }
                pageNo++;
            }
            return csv.ToString();
        }

        /// <summary>
        /// 全ての認識結果を1行で出力する
        /// </summary>
        /// <returns></returns>
        private string createCsvOneLine()
        {
            StringBuilder csv = new StringBuilder();
            var sortItems = this.outputItemList.OrderBy(x => x.OpOrderNo);
            int colummIndex = 0;
            foreach (OutputFileViewDto item in sortItems)
            {
                if (colummIndex > 0)
                {
                    //最初の列以外、区切り文字追加
                    csv.Append(this.delimiter);
                }
                //ページ指定しかないので、出力項目定義されたページ番号を使用する
                string itemValue = getItemValue(item,item.RcPageNo);
                csv.Append(this.addQuotation(itemValue));
                colummIndex++;
            }
            return csv.ToString();
        }
        #endregion

        #region 出力文字列加工関数

        /// <summary>
        /// 項目修飾子追加
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string addQuotation(string value)
        {
            if (this.outputDesignInfo.RcResultOpFormat != Definition.OpDesignFileFormat.CSV)
            {
                //CSV形式以外項目修飾子を追加しない
                return value;
            }
            return Utility.AddQuotaion(value, "\"");
        }

        /// <summary>
        ///  指定された文字数になるまで右側に空白文字を埋め込む文字列を返します
        /// </summary>
        /// <param name="value">加工する文字列</param>
        /// <param name="digit">桁数</param>
        /// <returns></returns>
        private string padValue(string value, int digit)
        {
            if (this.outputDesignInfo.RcResultOpFormat != Definition.OpDesignFileFormat.Plain)
            {
                //プレーンファイル以外、空白文字を埋め込まない
                return value;
            }
            if (digit <= 0)
            {
                //桁数0及び設定なしの場合
                return value;
            }
            if (value.Length <= digit)
            {
                //桁数より少ない場合、右側に空白文字を埋め込む
                return value.PadRight(digit, ' ');
            }
            else
            {
                //桁数より多いの場合、切り捨て
                return value.Substring(0, digit);
            }
        }

        /// <summary>
        /// 半角変換を行う
        /// </summary>
        /// <returns>変換データ</returns>
        private string convertToNarrow(string value)
        {
            return Strings.StrConv(value, VbStrConv.Narrow);
        }

        /// <summary>
        /// 日付形式書式設定
        /// </summary>
        /// <param name="item">ファイル出力ビュー</param>
        /// <param name="value">出力項目</param>
        /// <returns>出力項目</returns>
        private string setDateFormat(OutputFileViewDto item, string value)
        {
            string formatValue = value;
            if (item.DateFormat.HasValue && !string.IsNullOrWhiteSpace(value))
            {
                DateTime date;
                //日付変換のため、まず半角へ変換
                string halfValue = this.convertToNarrow(value);
                if (DateTime.TryParseExact(formatValue, dateFormats, null, DateTimeStyles.AllowWhiteSpaces, out date))
                {
                    switch (item.DateFormat.Value)
                    {
                        case Definition.DateFormat.yyyymmdd:
                            formatValue = date.ToString(Definition.DateFormatType.yyyymmdd);
                            break;
                        case Definition.DateFormat.yyyymmddhhmm:
                            formatValue = date.ToString(Definition.DateFormatType.yyyymmddhhmm);
                            break;
                        case Definition.DateFormat.yyyymmddhhmmss:
                            formatValue = date.ToString(Definition.DateFormatType.yyyymmddhhmmss);
                            break;
                    }
                }
            }
            return formatValue;
        }

        /// <summary>
        /// 時間形式書式設定
        /// </summary>
        /// <param name="item">ファイル出力ビュー</param>
        /// <param name="value">出力項目</param>
        /// <returns>出力項目</returns>
        private string setTimeFormat(OutputFileViewDto item, string value)
        {
            string formatValue = value;

            if (item.TimeFormat.HasValue && !string.IsNullOrWhiteSpace(value))
            {
                DateTime date;
                //日付変換のため、まず半角へ変換
                string halfValue = this.convertToNarrow(value);
                if (DateTime.TryParseExact(halfValue, timeFormats, null, DateTimeStyles.AllowWhiteSpaces, out date))
                {
                    switch (item.TimeFormat)
                    {
                        case Definition.TimeFormat.hhmm:
                            formatValue = date.ToString(Definition.TimeFormatType.hhmm);
                            break;
                        case Definition.TimeFormat.hhmmss:
                            formatValue = date.ToString(Definition.TimeFormatType.hhmmss);
                            break;
                    }
                }
            }
            return formatValue;
        }

        /// <summary>
        /// 数値のカンマ区切りの設定
        /// </summary>
        /// <param name="item">ファイル出力ビュー</param>
        /// <param name="value">出力項目</param>
        /// <returns>出力項目</returns>
        private string setCommaSeparate(OutputFileViewDto item, string value)
        {
            string formatValue = value;
            if (item.CommaSeparateFlag && !string.IsNullOrWhiteSpace(value))
            {

                decimal num;
                //日付変換のため、まず半角へ変換
                string halfValue = this.convertToNarrow(value);
                if (decimal.TryParse(halfValue, out num))
                {
                    formatValue = String.Format("{0:#,0}", num);
                }
            }
            return formatValue;
        }

        /// <summary>
        /// 金額文字列の設定
        /// </summary>
        /// <param name="item">ファイル出力ビュー</param>
        /// <param name="value">出力項目</param>
        /// <returns>出力項目</returns>
        private string setMoneyString(OutputFileViewDto item, string value)
        {
            string formatValue = value;
            if (item.MoneyStringGenerationFlag && !string.IsNullOrWhiteSpace(value))
            {
                switch (item.CurrencySymbol)
                {
                    case Definition.CurrencyFormat.Yen:
                        formatValue = Definition.CurrencyFormatString.Yen + value;
                        break;

                    case Definition.CurrencyFormat.Dollar:
                        formatValue = Definition.CurrencyFormatString.Dollar + value;
                        break;
                }
            }
            return formatValue;
        }
        #endregion

        #endregion

        #region public method
        /// <summary>
        /// ファイル出力する
        /// </summary>
        public void OutputFile()
        {
            try
            {
                //出力形式を設定する
                switch (outputDesignInfo.RcResultOpFormat)
                {
                    case Definition.OpDesignFileFormat.CSV:
                        this.extension = Definition.FileExtension.CSVExtension;
                        this.delimiter = Definition.Delimiter.COMMA;
                        break;
                    case Definition.OpDesignFileFormat.TabSeparate:
                        this.extension = Definition.FileExtension.TSVExtension;
                        this.delimiter = Definition.Delimiter.TAB;
                        break;
                    case Definition.OpDesignFileFormat.Plain:
                        this.extension = Definition.FileExtension.TXTExtension;
                        this.delimiter = string.Empty;
                        break;
                }

                //ファイル作成
                string csvFileData = this.createCsvFile();

                //ファイルパスを作成
                string filePath = outputDesignInfo.OpFolderPath;

                if (outputDesignInfo.RcResultOpUnit == Definition.OpDesignOpUnit.Add)
                {
                    filePath = System.IO.Path.Combine(filePath, outputDesignInfo.RcResultOpFileName);
                }
                else
                {
                    filePath = System.IO.Path.Combine(filePath, sequenceNo);
                }
                filePath += this.extension;

                // ファイルの存在フラグ
                bool fileExists = File.Exists(filePath);

                // 追記か上書きかのフラグ判断
                bool appendFlag = false;
                if (outputDesignInfo.RcResultOpUnit == Definition.OpDesignOpUnit.Add)
                {
                    // 追記
                    appendFlag = true;
                }
                //同時書き込みことがあるので、ロックを使用する
                lock (fileLock)
                {
                    // 画像を先に出力
                    outputImg();
                    //CSV出力
                    using (StreamWriter sw = new StreamWriter(filePath, appendFlag, Encoding.GetEncoding(Definition.CSV_ENCODING)))
                    {
                        // タイトル出力＋ファイル新規作成の場合、ヘッダを出力する
                        if (outputDesignInfo.RcResultTitleFlag && !fileExists)
                        {
                            //ヘッダを作成する
                            sw.WriteLine(this.createCsvHeader());
                        }
                        sw.WriteLine(csvFileData);
                    }
                }
            }
            catch (Exception ex)
            {
                //例外発生する
                throw new DenshowBusinessException(string.Format(DenshowCommon.Message.EP099, sequenceNo), ex);
            }
        }

        #endregion

    }

}
