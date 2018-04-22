using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Control
{
    public abstract void Execute(Object data);

    //获取模型
    protected T GetModel<T>()
        where T : Model
    {
        return MVC.GetModel<T>() as T;
    }

    //获取视图
    protected T getView<T>()
        where T : View
    {
        return MVC.GetView<T>() as T;
    }

    protected void RegisterModel(Model model)
    {
        MVC.RegisterModel(model);
    }

    protected void RegisterView(View view)
    {
        MVC.RegisterView(view);
    }

    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }
}