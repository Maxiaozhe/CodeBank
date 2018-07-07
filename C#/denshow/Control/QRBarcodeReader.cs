using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Client.Result;
using ZXing.Common;

namespace DenshowBusinessComponent.Control
{

    /// <summary>
    /// Barcode Readerのパラメタ変数設定
    /// </summary>
    public class BarcodeReaderParams
    {
        /// <summary>
        /// 画像を自動的に回転するかどうかを取得または設定します
        /// 回転は90度、180度、270度に対応しています
        /// </summary>
        public bool AutoRotate { get; set; }
        /// <summary>
        /// 元の画像に結果が見つからない場合は反転されるかどうかを取得または設定します。
        /// 注意：使用されているとデコード処理が遅くなる場合がある
        /// </summary>
        public bool TryInverted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool TryHarder { get; set; }

        /// <summary>
        /// 画像は、純粋なモノクロ画像かどうかを取得または設定します
        /// </summary>
        public bool PureBarcode { get; set; }

        /// <summary>
        /// 認識するバーコード種別
        /// </summary>
        public IList<BarcodeFormat> PossibleFormats { get; set; }
        /// <summary>
        /// バーコードリーダーのパラメタのコンストラクタ
        /// </summary>
        public BarcodeReaderParams()
        {
            this.AutoRotate = true;
            this.TryInverted = true;
            this.TryHarder = true;
            this.PureBarcode = false;
            this.PossibleFormats = null;
        }


    }

    /// <summary>
    /// バーコードリーダーを実装します
    /// </summary>
    public class QRBarcodeReader
    {
        #region Env
        /// <summary>
        /// 既定のオプション設定
        /// </summary>
        private static BarcodeReaderParams DefaultOptions = new BarcodeReaderParams();
        private BarcodeReaderParams _options = null;
        /// <summary>
        ///  バーコードリーダーのパラメタ設定
        /// </summary>
        public BarcodeReaderParams Options
        {
            get
            {
                if (this._options == null)
                {
                    this._options = DefaultOptions;
                    return this._options;
                }
                return this._options;

            }
        }
        /// <summary>
        /// パラメタを設定する
        /// </summary>
        public static void SetDefaultOption(BarcodeReaderParams param)
        {
            DefaultOptions = param;
        }

        #endregion
        /// <summary>
        /// バーコードリーダーのインスタンス
        /// </summary>
        private BarcodeReader reader = null;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public QRBarcodeReader()
        {
            this.reader = new BarcodeReader()
            {
                AutoRotate = Options.AutoRotate,
                TryInverted = Options.TryInverted,

                Options = new DecodingOptions()
                {
                    TryHarder = Options.TryHarder,
                    PureBarcode = Options.PureBarcode
                }
            };
        }
        /// <summary>
        /// 単一バーコードを読み取りする
        /// </summary>
        /// <param name="bitmap">画像</param>
        /// <returns>読み取り結果</returns>
        public BarcodeResult Decode(Bitmap bitmap)
        {
            try
            {
                BarcodeResult result = this.Decode(bitmap, false);
                if (!result.IsSuccess)
                {
                    result = this.Decode(bitmap, true);
                }
                return result;
            }
            catch (Exception ex)
            {
                return new BarcodeResult(ex);
            }
        }

     
        /// <summary>
        /// オプションを設定する
        /// </summary>
        private void SetOptions()
        {
            this.reader.AutoRotate = Options.AutoRotate;
            this.reader.TryInverted = Options.TryInverted;
            this.reader.Options.TryHarder = Options.TryHarder;
            this.reader.Options.PureBarcode = Options.PureBarcode;
        }

        /// <summary>
        ///  PureBarcodeを指定して、バーコードを読み取りする
        /// </summary>
        /// <param name="bitmap">画像</param>
        /// <param name="pureBarcode">モノクロ画像かどうか</param>
        /// <returns>読み取り結果</returns>
        private BarcodeResult Decode(Bitmap bitmap, bool pureBarcode)
        {
            try
            {
                Options.PureBarcode = pureBarcode;
                SetOptions();
                Result result = this.reader.Decode(bitmap);
                return new BarcodeResult(result);
            }
            catch (Exception ex)
            {
                return new BarcodeResult(ex);
            }
        }
        /// <summary>
        /// 複数バーコードを読み取りする
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public IList<BarcodeResult> DecodeMultiple(Bitmap bitmap)
        {
            Result[] results = this.reader.DecodeMultiple(bitmap);
            List<BarcodeResult> lstResult = new List<BarcodeResult>();
            if (results == null)
            {
                return lstResult;
            }
            
            foreach (var result in results)
            {
                lstResult.Add(new BarcodeResult(result));
            }
            return lstResult;
        }
    }


    /// <summary>
    /// バーコード認識結果を格納する
    /// </summary>
    public class BarcodeResult
    {
        /// <summary>
        /// バーコード認識成功かどうかを取得する
        /// </summary>
        public bool IsSuccess { get; private set; }
        /// <summary>
        /// 認識された生文字列
        /// </summary>
        public string RawText { get; private set; }
        /// <summary>
        /// 解析されたテキスト
        /// </summary>
        public string ParsedText { get; private set; }
        /// <summary>
        /// 解析されたテキストの種別
        /// </summary>
        public ParsedResultType ParsedType { get; private set; }
        /// <summary>
        /// バーコードの識別領域
        /// </summary>
        public Rectangle? ResultRegion { get; private set; }
        /// <summary>
        /// バーコードの種別
        /// </summary>
        public BarcodeFormat BarcodeFormat { get; private set; }
        /// <summary>
        ///  認識されたバイナリデータ
        /// </summary>
        public byte[] RawBytes { get; private set; }
        /// <summary>
        /// 認識されたメタデータ
        /// </summary>
        public IDictionary<ResultMetadataType, object> ResultMetadata { get; private set; }
        /// <summary>
        /// タイムスタンプ
        /// </summary>
        public long Timestamp { get; private set; }
        /// <summary>
        /// 解析結果
        /// </summary>
        public ParsedResult ParsedResult { get; private set; }
        /// <summary>
        /// 内部例外
        /// </summary>
        public Exception InnerException { get; private set; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="result"></param>
        public BarcodeResult(Result result)
        {
            if (result == null)
            {
                this.IsSuccess = false;
                return;
            }
            this.RawText = result.Text;
            this.BarcodeFormat = result.BarcodeFormat;
            this.RawBytes = result.RawBytes;
            this.ResultMetadata = new Dictionary<ResultMetadataType, object>(result.ResultMetadata);
            this.Timestamp = result.Timestamp;
            this.ParsedResult = ResultParser.parseResult(result);
            this.ParsedText = this.ParsedResult.DisplayResult;
            this.ParsedType = this.ParsedResult.Type;
            this.ResultRegion = GetRegion(result);
            this.IsSuccess = true;
        }
        /// <summary>
        /// 例外発生時のバーコード認識結果のコンストラクタ
        /// </summary>
        /// <param name="ex">内部例外</param>
        public BarcodeResult(Exception ex)
        {
            this.IsSuccess = false;
            this.InnerException = ex;

        }
        /// <summary>
        /// バーコードの領域を取得する
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private Rectangle? GetRegion(Result result)
        {
            if (result.ResultPoints == null || result.ResultPoints.Length == 0)
            {
                return null;
            }
            try
            {
                int sx = (int)result.ResultPoints.Min(p => p.X);
                int sy = (int)result.ResultPoints.Min(p => p.Y);
                int ex = (int)result.ResultPoints.Max(p => p.X);
                int ey = (int)result.ResultPoints.Max(p => p.Y);
                return new Rectangle(sx, sy, ex - sx, ey - sy);
            }
            catch
            {
                return null;
            }
        }

    }


}
