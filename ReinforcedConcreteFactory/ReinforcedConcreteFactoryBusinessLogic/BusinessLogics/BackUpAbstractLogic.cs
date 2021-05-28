using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace ReinforcedConcreteFactoryBusinessLogic.BusinessLogics
{
    public abstract class BackUpAbstractLogic
    {
        public void CreateArchive(string folderName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName);
                if (dirInfo.Exists)
                {
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
                string fileName = $"{folderName}.zip";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                // берем сборку, чтобы от нее создавать объекты
                Assembly assem = GetAssembly();
                // вытаскиваем список классов для сохранения
                var dbsets = GetFullList();
                // берем метод для сохранения (из базвого абстрактного класса)
                MethodInfo method = GetType().BaseType.GetTypeInfo().GetDeclaredMethod("SaveToFile");
                foreach (var set in dbsets)
                {
                    // создаем объект из класса для сохранения
                    var elem =
                    assem.CreateInstance(set.PropertyType.GenericTypeArguments[0].FullName);
                    // генерируем метод, исходя из класса
                    MethodInfo generic = method.MakeGenericMethod(elem.GetType());
                    // вызываем метод на выполнение
                    generic.Invoke(this, new object[] { folderName });
                }
                // архивируем
                ZipFile.CreateFromDirectory(folderName, fileName);
                // удаляем папку
                dirInfo.Delete(true);
            }
            catch (Exception)
            {
                // делаем проброс
                throw;
            }
        }
        private void SaveToFile<T>(string folderName) where T : class, new()
        {
            var records = GetList<T>();
            T obj = new T();
            XmlSerializer xmlFormatter = new
            XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(string.Format("{0}/{1}.xml", folderName, obj.GetType().Name), FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fs, records);
            }
        }
        protected abstract Assembly GetAssembly();
        protected abstract List<PropertyInfo> GetFullList();
        protected abstract List<T> GetList<T>() where T : class, new();

    }
}
