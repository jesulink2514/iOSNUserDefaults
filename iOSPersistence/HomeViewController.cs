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

        partial void UIButton724_TouchUpInside(UIButton sender)
        {
            var nombre = NombreText.Text;
            NombreText.ResignFirstResponder();
            NombreText.Text = string.Empty;

            var phone = TelefonoText.Text;
            TelefonoText.ResignFirstResponder();
            TelefonoText.Text = string.Empty;

            var store = NSUserDefaults.StandardUserDefaults;

            store.SetString(nombre, "name");
            store.SetString(phone, "phone");
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var cont = (ContactsViewController)segue.DestinationViewController;
            var name = NSUserDefaults.StandardUserDefaults.StringForKey("name");
            var phone = NSUserDefaults.StandardUserDefaults.StringForKey("phone");
            cont.Name = name;
            cont.Phone = phone;

            base.PrepareForSegue(segue, sender);
        }
    }
}