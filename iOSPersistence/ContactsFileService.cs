using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace iOSPersistence
{
    public class ContactsFileService
    {
        public const string FileName = "contact.json";
        public async Task GuardarContacto(Contacto contacto)
        {
            var path = GetPath();

            var contactos = await LeerContactos();
            contactos.Insert(0,contacto);

            var json = JsonConvert.SerializeObject(contactos);

            var stream = !File.Exists(path) ?
                File.Create(path) :
                File.OpenWrite(path);

            using(var writer = new StreamWriter(stream))
            {
                await writer.WriteAsync(json);
            }
        }

        public async Task<List<Contacto>> LeerContactos()
        {
            var path = GetPath();
            if (!File.Exists(path))
            {
                return new List<Contacto>();
            }

            string fileContent = string.Empty;
            using (var reader = new StreamReader(File.OpenRead(path)))
            {
                fileContent = await reader.ReadToEndAsync();
            }
            var contacts = JsonConvert.DeserializeObject<List<Contacto>>(fileContent);
            return contacts;
        }

        private string GetPath()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documents, "..", "Library", FileName);
        }
    }

    public class Contacto
    {
        public Contacto(string name, string phone)
        {
            Nombre = name;
            Telefono = phone;
        }
        public Contacto()
        {
        }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public override string ToString()
        {
            return $"{Nombre} - {Telefono}";
        }
    }
}
