using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClassReflect
{
    public partial class frmTestCreator : Form
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

        public frmTestCreator()
        {
            InitializeComponent();
        }
        /// <summary>
        /// XML document
        /// </summary>
        private XmlDocument xmldoc = null;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(this.txtOutputFolder.Text))
            {
                MessageBox.Show("出力フォルダを選択してください");
                return;
            }
            if (this.openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                int row = 3;
                string tempFile = System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                        Definition.TemplateName);
                    string fileName = this.openFileDialog.FileName;
                 
                        xmldoc = GetXmlDocument(fileName);
                        row = ReflectAssembly(fileName, row);
          
           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                txtOutputFolder.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }
        private int ReflectAssembly( string filePath,int row)
        {
            var asm = Assembly.LoadFrom(filePath);
            var types = asm.GetTypes().OrderBy(x => x.Namespace + "." + x.Name);
            foreach (Type type in types)
            {
                if (!type.IsNested && !type.IsAutoClass && !type.IsInterface && !string.IsNullOrEmpty(type.Namespace))
                {
                    row = WriteTypeInfo(type, row);
                }
            }
            return row;
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

        private int WriteTypeInfo( Type type, int row)
        {
            if (!checkNamespace(type))
            {
                return row;
            }
            //クラスInfo
            string dirPath= WriteClassHeader( type, row, true);
            row++;
            row = WriteMethods(type, row, dirPath);
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
        private int WriteMethods( Type type, int row,string dir)
        {
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.DeclaringType == type && (!x.IsSpecialName) && (!x.Name.Contains("__")) && (!x.Name.Equals("InitializeComponent")) )
                .OrderBy(x => x.Name);
            foreach (var method in methods)
            {
                if (!method.IsPublic)
                {
                    continue;
                }

                string fileName = System.IO.Path.Combine(dir, method.Name + "Test.cs");
                string ns = type.Name.Replace("Component", "");//{0}
                string classComment = Regex.Replace(this.GetSummary(method), @"\n", @"///\n");//{1}
                string className = method.Name; //{2}
                string methodComment = Regex.Replace(this.GetSummary(method), @"\n", @"///\n");//{3}
                string methodName = method.Name;//{4}
                string returnType = getTypeName(method.ReturnType);
                string excpted = string.Empty;
                string resultDeclare = string.Empty; //{9}
                string resultAssert = "";
                if (!returnType.Equals("void"))
                {
                    excpted = getTypeDeclare("expected", method.ReturnType);//{5}
                    resultDeclare = returnType + " result = ";
                    resultAssert = "Assert.AreEqual(expected , result);";

                }
                else
                {
                    excpted = "";//{5}
                }
                StringBuilder paramDeclare = new StringBuilder();//{6}
                StringBuilder paramCall = new StringBuilder();//{6}
                var paramters = method.GetParameters();//{7}
                var buniessName = type.Name; //{8}
                foreach(var param in paramters){
                    paramDeclare.AppendFormat("\t\t\t{0}\r\n", getTypeDeclare(param.Name,param.ParameterType));
                    if (paramCall.Length > 0)
                    {
                        paramCall.Append(",");
                    }
                    paramCall.Append(param.Name);
                }

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName,false,Encoding.UTF8))
                {
                    string file = string.Format(Properties.Resources.TestTemplate,
                                          ns, classComment, className, methodComment, methodName,
                                          excpted, paramDeclare.ToString(), paramCall.ToString(), buniessName, resultDeclare,resultAssert);
                    writer.Write(file);
                    writer.Write(Environment.NewLine);
                }
                row++;
            }
            return row;
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

        /// <summary>
        /// C#のタイプ名へ変換
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string getTypeDeclare(string param,Type type)
        {
            string name = type.Name;
            string value = "null";
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
                value = "string.Empty";
            }
            else if (type == typeof(int))
            {
                name = "int";
                value = "0";
            }
            else if (type == typeof(short))
            {
                name = "short";
                value = "0";
            }
            else if (type == typeof(long))
            {
                name = "long";
                value = "0";
            }
            else if (type == typeof(void))
            {
                return "";
            }
            else if (type == typeof(bool))
            {
                name = "bool";
                value = "false";
            }
            else if (type == typeof(object))
            {
                name = "object";
                value = "null";
            }
           
            return string.Format("{0} {1} = {2};", name , param, value);
        }


        //Classを書き出す
        private string  WriteClassHeader(Type type, int row, bool isHeader)
        {
            
            string dirName =type.Name;
            dirName = dirName.Replace("Component","");
            dirName=  System.IO.Path.Combine(this.txtOutputFolder.Text,dirName);
            if(!System.IO.Directory.Exists(dirName)){
                System.IO.Directory.CreateDirectory(dirName);
            }
            return dirName;
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
    }
}
