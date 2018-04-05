using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace iOSPersistence
{
    public partial class ContactsViewController : UITableViewController
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public const string CellId = "ContactsCell";
        public ContactsViewController (IntPtr handle) : base (handle)
        {
            TableView.RegisterClassForCellReuse(typeof(UITableViewCell),CellId);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            TableView.DataSource = new ContactsDataSource(this);

            TableView.ReloadData();
        }
    }

    public class ContactsDataSource : UITableViewDataSource
    {
        private readonly ContactsViewController controller;
        private readonly List<Tuple<string, string>> users;

        public ContactsDataSource(ContactsViewController controller)
        {
            this.controller = controller;
            this.users = new List<Tuple<string,string>>()
            {
                new Tuple<string,string>(controller.Name,controller.Phone)
            };
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ContactsViewController.CellId);
            var contact = users[indexPath.Row];

            cell.TextLabel.Text = $"{contact.Item1} - {contact.Item2}";

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return users.Count;    
        }
    }
}