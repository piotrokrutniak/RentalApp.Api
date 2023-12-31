﻿using Domain.Interfaces;
using System;

namespace Domain.Common
{
    public class AuditableBaseEntity : IEntity
    {
        public virtual int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
