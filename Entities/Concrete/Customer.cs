﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updater { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
