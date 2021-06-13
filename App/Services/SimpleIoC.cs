using System;
using System.Collections.Generic;

namespace Rootmap.Configurator.Services
{
  public sealed class SimpleIoC
  {
    private static volatile SimpleIoC _instance;
    private static object _syncRoot = new object();
    private Dictionary<Type, Type> _multiInstance = new Dictionary<Type, Type>();
    private Dictionary<Type, object> _singletons = new Dictionary<Type, object>();

    private SimpleIoC() { }
    public static SimpleIoC Container
    {
      get
      {
        if (_instance == null)
        {
          lock (_syncRoot)
          {
            if (_instance == null)
              _instance = new SimpleIoC();
          }
        }

        return _instance;
      }
    }

    public void Register<T>()
    {
      RegisterSingleton<T, T>();
    }

    public void RegisterSingleton<T>()
    {
      RegisterSingleton<T, T>();
    }

    public void Register<TInterface, TImplementation>()
    {
      Validate<TInterface, TImplementation>();
      _multiInstance.Add(typeof(TInterface), typeof(TImplementation));
    }

    public void RegisterSingleton<TInterface, TImplementation>()
    {
      Validate<TInterface, TImplementation>();
      _singletons.Add(typeof(TInterface), Activator.CreateInstance(typeof(TImplementation)));
    }

    public void RegisterSingleton<TInterface, TImplementation>(TImplementation theSingleInstance)
    {
      Validate<TInterface, TImplementation>();
      _singletons.Add(typeof(TInterface), theSingleInstance);
    }

    public T Resolve<T>()
    {
      if (_singletons.ContainsKey(typeof(T)))
      {
        return (T)_singletons[typeof(T)];
      }
      else if (_multiInstance.ContainsKey(typeof(T)))
      {
        var theType = _multiInstance[typeof(T)];
        var obj = Activator.CreateInstance(theType);
        return (T)obj;
      }
      else
        throw new Exception($"Type {typeof(T).ToString()} is not registered");
    }

    private void Validate<TInterface, TImplementation>()
    {
      // This will fail up-front if the class cannot be instantiated correctly
      Activator.CreateInstance<TImplementation>();

      if (_multiInstance.ContainsKey(typeof(TInterface)))
      {
        throw new Exception($"Type {_multiInstance[typeof(TInterface)].ToString()} is already registered for {typeof(TInterface).ToString()}.");
      }
      else if (_singletons.ContainsKey(typeof(TInterface)))
      {
        throw new Exception($"Type {_singletons[typeof(TInterface)].ToString()} is already registered for {typeof(TInterface).ToString()}.");
      }
    }
  }
}
