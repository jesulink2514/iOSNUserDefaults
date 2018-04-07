using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace iOSPersistence
{
    public partial class ContactsViewController : UITableViewController
    {
        public const string CellId = "ContactsCell";
        public ContactsViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell),CellId);
        }

        public override async void ViewDidLoad()
        {
            var contacts = await Application.ContactsService.LeerContactos();
            TableView.DataSource = new ContactsDataSource(contacts);
            TableView.ReloadData();
        }
    }

    public class ContactsDataSource : UITableViewDataSource
    {
        private readonly List<Contacto> contactos;

        public ContactsDataSource(List<Contacto> contactos)
        {
            this.contactos = contactos;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ContactsViewController.CellId);
            var contact = contactos[indexPath.Row];

            cell.TextLabel.Text = contact.ToString();

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return contactos.Count;    
        }
    }
}