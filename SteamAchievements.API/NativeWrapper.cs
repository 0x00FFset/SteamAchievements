using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace SteamAchievements.API;

public abstract class NativeWrapper<TNativeFunctions> : INativeWrapper
{
    protected IntPtr ObjectAddress;
    protected TNativeFunctions Functions;

    public override string ToString()
    {
        return string.Format(
            System.Globalization.CultureInfo.CurrentCulture,
            "Steam Interface<{0}> #{1:X8}",
            typeof(TNativeFunctions),
            this.ObjectAddress.ToInt32());
    }

    public void SetupFunctions(IntPtr objectAddress)
    {
        this.ObjectAddress = objectAddress;

        var iface = (NativeClass)Marshal.PtrToStructure(
            this.ObjectAddress,
            typeof(NativeClass));

        this.Functions = (TNativeFunctions)Marshal.PtrToStructure(
            iface.VirtualTable,
            typeof(TNativeFunctions));
    }

    private readonly Dictionary<IntPtr, Delegate> _FunctionCache = new Dictionary<IntPtr, Delegate>();

    protected Delegate GetDelegate<TDelegate>(IntPtr pointer)
    {
        Delegate function;

        if (this._FunctionCache.ContainsKey(pointer) == false)
        {
            function = Marshal.GetDelegateForFunctionPointer(pointer, typeof(TDelegate));
            this._FunctionCache[pointer] = function;
        }
        else
        {
            function = this._FunctionCache[pointer];
        }

        return function;
    }

    protected TDelegate GetFunction<TDelegate>(IntPtr pointer)
        where TDelegate : class
    {
        return (TDelegate)((object)this.GetDelegate<TDelegate>(pointer));
    }

    protected void Call<TDelegate>(IntPtr pointer, params object[] args)
    {
        this.GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
    }

    protected TReturn Call<TReturn, TDelegate>(IntPtr pointer, params object[] args)
    {
        return (TReturn)this.GetDelegate<TDelegate>(pointer).DynamicInvoke(args);
    }
}