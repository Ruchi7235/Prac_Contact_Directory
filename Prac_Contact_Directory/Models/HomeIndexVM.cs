using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prac_Contact_Directory.Models
{
    public class HomeIndexVM
    {
        private SelectList _ContactSelectList { get; set; }
        public SelectList ContactSelectList
        {
            get {
                
                    if (_ContactSelectList != null)
                        return _ContactSelectList;

                return new SelectList(GetContacts(), "Id");
            }
            set { _ContactSelectList = value; }
            }
        private List<Contact> GetContacts()
        {
            var contacts = new List<Contact>();
            contacts.Add(new Models.Contact() { EmployeeId = 1 });
            contacts.Add(new Models.Contact() { EmployeeId = 2 });
            contacts.Add(new Models.Contact() { EmployeeId = 3 });
            contacts.Add(new Models.Contact() { EmployeeId = 4 });
            contacts.Add(new Models.Contact() { EmployeeId = 5 });
            contacts.Add(new Models.Contact() { EmployeeId = 6 });
            contacts.Add(new Models.Contact() { EmployeeId = 7 });
            contacts.Add(new Models.Contact() { EmployeeId = 8 });
            contacts.Add(new Models.Contact() { EmployeeId = 9 });
            contacts.Add(new Models.Contact() { EmployeeId = 10 });
            

            return contacts;
        }
    }

    }

