using System;
using System.IO;
using System.Xml;

namespace WorkTimer
{
    /// <summary>
    /// XMLファイルIOのインターフェースを提供する抽象クラスです。
    /// </summary>
    public abstract class XmlService
    {
        /// <summary>設定XML</summary>
        protected XmlDocument xmlDoc;

        /// <summary>設定ファイルのパス (有効な設定が読み込まれていない状態では null)</summary>
        public string FilePath { get; private set; }

        /// <summary>内部で保持しているXMLの文字列</summary>
        public string XmlText
        {
            get { return (this.xmlDoc == null) ? null : this.xmlDoc.OuterXml; }
        }

        #region 抽象メソッド

        /// <summary>
        /// 指定されたXMLオブジェクトの内容をクラスのメンバに読み込みます。
        /// </summary>
        /// <param name="xd">入力するXMLオブジェクト</param>
        /// <returns>エラーメッセージ (正常終了時は null)</returns>
        public abstract string Import(XmlDocument xd);

        /// <summary>
        /// クラスが保持しているデータをXMLオブジェクトに出力します。
        /// </summary>
        /// <param name="xd">出力対象のXMLオブジェクト</param>
        /// <returns>エラーメッセージ (正常終了時は null)</returns>
        public abstract string Export(XmlDocument xd);

        #endregion // 抽象メソッド

        #region コンストラクタ
        /// <summary>コンストラクタ</summary>
        public XmlService()
        {
            this.FilePath = null;
            this.xmlDoc = null;
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="filePath">設定ファイルのパス</param>
        public XmlService(string filePath)
        {
            this.FilePath = null;
            this.xmlDoc = null;

            string errorMsg = Import(filePath);
            if (errorMsg != null)
            {
                throw new Exception(errorMsg);
            }
        }
        #endregion // コンストラクタ

        #region Import
        /// <summary>
        /// XMLファイルをインポートします。
        /// </summary>
        /// <param name="path">設定ファイルのパス</param>
        public string Import(string path)
        {
            if (!File.Exists(path))
            {
                return string.Format("The file does not exist: {0}", path);
            }

            try
            {
                var xd = new XmlDocument();
                xd.Load(this.FilePath);

                string errorMsg = Import(xd);
                if (errorMsg != null)
                {
                    return errorMsg;
                }

                this.FilePath = path;
                this.xmlDoc = xd;
            }
            catch (Exception ex)
            {
                return string.Format("The file could not be imported as a XML file: {0}[{1}]",
                                        ex.Message, path);
            }

            return null;
        }
        #endregion // Import

        #region Export
        /// <summary>
        /// クラスが保持しているデータをXMLファイルに出力します。
        /// </summary>
        /// <param name="path">出力先のパス</param>
        /// <returns>エラーメッセージ (正常終了時は null)</returns>
        public string Export(string path)
        {
            string errorMsg = Export(this.xmlDoc);
            if (errorMsg != null)
            {
                return errorMsg;
            }

            try
            {
                string dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                this.xmlDoc.Save(path);
            }
            catch (Exception ex)
            {
                return string.Format("The XML could not be exported to {0}: {1}[{2}]",
                                        path, ex.Message, this.xmlDoc);
            }
            return null;
        }
        #endregion // Export
    }

    /// <summary>
    /// アプリケーション設定ファイルのIOを行、インポートした設定を保持するクラスです。
    /// </summary>
    public class AppSetting : XmlService
    {
        // 抽象メソッドの実装

        #region Import
        /// <summary>
        /// 指定されたXMLオブジェクトの内容をクラスのメンバに読み込みます。
        /// </summary>
        /// <param name="xd">入力するXMLオブジェクト</param>
        /// <returns>エラーメッセージ (正常終了時は null)</returns>
        public override string Import(XmlDocument xd)
        {
            throw new NotImplementedException();
        }
        #endregion // Import

        #region Export
        /// <summary>
        /// クラスが保持しているデータをXMLオブジェクトに出力します。
        /// </summary>
        /// <param name="xd">出力対象のXMLオブジェクト</param>
        /// <returns>エラーメッセージ (正常終了時は null)</returns>
        public override string Export(XmlDocument xd)
        {
            throw new NotImplementedException();
        }
        #endregion // Export
    }
}