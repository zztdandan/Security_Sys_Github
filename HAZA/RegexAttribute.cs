using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;   
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Contexts;
namespace RegexAttr
{

                              //应用反射技术获得特性信息

    //定制特性也可以应用在其他定制特性上，
    //应用AttributeUsage，来控制如何应用新定义的特性
    [AttributeUsageAttribute(AttributeTargets.Property,       //可应用任何元素
        AllowMultiple = true,                            //允许应用多次
        Inherited = false)]                              //不继承到派生类
    //特性也是一个类，
    //必须继承自System.Attribute类，
    //命名规范为："类名"+Attribute。        
    public class RegexXAttribute : System.Attribute
    {
        //定义字段
        private string _regex_str;
        private string _matchtext;
        public bool mSuccess { get; set; }
        public string mValue { get; set; }

        public string RegexStr { get { return this._regex_str; } set { this._regex_str = value; } }
        //public string MatchVal { get; set; }
        //public bool MatchSuc { get; set; }
 
        //必须定义其构造函数，如果不定义有编译器提供无参默认构造函数

        public RegexXAttribute(string regex_str)
        {
            this._regex_str = regex_str;
        }

        //定义属性
        //显然特性和属性不是一回事儿
     

        //定义方法
        public void DoMatch(string matchtext)
        {
            Regex r = new Regex(_regex_str,RegexOptions.IgnoreCase|RegexOptions.Singleline);
            Match m = r.Match(_matchtext);
            this.mSuccess = m.Success;
            this.mValue = m.Value;
        }
    }

    public class ValidationModel
    {

        public void Validate(object obj)
        {
            var t = obj.GetType();

            //由于我们只在Property设置了Attibute,所以先获取Property
            var properties = t.GetProperties();
            foreach (var property in properties)
            {

                //这里只做一个stringlength的验证，这里如果要做很多验证，需要好好设计一下,千万不要用if elseif去链接
                //会非常难于维护，类似这样的开源项目很多，有兴趣可以去看源码。
                //如果没有这个属性则跳过
                if (!property.IsDefined(typeof(RegexXAttribute), false)) continue;

                var attributes = property.GetCustomAttributes(typeof(RegexXAttribute),false);
                foreach (RegexXAttribute attribute in attributes)
                {
                    var propertyValue = property.GetValue(obj,null);
                    attribute.DoMatch(propertyValue.ToString());

                    //获取属性的值

                    if (propertyValue == null)
                    { }

                    if (!attribute.mSuccess)
                        throw new Exception(string.Format("属性{0}的值{1}不符合要求{2}", property.Name, propertyValue, attribute.RegexStr));
                }
            }

        }
//public void ValidateProp(object )


    }
}
