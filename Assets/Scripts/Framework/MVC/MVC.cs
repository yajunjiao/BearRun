using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class MVC
{
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Type> commandMap = new Dictionary<string, Type>();

    //注册
    public static void RegisterView(View view)
    {
        view.RegisterAttentionEvent();
        Views[view.Name] = view;
    }

    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterController(string eventName, Type controllerType)
    {
        commandMap[eventName] = controllerType;
    }

    public static T GetModel<T>()
        where T:Model
    {
        foreach (var m in Models.Values)
        {
            if (m is T)
            {
                return (T)m;
            }
        }

        return null;
    }

    public static T GetView<T>()
        where T : View
    {
        foreach (var v in Views.Values)
        {
            if (v is T)
            {
                return (T)v;
            }
        }

        return null;
    }

    //发送事件
    public static void SendEvent(string eventName, object data = null)
    {
        //controller 执行
        if (commandMap.ContainsKey(eventName))
        {
            Type t = commandMap[eventName];
            Control c = Activator.CreateInstance(t) as Control;
            c.Execute(data);
        }

        //view处理
        foreach (var v in Views.Values)
        {
            if (v.AttentionList.Contains(eventName))
            {
                v.HandleEvent(eventName, data);
            }
        }
    }
}