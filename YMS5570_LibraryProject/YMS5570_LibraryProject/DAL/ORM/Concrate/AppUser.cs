﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YMS5570_LibraryProject.DAL.ORM.Abstarct;

namespace YMS5570_LibraryProject.DAL.ORM.Concrate
{
    public enum Role
    {
        None=0,
        Admin=1,
        Employee=2,
        Customer=3,
        Author=4
    }

    public class AppUser:BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Role Role { get; set; }
        

        public virtual List<Book> Books { get; set; }

        public string Password { get; set; }

        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(LastName))
                {
                    return FirstName;
                }
                else
                {
                    return FirstName + " " + LastName;
                }
            }
        }

        public string UserName { get; set; }

        public override string ToString()
        {
            return FullName;
            
        }
    }
}
