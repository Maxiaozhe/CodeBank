using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PoemWebService
{
    // メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にインターフェイス名 "IService2" を変更できます。
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void DoWork();
    }
}
