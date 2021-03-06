using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.ObjectModel;
using log4net;
using System.Drawing;
using System.Reflection;

namespace FT.Commons.Tools
{
    /// <summary>
    /// 帮助把一个对象绑定到一个窗体上已经把窗体上的数据绑定到一个对象上
    /// 绑定使用getset的属性,不支持列表属性,暂不支持关联属性
    /// 只支持public的可访问性
    /// 自带cache，格式
    ///             实体类名 
    ///                         关联对象id,控件name-实体属性
    ///  窗体类名   实体类名    关联对象id
    ///                         关联对象id
    ///             实体类名
    /// </summary>
    public class WebFormHelper : BaseHelper
    {

        public static void WriteScript(Page page,string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "script_tmp", script); 
        }

        public static void Alert(Page page,string msg)
        {
            WriteScript(page,"<script>alert('"+msg+"');</script>"); 
        }

        public static void Confirm(Page page,string msg)
        {
            WriteScript(page, "<script>confirm('" + msg + "');</script>"); 
        }

        private static Hashtable caches = new Hashtable();

        /// <summary>
        /// 窗体对象关联的缓存
        /// </summary>
        public static Hashtable Caches
        {
            get { return WebFormHelper.caches; }
        }

        /// <summary>
        /// 把窗体上的数据赋值到Object对象上
        /// </summary>
        /// <param name="form">窗体对象</param>
        /// <param name="obj">对象Object</param>
        public static void GetDataFromForm(Page form, object obj)
        {
            Type type = obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitFormType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.ToString()] as Hashtable;
                if (controls != null)
                {
                    GetDataFromControl(form, controls, obj);
                }
            }
        }
        /// <summary>
        /// 把参数data设置到object的name属性或者字段上
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        public static void SetDataToObject(object obj, string name, object data)
        {
            Type type = obj.GetType();
            PropertyInfo prop;
            FieldInfo field;
            prop = type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);

            if (prop != null)
            {
                prop.SetValue(obj, ParsePropertyInfo(prop, data), null);
            }
            else
            {
                field = type.GetField(name, BindingFlags.IgnoreCase | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                if (field != null)
                {
                    //field.SetValueDirect

                    field.SetValue(obj, ParseFieldInfo(field, data));
                }
            }
        }

        /// <summary>
        /// 从控件跟实体对应的缓存中设置数据到一个对象实体上
        /// </summary>
        /// <param name="ctr">具体的控件，一般用在form上</param>
        /// <param name="controls">缓存的hashtable</param>
        /// <param name="obj">对象实体</param>
        private static void GetDataFromControl(Control ctr, Hashtable controls, object obj)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                if (ctr.ID!=null&&controls.Contains(ctr.ID))
                {
                    SetDataToObject(obj, controls[ctr.ID].ToString(), GetControlValue(ctr));


                }
            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    GetDataFromControl(tmp, controls, obj);
                }
            }
        }

        /// <summary>
        /// 把一个对象赋值到窗体上
        /// </summary>
        /// <param name="form">窗体</param>
        /// <param name="obj">实体对象</param>
        public static void SetDataToForm(Page form, object obj)
        {
            if (form == null || obj == null)
            {
                return;
            }
            Type type = obj.GetType();
            if (!caches.Contains(form.GetType().FullName))
            {
                InitFormType(form, obj.GetType());
            }
            Hashtable table = caches[form.GetType().FullName] as Hashtable;
            if (table != null)
            {
                Hashtable controls = table[obj.GetType().FullName] as Hashtable;
                if (controls != null)
                {

                    SetDataToControl(form, controls, obj);

                }
            }
        }


        /// <summary>
        /// 根据PropertyInfo把数据data转换成合适的类型对象
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static object ParsePropertyInfo(PropertyInfo prop, object data)
        {
            if (prop.PropertyType == typeof(Int32))
            {
                try
                {
                    return Convert.ToInt32(data.ToString());
                }
                catch
                {
                    return -1;
                }
            }
            if (prop.PropertyType == typeof(string))
            {
                return data.ToString();
            }
            if (prop.PropertyType == typeof(DateTime))
            {
                return Convert.ToDateTime(data.ToString());
            }
            if (prop.PropertyType == typeof(Boolean))
            {
                string tmp = data.ToString();
                if (tmp == "是")
                {
                    return true;
                }
                else if (tmp == "否")
                {
                    return false;
                }
                return Convert.ToBoolean(tmp);
            }
            return null;
        }



        /// <summary>
        /// 根据FieldInfo把数据data转换成合适的类型对象
        /// </summary>
        /// <param name="field">FieldInfo</param>
        /// <param name="data">数据</param>
        /// <returns>合适的类型对象</returns>
        private static object ParseFieldInfo(FieldInfo field, object data)
        {
#if DEBUG
            string tt=field.Name;
#endif
            if (field.FieldType == typeof(Int32))
            {
                try
                {
                    return Convert.ToInt32(data.ToString());
                }
                catch
                {
                    return -1;
                }
            }
            if (field.FieldType == typeof(double))
            {
                try
                {
                    return Convert.ToDouble(data.ToString());
                }
                catch
                {
                    return 0.0D;
                }
            }
            if (field.FieldType == typeof(decimal))
            {
                try
                {
                    return Convert.ToDecimal(data.ToString());
                }
                catch
                {
                    return 0.0M;
                }
            }
            if (field.FieldType == typeof(string))
            {
                return data.ToString();
            }
            if (field.FieldType == typeof(DateTime))
            {
                if (data.ToString().Length == 0)
                {
                    return null;
                }
                return Convert.ToDateTime(data.ToString());
            }
            if (field.FieldType == typeof(Boolean))
            {
                string tmp = data.ToString();
                if (tmp == "是")
                {
                    return true;
                }
                else if (tmp == "否")
                {
                    return false;
                }
                return Convert.ToBoolean(tmp);
            }
            return null;
        }
        /// <summary>
        /// 获取对象名字为name的属性或者字段值，首先属性，属性没有则取字段
        /// 字段没有则返回空
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetObjectValue(object obj, string name)
        {
            PropertyInfo prop;
            FieldInfo field;
            Type type = obj.GetType();
            prop = type.GetProperty(name);
            if (prop != null)
            {
                return prop.GetValue(obj, null);
            }
            else
            {
                field = type.GetField(name);
                if (field != null)
                {
                    return field.GetValue(obj);
                }
            }
            return null;
        }

        /// <summary>
        /// 把object数据全部赋值给control上去
        /// </summary>
        /// <param name="ctr"></param>
        /// <param name="controls"></param>
        /// <param name="obj"></param>
        private static void SetDataToControl(Control ctr, Hashtable controls, object obj)
        {
            int count = ctr.Controls.Count;

            if (ctr!=null&&ctr.ID!=null&&count == 0)
            {
                if (controls.Contains(ctr.ID))
                {
                    object objtmp = GetObjectValue(obj, controls[ctr.ID].ToString());
                    if (objtmp != null)
                    {
                        SetControlValue(ctr, objtmp);
                    }

                }

            }
            else
            {
                foreach (Control tmp in ctr.Controls)
                {
                    SetDataToControl(tmp, controls, obj);
                }
            }
        }

        /// <summary>
        /// 获取控件的值,返回具体控件的值
        /// </summary>
        /// <param name="ctr">控件，支持 以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// ComboBox Dropdownlist cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>获取控件的值</returns>
        private static object GetControlValue(Control ctr)
        {
            object result = null;
            if (ctr is Label)
            {
                result = ((Label)ctr).Text.ToString();
            }
            else if (ctr is TextBox)
            {
                result = ((TextBox)ctr).Text.ToString();
            }

            else if (ctr is DropDownList)
            {
                if (ctr.ID.EndsWith("Value"))
                {
                    object cbtmp = ((DropDownList)ctr).SelectedValue;
                    if (cbtmp != null)
                        result = cbtmp.ToString();
                    else
                        result = string.Empty;
                }
                else
                {
                    result = ((DropDownList)ctr).Text.ToString();
                }
            }
            
            else if (ctr is CheckBox)
            {
                result = ((CheckBox)ctr).Checked ? "是" : "否";
            }
            else if (ctr is RadioButtonList)
            {
                result = ((RadioButtonList)ctr).Text;
            }
            
            return result;
        }

        /// <summary>
        /// 为某个控件赋值,自动根据value值转换后赋值给控件
        /// </summary>
        /// <param name="ctr">控件，支持 以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// ComboBox cb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <param name="value">具体的值</param>
        private static void SetControlValue(Control ctr, object value)
        {
            /*
            if (value is double)
            {
                value = string.Format("{0:N2}", value);
            }
             * */
            if (value == null)
            {
                return;
            }
            if (ctr is Label)
            {
                ((Label)ctr).Text = value.ToString();
            }
            else if (ctr is TextBox)
            {
                ((TextBox)ctr).Text = value.ToString();
            }

           

            else if (ctr is DropDownList)
            {
                if (ctr.ID.EndsWith("Value"))
                {
                    ((DropDownList)ctr).SelectedValue = value.ToString();

                }
                else
                {
                    ((DropDownList)ctr).Text = value.ToString();
                }
            }
          
            else if (ctr is CheckBox)
            {
                ((CheckBox)ctr).Checked = (value.ToString() == "是" || value.ToString().ToLower() == "true" ? true : false);
            }
            else if (ctr is RadioButtonList)
            {
                ((RadioButtonList)ctr).Text = value.ToString();
            }
            
        }

        /// <summary>
        /// 根据控件名称得出跟实体对应的属性名
        /// </summary>
        /// <param name="ctr">控件支持以下对象属性的简写
        /// Label lb
        /// TextBox txt
        /// MaskedBox mtxt
        /// ComboBox cb
        /// LinkLabel lb
        /// DateTimePicker date
        /// CheckBox check
        /// PictureBox pic</param>
        /// <returns>属性名</returns>
        public static string ParseControlName(Control ctr)
        {
            string result = string.Empty;
            string name = ctr.ID;
            //num控件 包括一个 没有名字的textbox
            if(name==null)
            {

                return string.Empty;
            }
            if (name.Length == 0)
            {
                return string.Empty;
            }
            if (ctr is Label)
            {
                result = name.Substring(2);
            }
            else if (ctr is TextBox)
            {
                result = name.Substring(3);
            }
            

            else if (ctr is DropDownList)
            {
                if (name.EndsWith("Value"))
                {
                    ///这个是否正确
                    result = name.Substring(2, name.Length - 7);
                }
                else
                {
                    result = name.Substring(2);
                }
            }
            
            else if (ctr is CheckBox)
            {
                result = name.Substring(5);
            }
            else if (ctr is RadioButtonList)
            {
                result = name.Substring(3);
            }
            
            log.Debug(ctr.ID + "转换后控件的名称为：" + result);
            return result;

        }

        /// <summary>
        ///  从窗体控件获取跟某一类类型对应的实例
        /// </summary>
        /// <param name="ctr">控件，一般指窗体</param>
        /// <param name="type">类型</param>
        /// <param name="controls">缓存的hashtable</param>
        private static void InitControl(Control ctr, Type type, Hashtable controls)
        {
            int count = ctr.Controls.Count;
            if (count == 0)
            {
                string prop = ParseControlName(ctr);
                if (prop.Length>0&&(type.GetProperty(prop) != null || type.GetField(prop) != null))
                {
                    controls.Add(ctr.ID, prop);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    InitControl(ctr.Controls[i], type, controls);
                }
            }
        }
        /// <summary>
        /// 从窗体控件获取跟某一类类型对应的实例
        /// </summary>
        /// <param name="form">窗体实例</param>
        /// <param name="type">对象类型</param>
        private static void InitFormType(Page form, Type type)
        {

            string prop = string.Empty;
            Hashtable table = new Hashtable();
            Hashtable controls = new Hashtable();
            InitControl(form, type, controls);
            if (controls.Count > 0)
            {
                table.Add(type.FullName, controls);
                caches.Add(form.GetType().FullName, table);
            }
        }
    }
}
