using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public string Updater { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
