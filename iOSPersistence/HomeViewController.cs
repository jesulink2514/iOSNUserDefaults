using Foundation;
using System;
using UIKit;

namespace iOSPersistence
{
    public partial class HomeViewController : UIViewController
    {
        public HomeViewController (IntPtr handle) : base (handle)
        {
        }

        async partial void UIButton724_TouchUpInside(UIButton sender)
        {
            var nombre = NombreText.Text;
            NombreText.ResignFirstResponder();
            NombreText.Text = string.Empty;

            var phone = TelefonoText.Text;
            TelefonoText.ResignFirstResponder();
            TelefonoText.Text = string.Empty;

           var contacto = new Contacto(nombre,phone);

           await Application.ContactsService.GuardarContacto(contacto);
        }
    }
}