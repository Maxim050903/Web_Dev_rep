﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDevDataBase.Entities
{
    public class DisciplineEntity
    {
        public Guid id { get; set;  }
        public string Name { get; set;  } = string.Empty;
        public Guid idTeacher { get; set;  }
        public List<Guid> idGroups { get; set; }
    }
}
