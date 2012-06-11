using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClearCanvas.Common;
using System.Reflection;
namespace ClearCanvas.Ris.Client.Cache
{
    public class ClientCacheBase
    {
        public virtual  void Refesh()
        {
        }

        protected static  Dictionary<string, object> CacheData = new Dictionary<string, object>();
        public virtual void Clear( string key) {
            if (CacheData.ContainsKey(key))
            {
                CacheData.Remove(key);
            }
        }
        public string GetCachePath<T>()
        {
            string CacheFolderPath = "";
            return Path.Combine(CacheFolderPath, typeof(T).Name);
        }

        public static void RefreshAllCache()
        {
            var type = typeof(ClientCacheBase);

            List<Type> listOfDerivedClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsSubclassOf(type))
                .ToList();
            foreach (var derived in listOfDerivedClasses)
            {
                var  instance = Activator.CreateInstance(derived);

                MethodInfo method = derived.GetMethod("Refresh");
                method.Invoke(instance, null);
                Platform.Log(LogLevel.Info, derived.ToString() + " Being Refresh");
                // etc.
            }
        }
        public static void ClearAllCache()
        {
            CacheData = new Dictionary<string, object>();
        }
        public void Seriallize<T>(T obj)
        {

            using (Stream stream = File.Open(GetCachePath<T>(), FileMode.Create))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, obj);
            }
        }
        public  T Deserialize<T>()
        {
            string filename = GetCachePath<T>();
            FileInfo f = new FileInfo(filename);
            T objectToSerialize = default(T) ;
            if (!f.Exists)
                return objectToSerialize;
            
            using (Stream stream = File.Open(filename, FileMode.Open))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (T)bFormatter.Deserialize(stream);
            }
            return objectToSerialize;
        }
        public T GetCache<T>()
        {
            return Deserialize<T>();
        }
        public void WriteCache()
        {
            Seriallize<Dictionary<string, object>>(CacheData);
        }
        public void AddCache(string key, object obj)
        {
            CacheData.Add(key, obj);
        }
    }
}
