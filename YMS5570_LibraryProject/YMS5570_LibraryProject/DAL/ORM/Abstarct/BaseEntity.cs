﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YMS5570_LibraryProject.DAL.ORM.Abstarct
{
    public enum Status
    {
        None=0,
        Active=1,
        Updated=2,
        Deleted=3

    }
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
       public int ID { get; set; }

        private DateTime _addDate = DateTime.Now;
        public DateTime AddDate
        {
            get { return _addDate; }
            set { _addDate = value; }
        }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }


    }
}
