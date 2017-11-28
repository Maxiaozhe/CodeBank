using ClassReflect.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.ComponentModel.DataAnnotations.Schema;
namespace ClassReflect
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 抽出するNamespace
        /// </summary>
        private List<string> _namespaces = null;
        private List<string> TargetNamespaces
        {
            get
            {
                if (this._namespaces == null)
                {
                    _namespaces = new List<string>();
                    string buf = Properties.Settings.Default.OutputNamespaces;
                    if (!string.IsNullOrEmpty(buf))
                    {
                        string[] nms = buf.Split(',');
                        _namespaces.AddRange(nms);
                    }
                }
                return _namespaces;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// XML document
        /// </summary>
        private XmlDocument xmldoc = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                int row = 3;
                string tempFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        Definition.TemplateName);

                using (ExcelHelp xls = new ExcelHelp(tempFile))
                {
                    xls.BeginUpdate();
                    Excel.Worksheet sheet = xls.WorkBook.Sheets[Definition.SheetName];
                    string[] fileNames = this.openFileDialog.FileNames;
                    var assmFiles = fileNames.OrderBy(x => System.IO.Path.GetFileName(x));
                    foreach (string fileName in assmFiles)
                    {
                        xmldoc = GetXmlDocument(fileName);
                        textBox1.Text += fileName + "を抽出しています..." + System.Environment.NewLine;
                        Application.DoEvents();
                        row = ReflectAssembly(xls, sheet, fileName, row);
                    }
                    xls.EndUpdate();

                    if (this.saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        xls.Save(this.saveFileDialog1.FileName);
                    }
                }
            }
        }

        private int ReflectAssembly(ExcelHelp xls, Excel.Worksheet sheet, string filePath, int row)
        {
            var asm = Assembly.LoadFrom(filePath);
            var types = asm.GetTypes().OrderBy(x => x.Namespace + "." + x.Name);
            foreach (Type type in types)
            {
                if (!type.IsNested && !type.IsAutoClass && !type.IsInterface && !string.IsNullOrEmpty(type.Namespace))
                {
                    row = WriteTypeInfo(xls, sheet, type, row);
                }
            }
            return row;
        }

        private int WriteTypeInfo(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            if (!checkNamespace(type))
            {
                return row;
            }
            textBox1.Text += type.FullName + System.Environment.NewLine;
            textBox1.SelectionStart = textBox1.Text.Length - 1;
            textBox1.ScrollToCaret();
            Application.DoEvents();
            //クラスInfo
            WriteClassHeader(xls, sheet, type, row, true);
            row++;
            //コンストラクト
            row = WriteConstructor(xls, sheet, type, row);
            //Fields
            row = WriteFields(xls, sheet, type, row);
            //Properties
            row = WriteProperties(xls, sheet, type, row);
            //Methods
            row = WriteMethods(xls, sheet, type, row);
            return row;
        }
        /// <summary>
        /// メソッドを出力する
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheet"></param>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int WriteMethods(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.DeclaringType == type && (!x.IsSpecialName) && (!x.Name.Contains("__")) && (!x.Name.Equals("InitializeComponent")))
                .OrderBy(x => x.Name);
            foreach (var method in methods)
            {
                if (method.IsSpecialName || method.IsPrivate)
                {
                    string name = method.Name;
                }
                WriteClassHeader(xls, sheet, type, row, false);
                //TypeKind
                xls.WriteValue(sheet, Definition.TypeKind, row, GetMemberType(method.MemberType));
                //TypeName
                xls.WriteValue(sheet, Definition.TypeName, row, getTypeName(method.ReturnType));
                //BingAttibute
                xls.WriteValue(sheet, Definition.BingAttibute, row, method.IsPublic ? "+" : "-");
                //Name
                xls.WriteValue(sheet, Definition.MemberName, row, method.Name);
                var pms = method.GetParameters();
                string buff = "";
                foreach (var param in pms)
                {
                    if (!string.IsNullOrEmpty(buff))
                    {
                        buff += ", ";
                    }
                    buff += string.Format("{0} : {1}", param.Name, getTypeName(param.ParameterType));
                }
                //Paramter
                xls.WriteValue(sheet, Definition.MethodParams, row, string.IsNullOrEmpty(buff) ? "-" : buff);
                //Static
                if (method.IsStatic)
                {
                    xls.WriteValue(sheet, Definition.Memo, row, "static");
                }
                //summary
                string summary = GetSummary(method);
                if (!string.IsNullOrEmpty(summary))
                {
                    xls.WriteValue(sheet, Definition.MemberSummary, row, summary);
                }
                row++;
            }
            return row;
        }
        /// <summary>
        /// Propertyを出力する
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheet"></param>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int WriteProperties(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            bool isWriteAttribute = false;
            string tableName = "";
            if (type.Namespace.Equals("DenshowDataAccessInterface.Dto") ||
                type.Namespace.Equals("DenshowDataAccessInterface.Entity"))
            {
                isWriteAttribute = true;
                tableName = getAttribute(type.GetTypeInfo());
            }

            var props = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                        .Where(x => x.DeclaringType == type)
                        .OrderBy(x => x.Name);
   
            foreach (var prop in props)
            {
                if (prop.IsSpecialName)
                {
                    string name = prop.Name;
                }
                string attr = getAttribute(prop);
 
                WriteClassHeader(xls, sheet, type, row, false);
                //TypeKind
                xls.WriteValue(sheet, Definition.TypeKind, row, GetMemberType(prop.MemberType));
                //TypeName
                xls.WriteValue(sheet, Definition.TypeName, row, getTypeName(prop.PropertyType));
                //BingAttibute
                xls.WriteValue(sheet, Definition.BingAttibute, row, prop.CanRead ? "+" : "-");
                //Name
                xls.WriteValue(sheet, Definition.MemberName, row, prop.Name);
                //Paramter
                xls.WriteValue(sheet, Definition.MethodParams, row, "-");
                //summary
                string summary = GetSummary(prop);
                if (!string.IsNullOrEmpty(summary))
                {
                    xls.WriteValue(sheet, Definition.MemberSummary, row, summary);
                }
                //TableName
                if (isWriteAttribute)
                {
                    xls.WriteValue(sheet, Definition.TableName, row, tableName);
                    xls.WriteValue(sheet, Definition.ColumName, row, getAttribute(prop));
                }

                row++;
            }
            return row;
        }

        /// <summary>
        /// Fieldを出力
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheet"></param>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int WriteFields(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            var flds = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.DeclaringType == type && !x.Name.Contains("__")).OrderBy(x => x.Name);
            foreach (var fld in flds)
            {
                if (fld.FieldType==typeof(EventHandler))
                {
                    string text = GetSummary(fld);
                    if (!string.IsNullOrEmpty(text))
                    {
                        xls.WriteValue(sheet, Definition.MemberSummary, row, text);
                    }
                }
                WriteClassHeader(xls, sheet, type, row, false);
                //TypeKind
                xls.WriteValue(sheet, Definition.TypeKind, row, GetMemberType(fld.MemberType));
                //TypeName
                xls.WriteValue(sheet, Definition.TypeName, row, getTypeName(fld.FieldType));
                //BingAttibute
                xls.WriteValue(sheet, Definition.BingAttibute, row, fld.IsPublic ? "+" : "-");
                //Name
                xls.WriteValue(sheet, Definition.MemberName, row, fld.Name);
                //Paramter
                xls.WriteValue(sheet, Definition.MethodParams, row, "-");
                //Static
                if (fld.IsStatic)
                {
                    xls.WriteValue(sheet, Definition.Memo, row, "static");
                }
                //summary
                string summary = GetSummary(fld);
                if (!string.IsNullOrEmpty(summary))
                {
                    xls.WriteValue(sheet, Definition.MemberSummary, row, summary);
                }
                row++;
            }
            return row;
        }

        /// <summary>
        /// コンストラクタを出力する
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="sheet"></param>
        /// <param name="type"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int WriteConstructor(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            var ctors = type.GetConstructors();
            foreach (var ctor in ctors)
            {
                WriteClassHeader(xls, sheet, type, row, false);
                //TypeKind
                xls.WriteValue(sheet, Definition.TypeKind, row, GetMemberType(ctor.MemberType));
                //TypeName
                xls.WriteValue(sheet, Definition.TypeName, row, "-");
                //BingAttibute
                xls.WriteValue(sheet, Definition.BingAttibute, row, ctor.IsPublic ? "+" : "-");
                //Name
                xls.WriteValue(sheet, Definition.MemberName, row, type.Name);
                var pms = ctor.GetParameters();
                string buff = "";
                foreach (var param in pms)
                {
                    if (!string.IsNullOrEmpty(buff))
                    {
                        buff += ", ";
                    }
                    buff += string.Format("{0} : {1}", param.Name, getTypeName(param.ParameterType));
                }
                //Paramter
                xls.WriteValue(sheet, Definition.MethodParams, row, string.IsNullOrEmpty(buff) ? "-" : buff);
                //Static
                if (ctor.IsStatic)
                {
                    xls.WriteValue(sheet, Definition.Memo, row, "static");
                }
                //summary
                string summary = GetSummary(ctor);
                if (!string.IsNullOrEmpty(summary))
                {
                    xls.WriteValue(sheet, Definition.MemberSummary, row, summary);
                }
                else
                {
                    xls.WriteValue(sheet, Definition.MemberSummary, row, "コンストラクタ");
                }
                row++;
            }
            return row;
        }

        //Classを書き出す
        private void WriteClassHeader(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row, bool isHeader)
        {
            //NameSpace
            xls.WriteValue(sheet, Definition.NameSpace, row, type.Namespace);
            //className
            xls.WriteValue(sheet, Definition.ClassName, row, type.Name);
            //baseclass
            string buff = "";
            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                buff += type.BaseType.Name;
            }
            else
            {
                buff = GetInterfaces(type);
            }
            xls.WriteValue(sheet, Definition.BaseClass, row, string.IsNullOrEmpty(buff) ? "-" : buff);

            if (isHeader)
            {
                //Field Count
                int fldCount = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                 .Where(x => x.DeclaringType == type && !x.Name.Contains("__")).Count();
                fldCount += type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                 .Where(x => x.DeclaringType == type).Count();
                xls.WriteValue(sheet, Definition.FieldCount, row, fldCount.ToString());
                //Method Count
                var Methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                            .Where(x => x.DeclaringType == type && (!x.IsSpecialName) && (!x.Name.Contains("__")) && (!x.Name.Equals("InitializeComponent")));
                xls.WriteValue(sheet, Definition.MethodCount, row, Methods.Count().ToString());
                //TypeKind
                xls.WriteValue(sheet, Definition.TypeKind, row, GetMemberType(type.MemberType));
                //公開／非公開
                xls.WriteValue(sheet, Definition.BingAttibute, row, "-");
                //MemberName
                xls.WriteValue(sheet, Definition.MemberName, row, "-");
                //MethodParams
                xls.WriteValue(sheet, Definition.MethodParams, row, "-");
                //戻り値タイプ
                xls.WriteValue(sheet, Definition.TypeName, row, "-");
                //summary
                string summary = GetSummary(type.GetTypeInfo());
                if (!string.IsNullOrEmpty(summary))
                {
                    xls.WriteValue(sheet, Definition.ClassSummary, row, summary);
                }

            }
            WriteLayerName(xls, sheet, type, row);
        }
        /// <summary>
        /// MethodのIDを取得する
        /// </summary>
        /// <param name="minfo"></param>
        /// <returns></returns>
        private string getMethodId(MethodInfo minfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("M:");
            sb.Append(minfo.DeclaringType.Namespace + ".");
            sb.Append(minfo.DeclaringType.Name + ".");
            sb.Append(minfo.Name);
            var prams = minfo.GetParameters();
            if (prams.Count() == 0)
            {
                return sb.ToString();
            }
            string buff = "";
            sb.Append("(");
            foreach (var param in prams)
            {
                if (!string.IsNullOrEmpty(buff))
                {
                    buff += ",";
                }
                buff += getGenericTypeName(param.ParameterType);
            }
            sb.Append(buff);
            sb.Append(")");

            return sb.ToString();
        }
        private string getConstructId(ConstructorInfo minfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("M:");
            sb.Append(minfo.DeclaringType.Namespace + ".");
            sb.Append(minfo.DeclaringType.Name + ".");
            sb.Append("#ctor");
            var prams = minfo.GetParameters();
            if (prams.Count() == 0)
            {
                return sb.ToString();
            }
            string buff = "";
            sb.Append("(");
            foreach (var param in prams)
            {
                if (!string.IsNullOrEmpty(buff))
                {
                    buff += ",";
                }
                buff += getGenericTypeName(param.ParameterType);
            }
            sb.Append(buff);
            sb.Append(")");

            return sb.ToString();
        }

        private string getGenericTypeName(Type type)
        {
            if (!type.IsGenericType)
            {
                return type.FullName;
            }
            string name = type.Namespace + "." + type.Name;
            int pos = name.IndexOf("`");
            if (pos > -1)
            {
                name = name.Substring(0, pos);
            }
            Type[] gps = type.GenericTypeArguments;
            name += "{";
            for (var i = 0; i < gps.Length; i++)
            {
                if (i > 0)
                {
                    name += ",";
                }
                name += getGenericTypeName(gps[i]);
            }
            name += "}";
            return name;

        }
        /// <summary>
        /// 属性情報を取得する
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        private string getAttribute(MemberInfo typeInfo)
        {
            var attrs = typeInfo.GetCustomAttributes();
           foreach (var attr in attrs)
           {
               if(attr is ColumnAttribute){
                  return ((ColumnAttribute)attr).Name;
               }
               if (attr is TableAttribute)
               {
                   return ((TableAttribute)attr).Name;
               }    
           }
           return string.Empty;
        }


        /// <summary>
        /// C#のタイプ名へ変換
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string getTypeName(Type type)
        {
            string name = type.Name;
            if (type.IsGenericType)
            {
                int pos = name.IndexOf("`");
                if (pos > -1)
                {
                    name = name.Substring(0, pos);
                }
                if (type.GenericTypeArguments != null && type.GenericTypeArguments.Length > 0)
                {
                    Type[] gps = type.GenericTypeArguments;
                    name += "<";
                    for (var i = 0; i < gps.Length; i++)
                    {
                        if (i > 0)
                        {
                            name += ",";
                        }
                        name += getTypeName(gps[i]);
                    }
                    name += ">";
                }
            }
            else if (type == typeof(string))
            {
                name = "string";
            }
            else if (type == typeof(int))
            {
                name = "int";
            }
            else if (type == typeof(short))
            {
                name = "short";
            }
            else if (type == typeof(long))
            {
                name = "long";
            }
            else if (type == typeof(void))
            {
                name = "void";
            }
            else if (type == typeof(bool))
            {
                name = "bool";
            }
            else if (type == typeof(object))
            {
                name = "object";
            }

            return name;
        }

        private string GetInterfaces(Type type)
        {
            if (type.IsInterface)
            {
                return "";
            }
            var interfaces = type.GetInterfaces();
            string name = "";
            foreach (var iface in interfaces)
            {
                if (iface.DeclaringType == type)
                {
                    if (!string.IsNullOrEmpty(name))
                    {
                        name += " , ";
                    }
                    name += iface.Name;
                }
            }
            return name;
        }

        private string GetMemberType(MemberTypes memType)
        {
            switch (memType)
            {
                case MemberTypes.Constructor:
                    return "コンストラクタ";
                case MemberTypes.Event:
                    return "イベント";
                case MemberTypes.Field:
                    return "フィールド";
                case MemberTypes.Method:
                    return "メソッド";
                case MemberTypes.Property:
                    return "プロパティ";
                case MemberTypes.TypeInfo:
                    return "クラス";
                default:
                    return "";
            }
        }

        private bool checkNamespace(Type type)
        {
            if (this.TargetNamespaces.Count == 0)
            {
                return true;
            }
            string typeNm = type.Namespace;
            var isTarget = this.TargetNamespaces.Exists(
                x => !string.IsNullOrEmpty(typeNm) && (x.Equals(typeNm) || typeNm.StartsWith(x + ".")));
            return isTarget;
        }

        private void WriteLayerName(ExcelHelp xls, Excel.Worksheet sheet, Type type, int row)
        {
            switch (type.Namespace)
            {
                case "DenshowBusinessComponent":
                    //layer
                    xls.WriteValue(sheet, Definition.LayerType, row, "ビジネスロジック層");
                    xls.WriteValue(sheet, Definition.Category, row, "ロジック");
                    break;
                case "DenshowBusinessInterface":
                    xls.WriteValue(sheet, Definition.LayerType, row, "ビジネスロジック層");
                    xls.WriteValue(sheet, Definition.Category, row, "ファクトリー");
                    break;
                case "DenshowBusinessInterface.Component":
                case "DenshowBusinessInterface.Entity":
                    xls.WriteValue(sheet, Definition.LayerType, row, "ビジネスロジック層");
                    xls.WriteValue(sheet, Definition.Category, row, "エンティティ");
                    break;
                case "DenshowDataAccessComponent":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    xls.WriteValue(sheet, Definition.Category, row, "データアクセス");
                    break;
                case "DenshowDataAccessComponent.Dao":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    xls.WriteValue(sheet, Definition.Category, row, "データアクセス");
                    break;
                case "DenshowDataAccessImpl.Dao":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    xls.WriteValue(sheet, Definition.Category, row, "管理");
                    xls.GetRange(sheet, 2, 2, row, row).Font.Color = Excel.XlRgbColor.rgbRed;
                    break;
                case "DenshowDataAccessComponent.Properties":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    xls.WriteValue(sheet, Definition.Category, row, "システム");
                    break;
                case "DenshowDataAccessInterface":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    if (type.Name.EndsWith("Factory"))
                    {
                        xls.WriteValue(sheet, Definition.Category, row, "ファクトリー");
                    }
                    break;
                case "DenshowDataAccessInterface.Dto":
                case "DenshowDataAccessInterface.Entity":
                    xls.WriteValue(sheet, Definition.LayerType, row, "データアクセス層");
                    xls.WriteValue(sheet, Definition.Category, row, "エンティティ");
                    break;
                case "DenshowCommon":
                    xls.WriteValue(sheet, Definition.LayerType, row, "各層共通");
                    xls.WriteValue(sheet, Definition.Category, row, "共通");
                    break;
                case "DenshowNativeCommon":
                    xls.WriteValue(sheet, Definition.LayerType, row, "各層共通画像処理");
                    xls.WriteValue(sheet, Definition.Category, row, "共通");
                    break;
                case "ReportDefinition.Base":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "画面");
                    break;
                case "ReportDefinition.Checklist":
                case "ReportDefinition.ControlDefinision":
                case "ReportDefinition.Menu":
                case "ReportDefinition.Monitoring":
                case "ReportDefinition.ReportForm":
                case "ReportDefinition.Template":
                case "ReportDefinition.User":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "画面");
                    break;
                case "ReportDefinition.Process":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "プロセス");
                    break;

                case "ReportDefinition.Properties":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "システム");
                    break;
                case "ReportDefinitionControl.Button":
                case "ReportDefinitionControl.Cell":
                case "ReportDefinitionControl.ComboBoxItem":
                case "ReportDefinitionControl.Label":
                case "ReportDefinitionControl.Menu":
                case "ReportDefinitionControl.Picture2.ContextMenu.Menu":
                case "ReportDefinitionControl.Picture2.ContextMenu.MenuItem":
                case "ReportDefinitionControl.TextBox":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "共通コントロール");
                    break;
                case "ReportDefinitionControl.Picture2":
                case "ReportDefinitionControl.Picture2.CustomControl":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "描画コントロール");
                    break;
                case "ReportDefinitionControl.Picture2.Entity":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "管理");
                    break;
                case "ReportDefinitionControl.Properties":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "システム");
                    break;
                case "ReportService":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "システム");
                    break;
                case "ReportServiceProto.Process":
                    xls.GetRange(sheet, 2, 2, row, row).Font.Color = Excel.XlRgbColor.rgbRed;
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "プロセス");
                    break;
                case "RecogResultCorrection":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    if (!type.Name.Equals("Global"))
                    {
                        xls.WriteValue(sheet, Definition.Category, row, "Web画面");
                    }
                    else
                    {
                        xls.WriteValue(sheet, Definition.Category, row, "メイン");
                    }

                    break;
                case "RecogResultCorrection.Process":
                    xls.WriteValue(sheet, Definition.LayerType, row, "プレゼンテーション層");
                    xls.WriteValue(sheet, Definition.Category, row, "プロセス");
                    break;
                case "JocrSDKInterface":
                case "JocrSDKComponent":
                case "HocrSDKInterface":
                case "HocrSDKComponent":
                case "FormSDKInterface":
                case "FormSDKComponent":
                case "DocumentSDKInterface":
                case "DocumentSDKComponent":
                case "DocumentSDKCommon":
                    xls.WriteValue(sheet, Definition.LayerType, row, "ビジネスロジック層（SDK）");
                    if (type.Name.Equals(type.Namespace))
                    {
                        xls.WriteValue(sheet, Definition.Category, row, "ロジック");
                    }
                    break;
                default:
                    break;

            }
        }

        private string GetSummaryId(MemberInfo memInfo)
        {
            StringBuilder nsb = new StringBuilder();
            switch (memInfo.MemberType)
            {

                case MemberTypes.Field:
                    nsb.Append("F:");
                    nsb.Append(memInfo.DeclaringType.Namespace + ".");
                    nsb.Append(memInfo.DeclaringType.Name + ".");
                    nsb.Append(memInfo.Name);
                    break;
                case MemberTypes.Method:
                    return getMethodId((MethodInfo)memInfo);
                case MemberTypes.Constructor:
                    return getConstructId((ConstructorInfo)memInfo);
                case MemberTypes.Property:
                    nsb.Append("P:");
                    nsb.Append(memInfo.DeclaringType.Namespace + ".");
                    nsb.Append(memInfo.DeclaringType.Name + ".");
                    nsb.Append(memInfo.Name);
                    break;
                case MemberTypes.TypeInfo:
                    nsb.Append("T:");
                    nsb.Append(((TypeInfo)memInfo).Namespace + ".");
                    nsb.Append(((TypeInfo)memInfo).Name);
                    break;
                default:
                    break;
            }
            return nsb.ToString();
        }

        private XmlDocument GetXmlDocument(string asmfile)
        {
            string path = System.IO.Path.GetDirectoryName(asmfile);
            string xmlfileName = System.IO.Path.GetFileNameWithoutExtension(asmfile) + ".xml";
            string xmldocPath = System.IO.Path.Combine(path, xmlfileName);
            if (!System.IO.File.Exists(xmldocPath))
            {
                return null;
            }
            XmlDocument xml = new XmlDocument();
            xml.Load(xmldocPath);
            return xml;
        }

        private string GetSummary(MemberInfo info)
        {
            string xpath = "//member[@name='{0}']/summary";
            if (xmldoc == null)
            {
                return "";
            }
            string id = GetSummaryId(info);
            try
            {
                var nodes = xmldoc.SelectNodes(string.Format(xpath, id));
                if (nodes == null || nodes.Count == 0)
                {
                    return "";
                }
                string innerText = Regex.Replace(nodes[0].InnerText, @"^[\r\n]|[\r\n]$|\s+", "");
                return innerText.Trim();
            }
            catch
            {
                return string.Empty;
            }

        }


    }
}
