using System;
using AppBox.Model_View;

namespace AppBox.Model_View_Build
{
    public class Model_View_Builder
    {
        /// <summary>
        /// 回传一个build的类
        /// </summary>
        /// <param name="ViewType"></param>
        /// <returns></returns>
        public static Object BuildViewTableEntity(string TypeName)
        {
            var AssemblyName = "AppBox.Model_View";
            var TypeStr = AssemblyName + "." + TypeName;
            var ListType=Type.GetType(TypeStr);
            var a = Activator.CreateInstance(ListType);
          
            return a;
        }
    }
}
